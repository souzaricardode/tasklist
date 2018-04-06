namespace TaskList.DAL
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tarefa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 250, unicode: false),
                        Status = c.Int(nullable: false),
                        DataCriacao = c.DateTime(),
                        DataAlteracao = c.DateTime(),
                        DataConclusao = c.DateTime(),
                        DataExclusao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tarefa");
        }
    }
}
