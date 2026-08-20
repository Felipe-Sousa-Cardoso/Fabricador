using System;
using System.Collections.Generic;
using System.Text;

namespace ImperialInfo.Tipos.Materiais;

public static class Materiais
{
    public static readonly Material LigaIntermediária = new()
    {
        Tipo = TiposMaterial.Metal,
        Nome = "Liga Intermediária",
        Qualidade = 1,
        Custo = 2,
        Descrição = "Representada pelo bronze. Bastante comum é empregada em ferramentas e equipamentos baratos, usados por camponeses e aventureiros iniciantes. Resolve o problema básico, mas opções melhores são necessárias em situações de maior exigência."
    };
    public static readonly Material Ferro = new()
    {
        Tipo = TiposMaterial.Metal,
        Nome = "Ferro",
        Qualidade =2,
        Custo = 5,
        Descrição = "Material padrão empregado em armas e armaduras de aventureiros e mercenários mais experientes. É abundante, mas a dificuldade de obtenção e refino eleva seu preço, refletindo-se em uma qualidade superior."

    };

    public static readonly Material Aço = new()
    {
        Tipo = TiposMaterial.Metal,
        Nome = "Aço",
        Qualidade = 3,
        Custo = 40,
        Descrição = " Material mais escasso e de produção complexa, empregado em equipamentos de alta exigência. Seu custo elevado reflete diretamente na excelência e resistência do item.",
        Especiais = new()
        {
            (PropriedadesEspeciais.Denso, 1),
        }   
    };
    public static readonly Material Luminium = new()
    {
        Tipo = TiposMaterial.Metal,
        Nome = "Luminium",
        Qualidade = 4,
        Custo = 100,
        Descrição = " Material mais escasso e de produção complexa, empregado em equipamentos de alta exigência. Seu custo elevado reflete diretamente na excelência e resistência do item.",
        Especiais = new()
        {
            (PropriedadesEspeciais.Denso, 2),
        },
        PropriedadeEspecifica = new()
        {
            "ProteçãoMágica: Testes para resistir a magia são feitos com +20"
        }
    };

    public static readonly Material Lã = new()
    {
        Tipo = TiposMaterial.TextelBruto,
        Nome = "Lã",
        Qualidade = 1,
        Custo = 5,
        Descrição = "Lã comum recém-recolhida, devidamente separada e processada. Serve como base para tecidos e acolchoamentos."
    };
    public static readonly Material Linho = new()
    {
        Tipo = TiposMaterial.TextelBruto,
        Nome = "Linho",
        Qualidade = 1,
        Custo = 8,
        Descrição = "Linho recém-colhido com processamento básico. Serve como base para tecidos e acolchoamentos."
    };
    public static readonly Material Algodão = new()
    {
        Tipo = TiposMaterial.TextelBruto,
        Nome = "Algodão",
        Qualidade = 1,
        Custo = 15,
        Descrição = "Algodão recém-colhido e macio. Roupas de algodão protegem contra o frio e formam ótimos acolchoamentos.",
        Especiais = new()
        {
            (PropriedadesEspeciais.Acolchoado, 2),
        }
    };
    public static readonly Material Morlã = new()
    {
        Tipo = TiposMaterial.TextelBruto,
        Nome = "Morlã",
        Qualidade = 2,
        Custo = 20,
        Descrição = "Morlã recolhida e processada, muito mais resistente que a lã comum. Serve como base para tecidos e acolchoamentos",
        Especiais = new()
        {
            (PropriedadesEspeciais.Reforço, 1),
        }
    };
    public static readonly Material Couro_Leve = new()
    {
        Tipo = TiposMaterial.Couro,
        Nome = "Couro Leve",
        Qualidade = 1,
        Custo = 40,
        Descrição = "Peles de animais comuns, curtidas e processadas.",
    };
    public static readonly Material Couro_Pesado = new()
    {
        Tipo = TiposMaterial.Couro,
        Nome = "Couro Pesado",
        Qualidade = 2,
        Custo = 60,
        Descrição = "Couraça de grandes feras e animais resistentes.",
    };

    public static readonly Material Couro_Elemental = new()
    {
        Tipo = TiposMaterial.Couro,
        Nome = "Couro Elemental",
        Qualidade = 3,
        Custo = 250,
        Descrição = "Couro de bestas elementais adaptadas a eventos extremos de surto de magia. Raro e valioso.",
        Especiais = new()
        {
            (PropriedadesEspeciais.Robusto, 1),
        }
    };

    public static readonly Material Couro_De_Escamas_Elementais = new()
    {
        Tipo = TiposMaterial.Couro,
        Nome = "Couro de Escamas Elementais",
        Qualidade = 5,
        Custo = 600,
        Descrição = "Couro de bestas elementais adaptadas a eventos extremos de surto de magia. Raro e valioso.",
        Especiais = new()
        {
            (PropriedadesEspeciais.Completo, 1),
        }
    };

    public static readonly IReadOnlyList<Material> Todos =
    [
        LigaIntermediária,
        Ferro,
        Aço,
        Luminium,
        Lã,
        Linho,
        Algodão,
        Morlã,
        Couro_Leve,
        Couro_Pesado,
        Couro_Elemental,
        Couro_De_Escamas_Elementais
    ];
}
