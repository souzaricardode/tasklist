using System.Data.Entity.ModelConfiguration;

namespace TaskList.DAL.Infra.EntityFramework.Mapeamento
{
    public abstract class BaseMap<T> : EntityTypeConfiguration<T> where T : class
    {
    }
}
