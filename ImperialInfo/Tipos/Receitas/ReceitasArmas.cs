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
    public static readonly IReadOnlyList<ReceitaArma> Todos =
    [
        Espada_Longa
    ];
}
