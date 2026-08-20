using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ImperialInfo.Tipos;

public enum CaracterísticasArma
{
    Escamoteável,
    Leve,
    Pesada,
    Arremesso,
    DuasMãos,
    Alcance
}

public struct CaracterísticaArma
{
    [SetsRequiredMembers]
    public CaracterísticaArma(CaracterísticasArma tipo, int? valor1 = null, int? valor2 = null)
    {
        Tipo = tipo;
        Valor1 = valor1;
        Valor2 = valor2;
    }

    public required CaracterísticasArma Tipo { get; init; }
    public int? Valor1 { get; init; }
    public int? Valor2 { get; init; }

    public override string ToString()
    {
        return (Tipo, Valor1, Valor2) switch
        {
            (CaracterísticasArma.Arremesso, { } v1, { } v2) => $"Arremesso ({v1}/{v2})",
            (CaracterísticasArma.Alcance, { } v1, _) => $"Alcance ({v1})",
            _ => Tipo.ToString()
        };
    }
}

public static class DescriçõesCaracterísticasArma
{
    public static string Obter(CaracterísticasArma característica) => característica switch
    {
        CaracterísticasArma.Escamoteável => "Pequena ou discreta o suficiente para ser escondida no corpo ou entre as roupas com facilidade.",
        CaracterísticasArma.Leve => "Arma de pouco peso e bom equilíbrio, fácil de manusear e de carregar em longas jornadas.",
        CaracterísticasArma.Pesada => "Arma de grande massa, exigindo força e espaço para ser manejada com eficácia.",
        CaracterísticasArma.Arremesso => "Pode ser arremessada contra alvos à distância.",
        CaracterísticasArma.DuasMãos => "Exige as duas mãos para ser empunhada corretamente.",
        CaracterísticasArma.Alcance => "Possui alcance para golpear ou atacar alvos além do corpo a corpo imediato.",
        _ => string.Empty
    };
}
