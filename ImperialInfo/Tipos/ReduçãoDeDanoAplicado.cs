using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ImperialInfo.Tipos
{
    public struct ReduçãoDeDanoAplicado
    {
        [SetsRequiredMembers]
        public ReduçãoDeDanoAplicado(TiposDano tipo, int total)
        {
            Tipo = tipo;
            Total = total;
        }

        public required TiposDano Tipo { get; set; }
        public required int Total { get; set; }
    }
}
