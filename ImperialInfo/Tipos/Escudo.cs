using System.Diagnostics.CodeAnalysis;

namespace ImperialInfo.Tipos;

public class Escudo
{
    [SetsRequiredMembers]
    public Escudo(string tipo, int qualidade, string? descricao, int custo, int bloqueio, List<string> descriçõesEspeciais)
    {
        Tipo = tipo;
        Qualidade = qualidade;
        Descricao = descricao;
        Custo = custo;
        Bloqueio = bloqueio;
        DescriçõesEspeciais = descriçõesEspeciais;
    }

    public required string Tipo { get; set; }
    public required int Qualidade { get; set; }
    public required string? Descricao { get; set; }
    public required int Custo { get; set; }
    public required int Bloqueio { get; set; }
    public required List<string> DescriçõesEspeciais { get; set; }
}
