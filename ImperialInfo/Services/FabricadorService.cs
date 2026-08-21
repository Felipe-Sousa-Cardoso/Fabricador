using ImperialInfo.Tipos;
using ImperialInfo.Tipos.Receitas;
using System;
using System.Collections.Generic;
using System.Text;
using ImperialInfo.Tipos.Materiais;
using ImperialInfo.Tipos.Fabricação;

namespace ImperialInfo.Services;

public class FabricadorService
{
    public ResultadoFabricacao<Armadura> FabricarArmadura(ContextoFabricação<ReceitaArmadura> contexto)
    {
        ResultadoFabricacao<Armadura> resultado = new ResultadoFabricacao<Armadura>() { Sucesso = false };
        if (!ValidarContexto(contexto,resultado))
        {
            return resultado;
        }
        Armadura armadura = ProcessarFabricarArmadura(contexto, resultado);
        return new ResultadoFabricacao<Armadura> { Sucesso = true , Item = armadura };
    }
    public ResultadoFabricacao<Arma> FabricarArma(ContextoFabricação<ReceitaArma> contexto)
    {
        ResultadoFabricacao<Arma> resultado = new ResultadoFabricacao<Arma>() { Sucesso = false };
        if (!ValidarContexto(contexto,resultado))
        {
            return resultado;
        }
        Arma arma = ProcessarFabricarArma(contexto);
        return new ResultadoFabricacao<Arma> { Sucesso = true , Item = arma };
    }
    bool ValidarContexto<TReceita, TProduto>(ContextoFabricação<TReceita> contexto, ResultadoFabricacao<TProduto> resultado) where TReceita : Receita
    {
        int indiceMaterial = 0;
        foreach (var requisito in contexto.Receita.Materiais)
        {
            for (int i = 0; i < requisito.Quantidade; i++)
            {
                if (contexto.Materiais[indiceMaterial].Tipo != requisito.Tipo)
                {
                    resultado.Erros.Add($"Materiais estão incorretos ou na ordem errada, a ordem esperada é: {string.Join(", ", contexto.Receita.Materiais)}");
                    return false;
                }

                indiceMaterial++;
            }
        }
        return true;
    }
    int CalcularQualidade<TReceita>(ContextoFabricação<TReceita> contexto) where TReceita : Receita
    {
        int qualidade = 0;
        foreach (var material in contexto.Materiais)
        {
            qualidade += material.Qualidade;
        }
        return qualidade;
    }
    int CalcularCusto<TReceita>(ContextoFabricação<TReceita> contexto) where TReceita : Receita
    {
        int custo = 0;
        int indiceMaterial = 0;
        foreach (var requisito in contexto.Receita.Materiais)
        {
            for (int i = 0; i < requisito.Quantidade; i++)
            {
                custo += contexto.Materiais[indiceMaterial].Custo * requisito.Pack;

                indiceMaterial++;
            }
        }
        custo *= contexto.Receita.Custo+1;
        return custo;
    }
    Armadura ProcessarFabricarArmadura(ContextoFabricação<ReceitaArmadura> contexto, ResultadoFabricacao<Armadura> resultado)
    {
        int Qualidade = CalcularQualidade(contexto);
        int custo = CalcularCusto(contexto);
        float peso = Qualidade * contexto.Receita.Peso;
        var reducoes = new List<ReduçãoDeDanoAplicado>();
        reducoes = contexto.Receita.ReduçõesDeDano
            .Select(r => new ReduçãoDeDanoAplicado(
                r.Tipo,
                (int)(Qualidade * r.MultiplicadorQualidade)))
            .ToList();

        var descriçõesEspeciais = contexto.Materiais.SelectMany(m => m.PropriedadeEspecifica).ToList();

        Armadura armadura = new Armadura(Qualidade,contexto.Receita.Descrição,custo,peso,contexto.Receita.Classe,reducoes,contexto.Receita.Nome,descriçõesEspeciais);

        AplicarPropriedades(contexto, armadura);

        return armadura;
    }
    Arma ProcessarFabricarArma(ContextoFabricação<ReceitaArma> contexto)
    {
        int qualidade = CalcularQualidade(contexto);
        int custo = CalcularCusto(contexto);

        AplicarPropriedades(contexto, ref qualidade);

        var descriçõesEspeciais = contexto.Materiais.SelectMany(m => m.PropriedadeEspecifica).ToList();
        string dano = contexto.Receita.Dano.Replace("qualidade", qualidade.ToString());

        return new Arma(qualidade, contexto.Receita.Descrição, custo, contexto.Receita.Classe, contexto.Receita.Características, dano, contexto.Receita.Nome, descriçõesEspeciais);
    }
    void AplicarPropriedades(ContextoFabricação<ReceitaArmadura> contexto, Armadura armadura)
    {
        foreach (var propriedade in contexto.Receita.Especiais)
        {
            switch (propriedade)
            {
                case PropriedadesEspeciais.Robusto:
                    AplicarRobusto(contexto, armadura);
                    break;
                case PropriedadesEspeciais.Acolchoado:
                    AplicarAcolchoado(contexto, armadura);
                    break;
                case PropriedadesEspeciais.Completo:
                    AplicarCompleto(contexto, armadura);
                    break;
                case PropriedadesEspeciais.Reforço:
                    AplicarReforço(contexto, armadura);
                    break;
                case PropriedadesEspeciais.Denso:
                    AplicarDenso(contexto, armadura);
                    break;
            }
        }
    }
    void AplicarPropriedades(ContextoFabricação<ReceitaArma> contexto, ref int qualidade)
    {
        foreach (var propriedade in contexto.Receita.Especiais)
        {
            switch (propriedade)
            {
                case PropriedadesEspeciais.Denso:
                    qualidade += BônusDaPropriedade(contexto, PropriedadesEspeciais.Denso);
                    break;
            }
        }
    }
    void AplicarRobusto(ContextoFabricação<ReceitaArmadura> contexto, Armadura armadura)
    {
        int bônus = BônusDaPropriedade(contexto, PropriedadesEspeciais.Robusto);
        if (bônus <= 0) return;
        AplicarBônusReduções(armadura.ReduçõesDeDano, bônus, TiposDano.Cortante, TiposDano.Perfurante);
        ElevarClasse(armadura, ClassesDeArmadura.Media);
    }
    void AplicarAcolchoado(ContextoFabricação<ReceitaArmadura> contexto, Armadura armadura)
    {
        int bônus = BônusDaPropriedade(contexto, PropriedadesEspeciais.Acolchoado);
        if (bônus <= 0) return;
        AplicarBônusReduções(armadura.ReduçõesDeDano, bônus, TiposDano.Contusivo);
    }
    void AplicarCompleto(ContextoFabricação<ReceitaArmadura> contexto, Armadura armadura)
    {
        int bônus = BônusDaPropriedade(contexto, PropriedadesEspeciais.Completo);
        if (bônus <= 0) return;
        AplicarBônusReduções(armadura.ReduçõesDeDano, bônus,
            TiposDano.Cortante, TiposDano.Perfurante, TiposDano.Contusivo, TiposDano.Magico, TiposDano.Puro);
        ElevarClasse(armadura, ClassesDeArmadura.Pesada);
    }
    void AplicarReforço(ContextoFabricação<ReceitaArmadura> contexto, Armadura armadura)
    {
        int bônus = BônusDaPropriedade(contexto, PropriedadesEspeciais.Reforço);
        if (bônus <= 0) return;
        AplicarBônusReduções(armadura.ReduçõesDeDano, bônus, TiposDano.Cortante, TiposDano.Perfurante);
    }
    void AplicarDenso(ContextoFabricação<ReceitaArmadura> contexto, Armadura armadura)
    {
        int bônus = BônusDaPropriedade(contexto, PropriedadesEspeciais.Denso);
        if (bônus <= 0) return;
        AplicarBônusReduções(armadura.ReduçõesDeDano, bônus, TiposDano.Cortante, TiposDano.Perfurante, TiposDano.Contusivo);
    }
    int BônusDaPropriedade<TReceita>(ContextoFabricação<TReceita> contexto, PropriedadesEspeciais propriedade) where TReceita : Receita
        => contexto.Materiais
            .SelectMany(m => m.Especiais)
            .Where(e => e.Propriedade == propriedade)
            .Sum(e => e.Valor);
    void AplicarBônusReduções(List<ReduçãoDeDanoAplicado> reducoes, int bônus, params TiposDano[] tipos)
    {
        foreach (var tipo in tipos)
        {
            AplicarAjuste(reducoes, new AjusteRedução(tipo, bônus));
        }
    }
    void ElevarClasse(Armadura armadura, ClassesDeArmadura mínimo)
    {
        if (armadura.Classe < mínimo)
        {
            armadura.Classe = mínimo;
        }
    }
    void AplicarAjuste(List<ReduçãoDeDanoAplicado> reducoes, AjusteRedução ajuste)
    {
        for (int i = 0; i < reducoes.Count; i++)
        {
            if (reducoes[i].Tipo == ajuste.Tipo)
            {
                var r = reducoes[i];
                r.Total += ajuste.Bônus;
                reducoes[i] = r;
                return;
            }
        }
        reducoes.Add(new ReduçãoDeDanoAplicado(ajuste.Tipo, ajuste.Bônus));
    }
}
