namespace Quizz.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificationClassQuestion : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Questions", "Title", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Questions", "Title", c => c.String(maxLength: 20));
        }
    }
}
