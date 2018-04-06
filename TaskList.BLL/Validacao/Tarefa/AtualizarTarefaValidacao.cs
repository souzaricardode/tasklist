using TaskList.DAL.Infra.EntityFramework.Repositorio.Interfaces;

namespace TaskList.BLL.Validacao
{
    public class AtualizarTarefaValidacao : TarefaValidacao
    {
        public AtualizarTarefaValidacao(ITarefaRepositorio repository)
        {
            this.ValidarDescricao(repository);
        }
    }
}
