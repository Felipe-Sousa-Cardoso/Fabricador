using ImperialInfo.Tipos.Materiais;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImperialInfo.Tipos.Fabricação;

public class ContextoFabricação<TReceita>
    where TReceita : Receita
{
    public required TReceita Receita { get; init; }

    public required List<Material> Materiais { get; init; }
}
