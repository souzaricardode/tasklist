using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TaskList.Model.Model;

namespace TaskList.BLL.Interfaces
{
    public interface INegocio<T> where T : EntidadeBase
    {
        /// <summary>
        /// Adicionar entidade na base
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        void Adicionar(T entidade);

        /// <summary>
        /// Remover entidade da base
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        void Remover(T entidade);

        /// <summary>
        /// Atualizar entidade na base
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        void Atualizar(T entidade);

        /// <summary>
        /// Obter todos os registros da entidade
        /// </summary>
        /// <returns></returns>
        IQueryable<T> ObterTodos();

        /// <summary>
        /// Retorna registros da entidade, conforme filtro escolhido
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IEnumerable<T> Obter(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Retorna entidade, conforme filtro escolhido
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        T ObterUnico(Expression<Func<T, bool>> expression);
    }
}
