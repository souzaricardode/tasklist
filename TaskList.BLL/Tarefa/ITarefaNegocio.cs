using TaskList.BLL.Interfaces;
using TaskList.Model.Enum;
using TaskList.Model.Model;

namespace TaskList.BLL
{
    public interface ITarefaNegocio : INegocio<Tarefa>
    {
        /// <summary>
        /// Obtem uma tarefa pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Tarefa ObterPorId(long id);

        /// <summary>
        /// Define o status da tarefa realizando algumas validações
        /// </summary>
        /// <param name="entidade"></param>
        /// <param name="status"></param>
        void DefineStatus(Tarefa entidade, StatusTarefa status);

        /// <summary>
        /// Conclui uma tarefa
        /// </summary>
        /// <param name="entidade"></param>
        void Concluir(Tarefa entidade);

        /// <summary>
        /// Reabre uma tarefa concluída
        /// </summary>
        /// <param name="entidade"></param>
        void Reabrir(Tarefa entidade);

        /// <summary>
        /// Retorna se uma tarefa está concluída
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        bool TarefaConcluida(Tarefa entidade);

        /// <summary>
        /// Retornar se uma tarefa foi excluída
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        bool TarefaExcluida(Tarefa entidade);
    }
}
