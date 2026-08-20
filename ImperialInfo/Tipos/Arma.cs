using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ImperialInfo.Tipos;

public class Arma
{
    [SetsRequiredMembers]
    public Arma(int qualidade, string? descricao, int custo, ClassesDeArma classe, List<CaracterísticaArma> características, string dano, string tipo, List<string> descriçõesEspeciais)
    {
        Qualidade = qualidade;
        Descricao = descricao;
        Custo = custo;
        Classe = classe;
        Características = características;
        Dano = dano;
        Tipo = tipo;
        DescriçõesEspeciais = descriçõesEspeciais;
    }
    public required string Tipo { get; set; }
    public required int Qualidade { get; set; }
    public required string? Descricao { get; set; }

    public required int Custo { get; set; }

    public required ClassesDeArma Classe { get; set; }

    public required List<CaracterísticaArma> Características { get; set; } = new List<CaracterísticaArma>();

    public required string Dano { get; set; }

    public required List<string> DescriçõesEspeciais { get; set; } = new List<string>();
}
