using System;
using System.Collections.Generic;
using System.Text;

namespace ImperialInfo.Tipos.Receitas;

public class ReceitaArma : Receita
{
    public required ClassesDeArma Classe { get; set; }
    public required string Dano { get; set; }
    public List<CaracterísticaArma> Características { get; set; } = new List<CaracterísticaArma>();
    public List<PropriedadesEspeciais> Especiais { get; set; } = new List<PropriedadesEspeciais>();
}
