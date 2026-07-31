using ImperialInfo.Tipos.Materiais;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ImperialInfo.Tipos.Receitas;

public struct RequisitosMaterial
{
    public required TiposMaterial Tipo { get; init; }
    public required int Quantidade { get; init; }
    public int Pack { get; init; }
    [SetsRequiredMembers]
    public RequisitosMaterial(TiposMaterial tipo, int quantidade, int pack = 1)
    {
        Tipo = tipo;
        Quantidade = quantidade;
        Pack = pack;
    }

    public override string ToString()
    {
        return $"Tipo: {Tipo} Quantidae: {Quantidade} Pack: {Pack}";
        ;
    }
}
