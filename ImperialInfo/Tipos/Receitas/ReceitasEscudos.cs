using ImperialInfo.Tipos.Materiais;

namespace ImperialInfo.Tipos.Receitas;

public static class ReceitasEscudos
{
    public static readonly ReceitaEscudo Escudo_Pequeno = new()
    {
        Nome = "Escudo Pequeno",
        Descrição = "Um escudo utilizado por mercenários e aventureiros espalhados por todo o mundo, concede uma boa proteção e custa barato",
        Materiais = new List<RequisitosMaterial>
        {
            new RequisitosMaterial(TiposMaterial.Madeira, 1, 4),
            new RequisitosMaterial(TiposMaterial.Metal, 1, 2)
        },
        Custo = 1,
        BloqueioAdicional = -1
    };

    public static readonly ReceitaEscudo Escudo_Reforçado = new()
    {
        Nome = "Escudo Reforçado",
        Descrição = "Um escudo bem maior e mais robusto que seu sucessor, é mais caro mas protege melhor",
        Materiais = new List<RequisitosMaterial>
        {
            new RequisitosMaterial(TiposMaterial.Madeira, 1, 6),
            new RequisitosMaterial(TiposMaterial.Metal, 1, 4)
        },
        Custo = 2,
        BloqueioAdicional = 0
    };

    public static readonly IReadOnlyList<ReceitaEscudo> Todos =
    [
        Escudo_Pequeno,
        Escudo_Reforçado
    ];
}
