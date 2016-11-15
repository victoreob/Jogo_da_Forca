namespace JogoForca.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jogada",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Dificuldade = c.String(),
                        Pontos = c.Int(nullable: false),
                        UsuarioRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioRefId, cascadeDelete: false)
                .Index(t => t.UsuarioRefId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Pontuacao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Palavra",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jogada", "UsuarioRefId", "dbo.Usuario");
            DropIndex("dbo.Jogada", new[] { "UsuarioRefId" });
            DropTable("dbo.Palavra");
            DropTable("dbo.Usuario");
            DropTable("dbo.Jogada");
        }
    }
}
