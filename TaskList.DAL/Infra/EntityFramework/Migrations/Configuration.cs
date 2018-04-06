using System.Data.Entity.Migrations;

namespace TaskList.DAL
{
    internal sealed class Configuration : DbMigrationsConfiguration<TaskListContexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
            MigrationsDirectory = @"Infra\EntityFramework\Migrations";
        }
    }
}
