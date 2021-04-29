namespace m6tp1_dojo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArtMartial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Samourais", "Arme_Id", "dbo.Armes");
            DropIndex("dbo.Samourais", new[] { "Arme_Id" });
            DropPrimaryKey("dbo.Armes");
            DropPrimaryKey("dbo.Samourais");
            CreateTable(
                "dbo.ArtMartials",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SamouraiArtMartials",
                c => new
                    {
                        Samourai_Id = c.Long(nullable: false),
                        ArtMartial_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Samourai_Id, t.ArtMartial_Id })
                .ForeignKey("dbo.Samourais", t => t.Samourai_Id, cascadeDelete: true)
                .ForeignKey("dbo.ArtMartials", t => t.ArtMartial_Id, cascadeDelete: true)
                .Index(t => t.Samourai_Id)
                .Index(t => t.ArtMartial_Id);
            
            AlterColumn("dbo.Armes", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Samourais", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Samourais", "Arme_Id", c => c.Long());
            AddPrimaryKey("dbo.Armes", "Id");
            AddPrimaryKey("dbo.Samourais", "Id");
            CreateIndex("dbo.Samourais", "Arme_Id");
            AddForeignKey("dbo.Samourais", "Arme_Id", "dbo.Armes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Samourais", "Arme_Id", "dbo.Armes");
            DropForeignKey("dbo.SamouraiArtMartials", "ArtMartial_Id", "dbo.ArtMartials");
            DropForeignKey("dbo.SamouraiArtMartials", "Samourai_Id", "dbo.Samourais");
            DropIndex("dbo.SamouraiArtMartials", new[] { "ArtMartial_Id" });
            DropIndex("dbo.SamouraiArtMartials", new[] { "Samourai_Id" });
            DropIndex("dbo.Samourais", new[] { "Arme_Id" });
            DropPrimaryKey("dbo.Samourais");
            DropPrimaryKey("dbo.Armes");
            AlterColumn("dbo.Samourais", "Arme_Id", c => c.Int());
            AlterColumn("dbo.Samourais", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Armes", "Id", c => c.Int(nullable: false, identity: true));
            DropTable("dbo.SamouraiArtMartials");
            DropTable("dbo.ArtMartials");
            AddPrimaryKey("dbo.Samourais", "Id");
            AddPrimaryKey("dbo.Armes", "Id");
            CreateIndex("dbo.Samourais", "Arme_Id");
            AddForeignKey("dbo.Samourais", "Arme_Id", "dbo.Armes", "Id");
        }
    }
}
