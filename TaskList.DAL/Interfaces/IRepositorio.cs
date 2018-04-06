using System;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using TaskList.Model.Model;

namespace TaskList.DAL.Interfaces
{
    public interface IRepositorio<TEntity> where TEntity : EntidadeBase
    {
        /// <summary>
        /// Retornar uma nova transação do banco de dados
        /// </summary>
        DbTransaction Transacao { get; }

        /// <summary>
        /// Conta quantos registros existem na entidade
        /// </summary>
        /// <returns></returns>
        long Contar();

        /// <summary>
        /// Conta quantos registros existem na entidade de acordo a expressão
        /// </summary>
        /// <param name="predicado"></param>
        /// <returns></returns>
        long Contar(Expression<Func<TEntity, bool>> predicado);

        /// <summary>
        /// Obtém todos os registros da entidade
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> ObterTodos();

        /// <summary>
        /// Obtém todos os registros da entidade de acordo a expressão
        /// </summary>
        /// <param name="predicado"></param>
        /// <returns></returns>
        IQueryable<TEntity> Obter(Expression<Func<TEntity, bool>> predicado);

        /// <summary>
        /// Obtém uma entidade do banco de acordo a expressão
        /// </summary>
        /// <param name="predicado"></param>
        /// <returns></returns>
        TEntity ObterUnico(Expression<Func<TEntity, bool>> predicado);

        /// <summary>
        /// Busca uma entidade pelo id
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TEntity BuscarPorId(params object[] key);

        /// <summary>
        /// Atualiza uma entidade no banco de dados
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        int Atualizar(TEntity obj);

        /// <summary>
        /// Adiciona uma entidade no banco de dados
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        int Adicionar(TEntity obj);

        /// <summary>
        /// Remove uma ou várias entidades do banco de dados de acordo a expressão
        /// </summary>
        /// <param name="predicado"></param>
        void Remover(Expression<Func<TEntity, bool>> predicado);

        /// <summary>
        /// Remove uma entidade do banco de dados
        /// </summary>
        /// <param name="entity"></param>
        void Remover(TEntity entity);

        /// <summary>
        /// Verificar se existe qualquer entidade no banco de acordo a expressão
        /// </summary>
        /// <param name="predicado"></param>
        /// <returns></returns>
        bool Any(Expression<Func<TEntity, bool>> predicado);
    }
}
