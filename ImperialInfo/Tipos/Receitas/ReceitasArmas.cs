using ImperialInfo.Tipos.Materiais;
using ImperialInfo.Tipos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImperialInfo.Tipos.Receitas;

public static class ReceitasArmas
{
    public static readonly ReceitaArma Espada_Longa = new()
    {
        Nome = "Espada Longa",
        Materiais = new List<RequisitosMaterial>
        {
            new RequisitosMaterial ( TiposMaterial.Metal, 1, 5 )
        },
        Custo = 2,
        Classe = ClassesDeArma.Espada,
        Dano = "(qualidade)d10 +2 Dfor de dano cortante, com (qualidade+Dfor) penetração",
        Características = new List<CaracterísticaArma>
        {
            new CaracterísticaArma ( CaracterísticasArma.Pesada )
        },
        Descrição = "Uma lâmina entre 1 metro e 1.3 metros de comprimento total, cabo longo o suficiente para ser usado com as duas mãos mas que também pode ser usado com uma, geralmente tem uma ponta fina que serve para estocar mas geralmente usada para corte."
    };
    public static readonly ReceitaArma Adaga = new()
    {
        Nome = "Adaga",
        Materiais = new List<RequisitosMaterial>
        {
            new RequisitosMaterial ( TiposMaterial.Metal, 1, 2 )
        },
        Custo = 1,
        Classe = ClassesDeArma.Espada,
        Dano = "d6 + (qualidade)Ddes de dano cortante, com (qualidade) penetração",
        Características = new List<CaracterísticaArma>
        {
            new CaracterísticaArma ( CaracterísticasArma.Leve ),
            new CaracterísticaArma ( CaracterísticasArma.Escamoteável ),
            new CaracterísticaArma ( CaracterísticasArma.Arremesso, 6, 18 )
        },
        Descrição = "Abrange adagas, facas, punhais e armas semelhantes."
    };
    public static readonly ReceitaArma Espada_Curta = new()
    {
        Nome = "Espada Curta",
        Materiais = new List<RequisitosMaterial>
        {
            new RequisitosMaterial ( TiposMaterial.Metal, 1, 3 )
        },
        Custo = 1,
        Classe = ClassesDeArma.Espada,
        Dano = "(qualidade)d8 +Dfor de dano cortante",
        Características = new List<CaracterísticaArma>
        {
            new CaracterísticaArma ( CaracterísticasArma.Leve )
        },
        Descrição = "Abrange uma enorme gama de espadas, sabres, gumes duplo ou simples, com lâmina entre 40 e 60 com comprimento total, o peso é balanceado no punho para melhorar o balanço e pode ser utilizado tanto para corte quanto para estocadas."
    };
    public static readonly ReceitaArma Machadinha = new()
    {
        Nome = "Machadinha",
        Materiais = new List<RequisitosMaterial>
        {
            new RequisitosMaterial ( TiposMaterial.Metal, 1 ),
            new RequisitosMaterial ( TiposMaterial.Madeira, 1 )
        },
        Custo = 1,
        Classe = ClassesDeArma.Machado,
        Dano = "d6 +(qualidade)Dfor de dano cortante",
        Características = new List<CaracterísticaArma>
        {
            new CaracterísticaArma ( CaracterísticasArma.Leve ),
            new CaracterísticaArma ( CaracterísticasArma.Arremesso, 6, 12 )
        },
        Descrição = "Um cabo curto com uma lâmina pequena na ponta, pode ser arremessado."
    };
    public static readonly ReceitaArma Machado_Combate = new()
    {
        Nome = "Machado de Combate",
        Materiais = new List<RequisitosMaterial>
        {
            new RequisitosMaterial ( TiposMaterial.Metal, 1, 2 ),
            new RequisitosMaterial ( TiposMaterial.Madeira, 1 )
        },
        Custo = 1,
        Classe = ClassesDeArma.Machado,
        Dano = "d10 +(qualidade)Dfor de dano cortante, com (qualidade) penetração",
        Características = new List<CaracterísticaArma>
        {
            new CaracterísticaArma ( CaracterísticasArma.Leve )
        },
        Descrição = "Um cabo robusto com uma lâmina pesada na ponta, pode ser lâmina única ou dupla dependendo do modelo, se diferencia de um machado de trabalho por ser mais leve e com corte melhor."
    };
    public static readonly ReceitaArma Clava = new()
    {
        Nome = "Clava",
        Materiais = new List<RequisitosMaterial>
        {
            new RequisitosMaterial ( TiposMaterial.Madeira, 1, 2 )
        },
        Custo = 0,
        Classe = ClassesDeArma.Martelo,
        Dano = "(qualidade) + Dfor de dano contusivo",
        Descrição = "Uma das armas mais simples usada por todos os povos, reúne uma série de armas semelhantes, como porretes, bastões e etc, é mt barato de ser produzida e mais utilizada por indivíduos mais primitivos ou improvisados."
    };
    public static readonly ReceitaArma Clava_Grande = new()
    {
        Nome = "Clava Grande",
        Materiais = new List<RequisitosMaterial>
        {
            new RequisitosMaterial ( TiposMaterial.Madeira, 2, 3 )
        },
        Custo = 0,
        Classe = ClassesDeArma.Martelo,
        Dano = "d12+(qualidade) + 2Dfor de dano contusivo",
        Características = new List<CaracterísticaArma>
        {
            new CaracterísticaArma ( CaracterísticasArma.Pesada ),
            new CaracterísticaArma ( CaracterísticasArma.DuasMãos )
        },
        Descrição = "Uma clava ou porrete maior e mais pesado que requer as 2 mãos para ser utilizada."
    };
    public static readonly ReceitaArma Martelo = new()
    {
        Nome = "Martelo",
        Materiais = new List<RequisitosMaterial>
        {
            new RequisitosMaterial ( TiposMaterial.Metal, 1, 2 ),
            new RequisitosMaterial ( TiposMaterial.Madeira, 1 )
        },
        Custo = 1,
        Classe = ClassesDeArma.Martelo,
        Dano = "(qualidade)d4 + 2 Dfor de dano contusivo + (qualidade) penetração",
        Especiais = new()
        {
            PropriedadesEspeciais.Denso
        },
        Descrição = "Um martelo, ou maça ou arma semelhante que causa dano contusivo e tem cabeça de algum metal, se aproveita de materiais densos para ser mais efetivo."
    };
    public static readonly ReceitaArma Lança_Curta = new()
    {
        Nome = "Lança Curta",
        Materiais = new List<RequisitosMaterial>
        {
            new RequisitosMaterial ( TiposMaterial.Metal, 1 ),
            new RequisitosMaterial ( TiposMaterial.Madeira, 1, 2 )
        },
        Custo = 1,
        Classe = ClassesDeArma.Haste,
        Dano = "(qualidade)d6 +Dfor de dano perfurante",
        Características = new List<CaracterísticaArma>
        {
            new CaracterísticaArma ( CaracterísticasArma.Arremesso, 6, 12 ),
            new CaracterísticaArma ( CaracterísticasArma.Alcance, 1 )
        },
        Descrição = "A arma mais antiga de humanidade, foi sendo aprimorada através das eras e agora conta com uma ponta de metal, útil para espetar seus inimigos de mais longe e manter uma distância segura."
    };
    public static readonly ReceitaArma Lança_Pesada = new()
    {
        Nome = "Lança Pesada",
        Materiais = new List<RequisitosMaterial>
        {
            new RequisitosMaterial ( TiposMaterial.Metal, 1, 3 ),
            new RequisitosMaterial ( TiposMaterial.Madeira, 1, 3 )
        },
        Custo = 2,
        Classe = ClassesDeArma.Haste,
        Dano = "(qualidade)d8 Dfor de dano perfurante, com (qualidade*2) penetração",
        Características = new List<CaracterísticaArma>
        {
            new CaracterísticaArma ( CaracterísticasArma.Alcance, 2 ),
            new CaracterísticaArma ( CaracterísticasArma.DuasMãos )
        },
        Descrição = "Uma lança maior e mais pesada que uma lança normal, causa mais dano, penetra melhor armadura e requer a 2 mãos para ser utilizada."
    };

    public static readonly IReadOnlyList<ReceitaArma> Todos =
    [
        Espada_Longa,
        Adaga,
        Espada_Curta,
        Machadinha,
        Machado_Combate,
        Clava,
        Clava_Grande,
        Martelo,
        Lança_Curta,
        Lança_Pesada
    ];
}
