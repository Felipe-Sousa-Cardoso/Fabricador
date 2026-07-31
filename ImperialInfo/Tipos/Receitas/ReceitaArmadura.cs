using System;
using System.Collections.Generic;
using System.Text;

namespace ImperialInfo.Tipos.Receitas;

public class ReceitaArmadura : Receita
{
    public required List<ReduçãoDeDanoReceita> ReduçõesDeDano { get; set; } = new List<ReduçãoDeDanoReceita>();
    public required ClassesDeArmadura Classe { get; set; }
    public required float Peso { get; set; }
    public List<PropriedadesEspeciais> Especiais { get; set; } = new List<PropriedadesEspeciais>();

}
