using System;
using System.Collections.Generic;
using System.Text;

namespace ImperialInfo.Tipos.Materiais;

public class Material
{
    public required TiposMaterial Tipo { get; set; }
    public required string Nome { get; set; }
    public required int Qualidade { get; set; }
    public required int Custo { get; set; }
    public required string Descrição { get; set; }
    public List<(PropriedadesEspeciais Propriedade, int Valor)> Especiais { get; set; } = new List<(PropriedadesEspeciais Propriedade, int Valor)>();

    public List<string> PropriedadeEspecifica { get; set; } = new List<string>();
}
