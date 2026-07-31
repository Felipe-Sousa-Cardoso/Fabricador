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
        Receita = ReceitasArmaduras.Armadura_de_Couro,
        Materiais = new List<Material>
        {
            Materiais.Couro_Leve,
            Materiais.Couro_Leve,
            Materiais.Linho
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
        foreach (var material in contexto.Receita.Materiais)
        {
            if (contexto.Materiais.Count(m=> m.Tipo == material.Tipo) != material.Quantidade)
            {
                string erro = $"Quantidade de {material.Tipo} inválida. Esperado: {material.Quantidade}, Encontrado: {contexto.Materiais.Count(m => m.Tipo == material.Tipo)}";
                resultado.Erros.Add(erro);
                return false;
            }
        }
        foreach (var material in contexto.Materiais)
        {
            if (!contexto.Receita.Materiais.Any(m => m.Tipo == material.Tipo))
            {
                string erro = $"Material {material.Tipo} não é permitido na receita {contexto.Receita.Nome}";
                resultado.Erros.Add(erro);
                return false;
            }
        }
        return true;
    }
    Armadura ProcessarFabricarArmadura(ContextoFabricação<ReceitaArmadura> contexto, ResultadoFabricacao<Armadura> resultado)
    {
        int Qualidade = 0;
        foreach (var material in contexto.Materiais)
        {
            Qualidade += material.Qualidade;
        }
        int custo = 0;
        for (int i = 0; i < contexto.Receita.Materiais.Count; i++)
        {
            for (int j = 0; j < contexto.Receita.Materiais[i].Quantidade; j++)
            {
                custo += contexto.Materiais[i].Custo*contexto.Receita.Materiais[i].Pack;
            }
        }
        custo *= contexto.Receita.Custo;
        float peso = Qualidade * contexto.Receita.Peso;
        var reducoes = new List<ReduçãoDeDanoAplicado>();
        foreach (var reducao in contexto.Receita.ReduçõesDeDano)
        {
            reducoes.Add(new ReduçãoDeDanoAplicado(reducao.Tipo, ((int)(Qualidade * reducao.MultiplicadorQualidade))));
        }
        Armadura armadura = new Armadura(Qualidade,contexto.Receita.Descrição,custo,peso,contexto.Receita.Classe,reducoes,contexto.Receita.Nome);

        return armadura;
    }
}


