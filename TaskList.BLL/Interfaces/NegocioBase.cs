using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TaskList.DAL.Interfaces;
using TaskList.Model.Model;

namespace TaskList.BLL.Interfaces
{
    public class NegocioBase<T> : INegocio<T> where T : EntidadeBase
    {
        protected readonly IRepositorio<T> repositorio;

        public NegocioBase(IRepositorio<T> repositorio)
        {
            this.repositorio = repositorio;
        }

        /// <summary>
        /// Adiciona uma nova entidade no banco
        /// </summary>
        /// <param name="entidade"></param>
        public virtual void Adicionar(T entidade)
        {
            entidade.DataCriacao = DateTime.Now;
            repositorio.Adicionar(entidade);
        }

        /// <summary>
        /// Atualiza uma entidade no banco de dados
        /// </summary>
        /// <param name="entidade"></param>
        public virtual void Atualizar(T entidade)
        {
            entidade.DataAlteracao = DateTime.Now;
            repositorio.Atualizar(entidade);
        }

        /// <summary>
        /// Remove uma entidade do banco
        /// </summary>
        /// <param name="entidade"></param>
        public virtual void Remover(T entidade)
        {
            repositorio.Remover(entidade);
        }

        /// <summary>
        /// Busca uma entidade por id
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public T BuscarPorId(params object[] key)
        {
            return repositorio.BuscarPorId(key);
        }

        /// <summary>
        /// Conta quantos registros existem no banco
        /// </summary>
        /// <returns></returns>
        public long Contar()
        {
            return repositorio.Contar();
        }

        /// <summary>
        /// Conta quantos registros existem no banco a partir de uma expressão
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public long Contar(Expression<Func<T, bool>> predicate)
        {
            return repositorio.Contar(predicate);
        }

        /// <summary>
        /// Obtém todos as entidades do banco de dados
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> ObterTodos()
        {
            return repositorio.ObterTodos();
        }

        /// <summary>
        /// Obtem uma únidade entidade do banco de acordo a expressão
        /// </summary>
        /// <param name="predicado"></param>
        /// <returns></returns>
        public T ObterUnico(Expression<Func<T, bool>> predicado)
        {
            return repositorio.ObterUnico(predicado);
        }

        /// <summary>
        /// Obtem uma lista de entidades do banco de acordo a expressão
        /// </summary>
        /// <param name="predicado"></param>
        /// <returns></returns>
        public IEnumerable<T> Obter(Expression<Func<T, bool>> predicado)
        {
            return repositorio.Obter(predicado);
        }

        /// <summary>
        /// Verificar se existe alguma entidade com a expressão informada
        /// </summary>
        /// <param name="predicado"></param>
        /// <returns></returns>
        public bool Any(Expression<Func<T, bool>> predicado)
        {
            return repositorio.Any(predicado);
        }
    }
}
