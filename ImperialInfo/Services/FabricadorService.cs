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
    ContextoFabricação<ReceitaArmadura> contextoteste = new ContextoFabricação<ReceitaArmadura>
    {
        Receita = ReceitasArmaduras.Armadura_de_cota_de_malha_completa,
        Materiais = new List<Material>
        {
            
            Materiais.Ferro,
            Materiais.Aço,
            Materiais.Linho,
            Materiais.Couro_Leve
            

        }
    };

    public ResultadoFabricacao<Armadura> teste()
    {
        return FabricarArmadura(contextoteste);
    }
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
    bool ValidarContexto(ContextoFabricação<ReceitaArmadura> contexto, ResultadoFabricacao<Armadura> resultado)
    {
        if(contexto.Receita is not ReceitaArmadura)
        {
            resultado.Erros.Add("Receita inválida");
            return false;
        }
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
    Armadura ProcessarFabricarArmadura(ContextoFabricação<ReceitaArmadura> contexto, ResultadoFabricacao<Armadura> resultado)
    {
        //Qualidade
        int Qualidade = 0;
        foreach (var material in contexto.Materiais)
        {
            Qualidade += material.Qualidade;
        }
        //Custo
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
        custo *= contexto.Receita.Custo;
        //Peso
        float peso = Qualidade * contexto.Receita.Peso;
        //Reduções de dano
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
    int BônusDaPropriedade(ContextoFabricação<ReceitaArmadura> contexto, PropriedadesEspeciais propriedade)
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


