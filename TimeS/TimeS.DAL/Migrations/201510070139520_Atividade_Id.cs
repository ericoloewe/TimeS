namespace TimeS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Atividade_Id : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tarefas", "Atividade_Id", "dbo.Atividades");
            DropIndex("dbo.Tarefas", new[] { "Atividade_Id" });
            AlterColumn("dbo.Tarefas", "Atividade_Id", c => c.Int(nullable: true));
            CreateIndex("dbo.Tarefas", "Atividade_Id");
            AddForeignKey("dbo.Tarefas", "Atividade_Id", "dbo.Atividades", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tarefas", "Atividade_Id", "dbo.Atividades");
            DropIndex("dbo.Tarefas", new[] { "Atividade_Id" });
            AlterColumn("dbo.Tarefas", "Atividade_Id", c => c.Int());
            CreateIndex("dbo.Tarefas", "Atividade_Id");
            AddForeignKey("dbo.Tarefas", "Atividade_Id", "dbo.Atividades", "Id");
        }
    }
}
