namespace Quizz.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixChangeModelAndView : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "dateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "score", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "score");
            DropColumn("dbo.Users", "dateCreated");
        }
    }
}
