using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ImperialInfo.Tipos;

public class Armadura
{
    [SetsRequiredMembers]
    public Armadura(int qualidade, string? descricao, int custo, float peso, ClassesDeArmadura classe, List<ReduçãoDeDanoAplicado> reduçõesDeDano, string tipo, List<string> descriçõesEspeciais)
    {
        Qualidade = qualidade;
        Descricao = descricao;
        Custo = custo;
        Peso = peso;
        Classe = classe;
        ReduçõesDeDano = reduçõesDeDano;
        Tipo = tipo;
        DescriçõesEspeciais = descriçõesEspeciais;
    }
    public required string Tipo { get; set; }
    public required int Qualidade { get; set; }
    public required string? Descricao { get; set; }

    public required int Custo { get; set; }
    public required float Peso { get; set; }

    public required ClassesDeArmadura Classe { get; set; }

    public required List<ReduçãoDeDanoAplicado> ReduçõesDeDano { get; set; } = new List<ReduçãoDeDanoAplicado>();

    public required List<string> DescriçõesEspeciais { get; set; } = new List<string>();
}
