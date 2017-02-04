namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _02Jan2017_Default : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        NumStudent = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        ClassID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Classes", t => t.ClassID, cascadeDelete: true)
                .Index(t => t.ClassID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "ClassID", "dbo.Classes");
            DropIndex("dbo.Students", new[] { "ClassID" });
            DropTable("dbo.Students");
            DropTable("dbo.Classes");
        }
    }
}
