using ImperialInfo.Tipos.Materiais;
using ImperialInfo.Tipos.Receitas;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImperialInfo.Tipos;

public abstract class Receita
{
    public required string Nome { get; set; }
    public int Custo { get; set; }
    public List<RequisitosMaterial> Materiais { get; set; } = new List<RequisitosMaterial>();
    public List<TiposPropriedadesEspeciais> PropriedadesEspeciais { get; set; } = new List<TiposPropriedadesEspeciais>();

    public string? Descrição { get; set; }

}
