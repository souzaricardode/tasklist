using System;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TaskList.DAL.Interfaces;
using TaskList.Model.Model;

namespace TaskList.DAL
{
    public abstract class RepositorioBase<T> : IRepositorio<T> where T : EntidadeBase
    {
        internal DbContext contexto;
        internal DbSet<T> dbSet;
        public DbTransaction Transacao { get { return this.contexto.Database.BeginTransaction().UnderlyingTransaction; } }

        protected RepositorioBase(TaskListContexto contexto)
        {
            if (contexto == null)
            {
                throw new ArgumentNullException(nameof(contexto));
            }

            this.contexto = contexto;

            dbSet = contexto.Set<T>();
        }

        public virtual IQueryable<T> ObterTodos()
        {
            return dbSet;
        }

        public virtual IQueryable<T> Obter(Expression<Func<T, bool>> predicado)
        {
            return ObterTodos().Where(predicado);
        }

        public virtual T BuscarPorId(params object[] key)
        {
            return dbSet.Find(key);
        }

        public virtual int Atualizar(T obj)
        {
            contexto.Entry(obj).State = EntityState.Modified;

            return contexto.SaveChanges();
        }

        public virtual int Adicionar(T obj)
        {
            dbSet.Add(obj);
            return contexto.SaveChanges();
        }

        public virtual void Remover(Expression<Func<T, bool>> predicado)
        {
            dbSet.Where(predicado).ToList().ForEach(del => dbSet.Remove(del));
        }

        public virtual void RemoverPorId(int id)
        {
            var entidadeParaRemover = dbSet.Find(id);
            Remover(entidadeParaRemover);
        }

        public virtual void Remover(T entity)
        {
            if (contexto.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }

            dbSet.Remove(entity);
            contexto.SaveChanges();
        }

        public virtual T ObterUnico(Expression<Func<T, bool>> predicado)
        {
            return dbSet.FirstOrDefault(predicado);
        }

        public virtual long Contar()
        {
            return dbSet.Count();
        }

        public virtual long Contar(Expression<Func<T, bool>> predicado)
        {
            return dbSet.Count(predicado);
        }

        public virtual Task<int> ContarAsync(Expression<Func<T, bool>> predicate)
        {
            return dbSet.CountAsync(predicate);
        }

        public virtual bool Any(Expression<Func<T, bool>> predicado)
        {
            return dbSet.Any(predicado);
        }
    }
}