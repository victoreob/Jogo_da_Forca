namespace JogoForca.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DificuldadeNoUsuarioEPalavras : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "Dificuldade", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "Dificuldade");
        }
    }
}
