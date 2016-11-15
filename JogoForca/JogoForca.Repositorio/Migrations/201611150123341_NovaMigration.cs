namespace JogoForca.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NovaMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Usuario", "IdDificuldade_Id", "dbo.Dificuldade");
            DropIndex("dbo.Usuario", new[] { "IdDificuldade_Id" });
            AddColumn("dbo.Usuario", "Dificuldade", c => c.String());
            DropColumn("dbo.Usuario", "IdDificuldade_Id");
            DropTable("dbo.Dificuldade");
        }
        
        public override void Down()
        {
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
            DropColumn("dbo.Usuario", "Dificuldade");
            CreateIndex("dbo.Usuario", "IdDificuldade_Id");
            AddForeignKey("dbo.Usuario", "IdDificuldade_Id", "dbo.Dificuldade", "Id");
        }
    }
}
