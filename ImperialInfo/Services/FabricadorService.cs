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

        AplicarPropriedades(contexto, reducoes);

        Armadura armadura = new Armadura(Qualidade,contexto.Receita.Descrição,custo,peso,contexto.Receita.Classe,reducoes,contexto.Receita.Nome);

        return armadura;
    }
    void AplicarPropriedades(ContextoFabricação<ReceitaArmadura> contexto, List<ReduçãoDeDanoAplicado> reducoes)
    {
        foreach (var propriedade in contexto.Receita.Especiais)
        {
            var ajustes = propriedade switch
            {
                PropriedadesEspeciais.Robusto => AplicarRobusto(contexto, reducoes),
                _ => null
            };
            if (ajustes is null) continue;

            foreach (var ajuste in ajustes)
            {
                AplicarAjuste(reducoes, ajuste);
            }
        }
    }
    List<AjusteRedução> AplicarRobusto(ContextoFabricação<ReceitaArmadura> contexto, List<ReduçãoDeDanoAplicado> reducoes)
    {
        int bônus = contexto.Materiais
            .SelectMany(m => m.Especiais)
            .Where(e => e.Propriedade == PropriedadesEspeciais.Robusto)
            .Sum(e => e.Valor);
        if (bônus <= 0) return [];

        return reducoes.Select(r => new AjusteRedução(r.Tipo, bônus)).ToList();
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


