using System.ComponentModel;

namespace TaskList.Model.Enum
{
    /// <summary>
    /// Status das tarefas
    /// </summary>
    public enum StatusTarefa
    {
        [Description("Pendente")]
        Pendente = 1,

        [Description("Concluído")]
        Concluido = 2,

        [Description("Excluído")]
        Excluido = 3
    }
}
