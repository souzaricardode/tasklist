using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TaskList.DAL
{
    /// <summary>
    /// Contexto para acesso ao banco de dados
    /// </summary>
    public class TaskListContexto : DbContext
    {
        public TaskListContexto()
            : base("name=DefaultConnection")
        {
            Database.SetInitializer<TaskListContexto>(new MigrateDatabaseToLatestVersion<TaskListContexto, Configuration>());

            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;

#if DEBUG
            Database.Log = EntityLog;
#endif
        }

        private void EntityLog(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConve‌​ntion>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Properties()
                .Where(p => p.Name.Equals("Id"))
                .Configure(p => p.IsKey());
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties()
                .Where(p => p.PropertyType == typeof(string))
                .Configure(p => p.HasMaxLength(250).IsUnicode());

            modelBuilder.Properties<DateTime>()
                .Configure(p => p.HasColumnType("datetime"));

            modelBuilder.Types().Configure(c => c.ToTable(c.ClrType.Name.ToUpper()));
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
