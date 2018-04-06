using TaskList.DAL.Infra.EntityFramework.Repositorio.Interfaces;
using TaskList.Model.Model;

namespace TaskList.DAL.Infra.EntityFramework.Repositorio
{
    public class TarefaRepositorio : RepositorioBase<Tarefa>, ITarefaRepositorio
    {
        public TarefaRepositorio(TaskListContexto contexto) :
            base(contexto)
        {
        }
    }
}

