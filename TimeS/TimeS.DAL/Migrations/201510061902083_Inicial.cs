namespace TimeS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Atividades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 200),
                        Descricao = c.String(),
                        Tipo_Id = c.Int(nullable: false),
                        Criador_Id = c.String(maxLength: 128),
                        Responsavel_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.Criador_Id)
                .ForeignKey("dbo.Usuario", t => t.Responsavel_Id)
                .ForeignKey("dbo.TipoAtividades", t => t.Tipo_Id, cascadeDelete: true)
                .Index(t => t.Tipo_Id)
                .Index(t => t.Criador_Id)
                .Index(t => t.Responsavel_Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Nome = c.String(nullable: false),
                        Foto = c.Binary(),
                        ImageMimeType = c.String(),
                        Ativo = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.ClaimsUsuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.LoginsUsuario",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Usuario", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.RolesUsuario",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Usuario", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Tarefas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        Inicio = c.DateTime(),
                        Entrega = c.DateTime(),
                        Status = c.Int(),
                        Responsavel_Id = c.String(maxLength: 128),
                        Atividade_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.Responsavel_Id)
                .ForeignKey("dbo.Atividades", t => t.Atividade_Id)
                .Index(t => t.Responsavel_Id)
                .Index(t => t.Atividade_Id);
            
            CreateTable(
                "dbo.Tempi",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Horas = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Author_Id = c.String(maxLength: 128),
                        Tarefa_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.Author_Id)
                .ForeignKey("dbo.Tarefas", t => t.Tarefa_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.Tarefa_Id);
            
            CreateTable(
                "dbo.TipoAtividades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Descricao = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.ParticipantesAtividades",
                c => new
                    {
                        Usuario_Id = c.String(nullable: false, maxLength: 128),
                        Atividade_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Usuario_Id, t.Atividade_Id })
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id, cascadeDelete: true)
                .ForeignKey("dbo.Atividades", t => t.Atividade_Id, cascadeDelete: true)
                .Index(t => t.Usuario_Id)
                .Index(t => t.Atividade_Id);
            
            CreateTable(
                "dbo.SeguidoresTarefas",
                c => new
                    {
                        Tarefa_Id = c.Int(nullable: false),
                        Usuario_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Tarefa_Id, t.Usuario_Id })
                .ForeignKey("dbo.Tarefas", t => t.Tarefa_Id, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id, cascadeDelete: true)
                .Index(t => t.Tarefa_Id)
                .Index(t => t.Usuario_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RolesUsuario", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Atividades", "Tipo_Id", "dbo.TipoAtividades");
            DropForeignKey("dbo.Tarefas", "Atividade_Id", "dbo.Atividades");
            DropForeignKey("dbo.Atividades", "Responsavel_Id", "dbo.Usuario");
            DropForeignKey("dbo.Atividades", "Criador_Id", "dbo.Usuario");
            DropForeignKey("dbo.Tempi", "Tarefa_Id", "dbo.Tarefas");
            DropForeignKey("dbo.Tempi", "Author_Id", "dbo.Usuario");
            DropForeignKey("dbo.SeguidoresTarefas", "Usuario_Id", "dbo.Usuario");
            DropForeignKey("dbo.SeguidoresTarefas", "Tarefa_Id", "dbo.Tarefas");
            DropForeignKey("dbo.Tarefas", "Responsavel_Id", "dbo.Usuario");
            DropForeignKey("dbo.RolesUsuario", "UserId", "dbo.Usuario");
            DropForeignKey("dbo.LoginsUsuario", "UserId", "dbo.Usuario");
            DropForeignKey("dbo.ClaimsUsuario", "UserId", "dbo.Usuario");
            DropForeignKey("dbo.ParticipantesAtividades", "Atividade_Id", "dbo.Atividades");
            DropForeignKey("dbo.ParticipantesAtividades", "Usuario_Id", "dbo.Usuario");
            DropIndex("dbo.SeguidoresTarefas", new[] { "Usuario_Id" });
            DropIndex("dbo.SeguidoresTarefas", new[] { "Tarefa_Id" });
            DropIndex("dbo.ParticipantesAtividades", new[] { "Atividade_Id" });
            DropIndex("dbo.ParticipantesAtividades", new[] { "Usuario_Id" });
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropIndex("dbo.Tempi", new[] { "Tarefa_Id" });
            DropIndex("dbo.Tempi", new[] { "Author_Id" });
            DropIndex("dbo.Tarefas", new[] { "Atividade_Id" });
            DropIndex("dbo.Tarefas", new[] { "Responsavel_Id" });
            DropIndex("dbo.RolesUsuario", new[] { "RoleId" });
            DropIndex("dbo.RolesUsuario", new[] { "UserId" });
            DropIndex("dbo.LoginsUsuario", new[] { "UserId" });
            DropIndex("dbo.ClaimsUsuario", new[] { "UserId" });
            DropIndex("dbo.Usuario", "UserNameIndex");
            DropIndex("dbo.Atividades", new[] { "Responsavel_Id" });
            DropIndex("dbo.Atividades", new[] { "Criador_Id" });
            DropIndex("dbo.Atividades", new[] { "Tipo_Id" });
            DropTable("dbo.SeguidoresTarefas");
            DropTable("dbo.ParticipantesAtividades");
            DropTable("dbo.Roles");
            DropTable("dbo.TipoAtividades");
            DropTable("dbo.Tempi");
            DropTable("dbo.Tarefas");
            DropTable("dbo.RolesUsuario");
            DropTable("dbo.LoginsUsuario");
            DropTable("dbo.ClaimsUsuario");
            DropTable("dbo.Usuario");
            DropTable("dbo.Atividades");
        }
    }
}
