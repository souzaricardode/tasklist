using System;

namespace TaskList.Model.Model
{
    public class EntidadeBase
    {
        public int Id { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public DateTime? DataConclusao { get; set; }
        public DateTime? DataExclusao { get; set; }
    }
}
