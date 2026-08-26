namespace ImperialInfo.Tipos.Receitas;

public class ReceitaEscudo : Receita
{
    public required float MultiplicadorDefesa { get; set; }
    public List<PropriedadesEspeciais> Especiais { get; set; } = new List<PropriedadesEspeciais>();
}
