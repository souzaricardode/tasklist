using System;
using System.ComponentModel.DataAnnotations;

namespace TaskList.Model.Dto
{
    public class EntidadeBaseDto
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Data de Criação")]
        public DateTime? DataCriacao { get; set; }

        [Display(Name = "Data de Alteração")]
        public DateTime? DataAlteracao { get; set; }

        [Display(Name = "Data de Conclusão")]
        public DateTime? DataConclusao { get; set; }

        [Display(Name = "Data de Exclusão")]
        public DateTime? DataExclusao { get; set; }
    }
}
