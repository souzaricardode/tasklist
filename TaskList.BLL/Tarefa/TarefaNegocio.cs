using System;
using TaskList.BLL.Interfaces;
using TaskList.BLL.Validacao;
using TaskList.DAL.Infra.EntityFramework.Repositorio.Interfaces;
using TaskList.Model.Enum;
using TaskList.Model.Excecoes;
using TaskList.Model.Model;
using TaskList.Model.Resources;

namespace TaskList.BLL
{
    public class TarefaNegocio : NegocioBase<Tarefa>, ITarefaNegocio
    {
        private new ITarefaRepositorio repositorio;

        public TarefaNegocio(ITarefaRepositorio repositorio)
            : base(repositorio)
        {
            this.repositorio = repositorio;
        }

        public Tarefa ObterPorId(long id)
        {
            return repositorio.BuscarPorId(id);
        }

        public override void Adicionar(Tarefa entidade)
        {
            var validador = new AdicionarTarefaValidacao(repositorio);
            var resultadoValidacao = validador.Validate(entidade);

            if (!resultadoValidacao.IsValid)
            {
                throw new ValidacaoException(ResourceValidacoes.CAMPOS_INVALIDOS, resultadoValidacao.Errors);
            }

            base.Adicionar(entidade);
        }

        public object Invoking(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        public override void Atualizar(Tarefa entidade)
        {
            var validador = new AtualizarTarefaValidacao(repositorio);
            var resultadoValidacao = validador.Validate(entidade);

            if (!resultadoValidacao.IsValid)
            {
                throw new ValidacaoException(ResourceValidacoes.CAMPOS_INVALIDOS, resultadoValidacao.Errors);
            }

            base.Atualizar(entidade);
        }

        public override void Remover(Tarefa entidade)
        {
            var validador = new RemoverTarefaValidacao(repositorio);
            var resultadoValidacao = validador.Validate(entidade);

            if (!resultadoValidacao.IsValid)
            {
                throw new ValidacaoException(ResourceValidacoes.CAMPOS_INVALIDOS, resultadoValidacao.Errors);
            }

            //Não remover a entidade, mas sim colocar como status Excluído.
            //base.Remover(entidade);

            DefineStatus(entidade, StatusTarefa.Excluido);
            base.Atualizar(entidade);
        }

        /// <summary>
        /// Define o status da tarefa, realizando algumas validações
        /// </summary>
        /// <param name="entidade"></param>
        /// <param name="status"></param>
        public void DefineStatus(Tarefa entidade, StatusTarefa status)
        {
            if (entidade.Status == StatusTarefa.Excluido)
            {
                throw new ValidacaoException(ResourceValidacoes.ALTERA_STATUS_TAREFA_JA_EXCLUIDA);
            }

            if (status == StatusTarefa.Excluido)
            {
                entidade.DataExclusao = DateTime.Now;
            }

            entidade.Status = status;
        }

        /// <summary>
        /// Conclui uma tarefa
        /// </summary>
        /// <param name="entidade"></param>
        public void Concluir(Tarefa entidade)
        {
            this.DefineStatus(entidade, StatusTarefa.Concluido);
            this.Atualizar(entidade);
        }

        /// <summary>
        /// Reabre uma tarefa e define ela como pendente
        /// </summary>
        /// <param name="entidade"></param>
        public void Reabrir(Tarefa entidade)
        {
            this.DefineStatus(entidade, StatusTarefa.Pendente);
            this.Atualizar(entidade);
        }

        /// <summary>
        /// Retornar se a tarefa foi concluida
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        public bool TarefaConcluida(Tarefa entidade)
        {
            return (entidade != null && entidade.Status == StatusTarefa.Concluido);
        }

        /// <summary>
        /// Retorna se a tarefa foi excluída
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        public bool TarefaExcluida(Tarefa entidade)
        {
            return (entidade != null && entidade.Status == StatusTarefa.Excluido);
        }
    }
}