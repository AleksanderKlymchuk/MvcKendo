namespace PetHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PriceCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Spice = c.String(),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Prices");
        }
    }
}
