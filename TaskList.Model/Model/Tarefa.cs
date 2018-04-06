using TaskList.Model.Enum;

namespace TaskList.Model.Model
{
    /// <summary>
    /// Classe utilizada para controlar tarefas
    /// </summary>
    public class Tarefa : EntidadeBase
    {
        public string Descricao { get; set; }
        public StatusTarefa Status { get; set; } = StatusTarefa.Pendente;
    }
}
