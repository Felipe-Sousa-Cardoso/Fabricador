using ImperialInfo.Tipos.Materiais;
using ImperialInfo.Tipos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImperialInfo.Tipos.Receitas;

public static class ReceitasArmaduras
{
    public static readonly ReceitaArmadura Armadura_de_Couro = new()
    {
        Nome = "Armadura de Couro", 
        Materiais = new List<RequisitosMaterial>
        {
            new RequisitosMaterial ( TiposMaterial.Couro, 2)
        },
        ReduçõesDeDano = new List<ReduçãoDeDanoReceita>
        {
            new ReduçãoDeDanoReceita { Tipo = TiposDano.Cortante, MultiplicadorQualidade = 1f }
        },
        Custo = 1,
        Peso = 0.5f,
        Classe = ClassesDeArmadura.Leve,
        Especiais = new List<PropriedadesEspeciais>
        {
            PropriedadesEspeciais.Robusto,
            PropriedadesEspeciais.Completo
        }
    };
    public static readonly ReceitaArmadura Armadura_de_Couro_Acolchoada = new()
    {
        Nome = "Armadura de Couro Acolchoada",
        Materiais = new List<RequisitosMaterial>
        {
            new RequisitosMaterial ( TiposMaterial.Couro, 2 ),
            new RequisitosMaterial ( TiposMaterial.TextelBruto, 1 )
        },
        ReduçõesDeDano = new List<ReduçãoDeDanoReceita>
        {
            new ReduçãoDeDanoReceita { Tipo = TiposDano.Cortante, MultiplicadorQualidade = 1f },
            new ReduçãoDeDanoReceita { Tipo = TiposDano.Contusivo, MultiplicadorQualidade = 1f }
        },
        Custo = 2,
        Peso = 1f,
        Classe = ClassesDeArmadura.Leve,
         Especiais = new List<PropriedadesEspeciais>
        {
            PropriedadesEspeciais.Robusto,
            PropriedadesEspeciais.Completo,
            PropriedadesEspeciais.Acolchoado
        }
    };
    public static readonly ReceitaArmadura Armadura_de_tecido = new()
    {
        Nome = "Armadura de Tecido",
        Materiais = new List<RequisitosMaterial>
        {
            new RequisitosMaterial ( TiposMaterial.TextelBruto, 1 )
        },
        ReduçõesDeDano = new List<ReduçãoDeDanoReceita>
        {
            new ReduçãoDeDanoReceita { Tipo = TiposDano.Cortante, MultiplicadorQualidade = 1f },
            new ReduçãoDeDanoReceita { Tipo = TiposDano.Contusivo, MultiplicadorQualidade = 0.5f }
        },
        Custo = 1,
        Peso = 1,
        Classe = ClassesDeArmadura.Leve,
    };
    public static readonly ReceitaArmadura Armadura_de_tecido_Reforçado = new()
    {
        Nome = "Armadura de Tecido Reforçado",
        Materiais = new List<RequisitosMaterial>
        {
            new RequisitosMaterial ( TiposMaterial.TextelBruto, 2 )
        },
        ReduçõesDeDano = new List<ReduçãoDeDanoReceita>
        {
            new ReduçãoDeDanoReceita { Tipo = TiposDano.Cortante, MultiplicadorQualidade = 1f },
            new ReduçãoDeDanoReceita { Tipo = TiposDano.Contusivo, MultiplicadorQualidade = 1f }
        },
        Custo = 2,
        Peso = 1,
        Classe = ClassesDeArmadura.Leve,
        Especiais = new List<PropriedadesEspeciais>
        {
            PropriedadesEspeciais.Reforço
        }
    };
    public static readonly ReceitaArmadura Armadura_de_cota_de_malha = new()
    {
        Nome = "Armadura de Cota de Malha",
        Materiais = new List<RequisitosMaterial>
        {
            new RequisitosMaterial ( TiposMaterial.Metal, 1, 12 )
        },
        ReduçõesDeDano = new List<ReduçãoDeDanoReceita>
        {
            new ReduçãoDeDanoReceita { Tipo = TiposDano.Cortante, MultiplicadorQualidade = 1f },
            new ReduçãoDeDanoReceita { Tipo = TiposDano.Perfurante, MultiplicadorQualidade = 0.5f }
        },
        Custo = 2,
        Peso = 2,
        Classe = ClassesDeArmadura.Media,
    };
    public static readonly ReceitaArmadura Armadura_de_cota_de_malha_acolchoada = new()
    {
        Nome = "Armadura de Cota de Malha Acolchoada",
        Materiais = new List<RequisitosMaterial>
        {
            new RequisitosMaterial ( TiposMaterial.Metal, 1, 12 ),
            new RequisitosMaterial ( TiposMaterial.TextelBruto, 1 )
        },
        ReduçõesDeDano = new List<ReduçãoDeDanoReceita>
        {
            new ReduçãoDeDanoReceita { Tipo = TiposDano.Cortante, MultiplicadorQualidade = 1f },
            new ReduçãoDeDanoReceita { Tipo = TiposDano.Perfurante, MultiplicadorQualidade = 0.5f },
            new ReduçãoDeDanoReceita { Tipo = TiposDano.Contusivo, MultiplicadorQualidade = 0.5f }
        },
        Custo = 3,
        Peso = 2,
        Classe = ClassesDeArmadura.Media,
        Especiais = new List<PropriedadesEspeciais>
        {
            PropriedadesEspeciais.Acolchoado
        }
    };
    public static readonly ReceitaArmadura Armadura_de_cota_de_malha_completa = new()
    {
        Nome = "Armadura de Cota de Malha Completa",
        Materiais = new List<RequisitosMaterial>
        {
            new RequisitosMaterial ( TiposMaterial.Metal, 2, 12 ),
            new RequisitosMaterial ( TiposMaterial.TextelBruto, 1 ),
            new RequisitosMaterial ( TiposMaterial.Couro, 1 )
        },
        ReduçõesDeDano = new List<ReduçãoDeDanoReceita>
        {
            new ReduçãoDeDanoReceita { Tipo = TiposDano.Cortante, MultiplicadorQualidade = 1.5f },
            new ReduçãoDeDanoReceita { Tipo = TiposDano.Perfurante, MultiplicadorQualidade = 0.5f },
            new ReduçãoDeDanoReceita { Tipo = TiposDano.Contusivo, MultiplicadorQualidade = 0.5f }
        },
        Custo = 3,
        Peso = 3,
        Classe = ClassesDeArmadura.Media,
        Especiais = new List<PropriedadesEspeciais>
        {
            PropriedadesEspeciais.Acolchoado
        }
    };
    public static readonly ReceitaArmadura Armadura_de_tiras = new()
    {
        Nome = "Armadura de Tiras", 
        Materiais = new List<RequisitosMaterial>
        {
            new RequisitosMaterial ( TiposMaterial.Metal, 1, 20 ),
            new RequisitosMaterial ( TiposMaterial.TextelBruto, 1 ),
            new RequisitosMaterial ( TiposMaterial.Couro, 1 )
        },
        ReduçõesDeDano = new List<ReduçãoDeDanoReceita>
        {
            new ReduçãoDeDanoReceita { Tipo = TiposDano.Cortante, MultiplicadorQualidade = 1.5f },
            new ReduçãoDeDanoReceita { Tipo = TiposDano.Perfurante, MultiplicadorQualidade = 1f },
            new ReduçãoDeDanoReceita { Tipo = TiposDano.Contusivo, MultiplicadorQualidade = 1f }
        },
        Custo = 3,
        Peso = 4,
        Classe = ClassesDeArmadura.Pesada,
        Especiais = new List<PropriedadesEspeciais>
        {
            PropriedadesEspeciais.Acolchoado,
            PropriedadesEspeciais.Denso
        }
    };
    public static readonly ReceitaArmadura Armadura_de_tiras_completa = new()
    {
        Nome = "Armadura de Tiras Completa",
        Materiais = new List<RequisitosMaterial>
        {
            new RequisitosMaterial ( TiposMaterial.Metal, 1, 20 ),
            new RequisitosMaterial ( TiposMaterial.Metal, 2, 12 ),
            new RequisitosMaterial ( TiposMaterial.TextelBruto, 1 ),
            new RequisitosMaterial ( TiposMaterial.Couro, 1 )
        },
        ReduçõesDeDano = new List<ReduçãoDeDanoReceita>
        {
            new ReduçãoDeDanoReceita { Tipo = TiposDano.Cortante, MultiplicadorQualidade = 1.5f },
            new ReduçãoDeDanoReceita { Tipo = TiposDano.Perfurante, MultiplicadorQualidade = 1f },
            new ReduçãoDeDanoReceita { Tipo = TiposDano.Contusivo, MultiplicadorQualidade = 1f }
        },
        Custo = 4,
        Peso = 4,
        Classe = ClassesDeArmadura.Pesada,
        Especiais = new List<PropriedadesEspeciais>
        {
            PropriedadesEspeciais.Acolchoado,
            PropriedadesEspeciais.Denso
        }
    };
    public static readonly IReadOnlyList<ReceitaArmadura> Todos =
    [
        Armadura_de_Couro,
        Armadura_de_Couro_Acolchoada,
        Armadura_de_tecido,
        Armadura_de_tecido_Reforçado,
        Armadura_de_cota_de_malha,
        Armadura_de_cota_de_malha_acolchoada,
        Armadura_de_cota_de_malha_completa,
        Armadura_de_tiras,
        Armadura_de_tiras_completa
    ];
}
