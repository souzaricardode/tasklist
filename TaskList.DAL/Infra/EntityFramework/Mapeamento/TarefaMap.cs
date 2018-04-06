using TaskList.Model.Model;

namespace TaskList.DAL.Infra.EntityFramework.Mapeamento
{
    /// <summary>
    /// Define o mapeamento da entidade TAREFA, bem como nome da tabela, nomes de campos, indíces e outros.
    /// </summary>
    public class TarefaMap : BaseMap<Tarefa>
    {
        public TarefaMap()
        {
            ToTable("tarefa");
        }
    }
}
