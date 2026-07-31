using System;
using System.Collections.Generic;
using System.Text;

namespace ImperialInfo.Tipos;

public struct ReduçãoDeDanoReceita
{
    public required TiposDano Tipo { get; init; }
    public required float MultiplicadorQualidade { get; init; }
}