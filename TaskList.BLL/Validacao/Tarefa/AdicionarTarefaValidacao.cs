using TaskList.DAL.Infra.EntityFramework.Repositorio.Interfaces;

namespace TaskList.BLL.Validacao
{
    public class AdicionarTarefaValidacao : TarefaValidacao
    {
        public AdicionarTarefaValidacao(ITarefaRepositorio repository)
        {
            this.ValidarDescricao(repository);
        }
    }
}
