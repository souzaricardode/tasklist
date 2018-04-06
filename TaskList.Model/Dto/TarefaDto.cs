using System.ComponentModel.DataAnnotations;
using TaskList.Model.Enum;

namespace TaskList.Model.Dto
{
    /// <summary>
    /// Classe utilizada para controlar tarefas
    /// </summary>
    public class TarefaDto : EntidadeBaseDto
    {
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Status")]
        public StatusTarefa Status { get; set; } = StatusTarefa.Pendente;
    }
}
