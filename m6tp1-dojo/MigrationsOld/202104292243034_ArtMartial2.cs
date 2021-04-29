namespace m6tp1_dojo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArtMartial2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Samourais", new[] { "Arme_Id" });
            RenameColumn(table: "dbo.Armes", name: "Arme_Id", newName: "Samourai_Id");
            CreateIndex("dbo.Armes", "Samourai_Id");
            DropColumn("dbo.Samourais", "Arme_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Samourais", "Arme_Id", c => c.Long());
            DropIndex("dbo.Armes", new[] { "Samourai_Id" });
            RenameColumn(table: "dbo.Armes", name: "Samourai_Id", newName: "Arme_Id");
            CreateIndex("dbo.Samourais", "Arme_Id");
        }
    }
}
