using ImperialInfo.Tipos.Materiais;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImperialInfo.Tipos.Fabricação;
public class ResultadoFabricacao<T>
{
    public required bool Sucesso { get; set; }

    public T? Item { get; init; }

    public List<string> Erros { get; set; } = [];
}