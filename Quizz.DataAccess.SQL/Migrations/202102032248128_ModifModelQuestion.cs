namespace Quizz.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifModelQuestion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "Answer", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "Answer");
        }
    }
}
