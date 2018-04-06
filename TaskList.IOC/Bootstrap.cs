using SimpleInjector;
using TaskList.BLL;
using TaskList.DAL;
using TaskList.DAL.Infra.EntityFramework.Repositorio;
using TaskList.DAL.Infra.EntityFramework.Repositorio.Interfaces;

namespace TaskList.IOC
{
    /// <summary>
    /// Registra os serviços necessários bem como repositório e negócio
    /// </summary>
    public static class Bootstrap
    {
        public static void RegistrarServicos(Container container)
        {
            container.Register<TaskListContexto>(Lifestyle.Scoped);
            container.Register<ITarefaRepositorio, TarefaRepositorio>();
            container.Register<ITarefaNegocio, TarefaNegocio>();
        }
    }
}