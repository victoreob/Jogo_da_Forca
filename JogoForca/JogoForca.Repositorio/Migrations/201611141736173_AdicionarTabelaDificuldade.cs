namespace JogoForca.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionarTabelaDificuldade : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Palavras", newName: "Palavra");
            CreateTable(
                "dbo.Dificuldade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        QuantidadeDeErros = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Usuario", "IdDificuldade_Id", c => c.Int());
            CreateIndex("dbo.Usuario", "IdDificuldade_Id");
            AddForeignKey("dbo.Usuario", "IdDificuldade_Id", "dbo.Dificuldade", "Id");
            DropColumn("dbo.Usuario", "Dificuldade");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuario", "Dificuldade", c => c.String());
            DropForeignKey("dbo.Usuario", "IdDificuldade_Id", "dbo.Dificuldade");
            DropIndex("dbo.Usuario", new[] { "IdDificuldade_Id" });
            DropColumn("dbo.Usuario", "IdDificuldade_Id");
            DropTable("dbo.Dificuldade");
            RenameTable(name: "dbo.Palavra", newName: "Palavras");
        }
    }
}
