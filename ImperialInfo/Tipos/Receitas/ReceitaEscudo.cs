namespace ImperialInfo.Tipos.Receitas;

public class ReceitaEscudo : Receita
{
    public required int BloqueioAdicional { get; set; }
    public List<PropriedadesEspeciais> Especiais { get; set; } = new List<PropriedadesEspeciais>();
}
