using ImperialInfo.Tipos.Materiais;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImperialInfo.Services;

public class MateriaisService
{
    public IReadOnlyList<Material> Todos => Materiais.Todos;

    public Material? Obter(string nome)
        => Materiais.Todos.FirstOrDefault(m => m.GetType().Name == nome);

    public IEnumerable<Material> ObterTodos(TiposMaterial tipo)
        => Materiais.Todos.Where(m => m.Tipo == tipo);
}
