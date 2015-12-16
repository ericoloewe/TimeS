namespace TimeS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mudancas_no_tempo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tempi", "Tarefa_Id", "dbo.Tarefas");
            DropIndex("dbo.Tempi", new[] { "Tarefa_Id" });
            RenameColumn(table: "dbo.Tempi", name: "Author_Id", newName: "Autor_Id");
            RenameIndex(table: "dbo.Tempi", name: "IX_Author_Id", newName: "IX_Autor_Id");
            AlterColumn("dbo.Tempi", "Tarefa_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Tempi", "Tarefa_Id");
            AddForeignKey("dbo.Tempi", "Tarefa_Id", "dbo.Tarefas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tempi", "Tarefa_Id", "dbo.Tarefas");
            DropIndex("dbo.Tempi", new[] { "Tarefa_Id" });
            AlterColumn("dbo.Tempi", "Tarefa_Id", c => c.Int());
            RenameIndex(table: "dbo.Tempi", name: "IX_Autor_Id", newName: "IX_Author_Id");
            RenameColumn(table: "dbo.Tempi", name: "Autor_Id", newName: "Author_Id");
            CreateIndex("dbo.Tempi", "Tarefa_Id");
            AddForeignKey("dbo.Tempi", "Tarefa_Id", "dbo.Tarefas", "Id");
        }
    }
}
