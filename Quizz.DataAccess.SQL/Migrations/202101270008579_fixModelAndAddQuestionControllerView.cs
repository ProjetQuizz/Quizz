namespace Quizz.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixModelAndAddQuestionControllerView : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestionCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Questions", "Category", c => c.String());
            AlterColumn("dbo.Answers", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Questions", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.Questions", "Survey");
            DropColumn("dbo.Surveys", "Timer");
            DropColumn("dbo.Surveys", "Score");
            DropColumn("dbo.Surveys", "Category");
            DropTable("dbo.Categories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Surveys", "Category", c => c.String());
            AddColumn("dbo.Surveys", "Score", c => c.Int(nullable: false));
            AddColumn("dbo.Surveys", "Timer", c => c.DateTime(nullable: false));
            AddColumn("dbo.Questions", "Survey", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "LastName", c => c.String(maxLength: 20));
            AlterColumn("dbo.Users", "FirstName", c => c.String(maxLength: 20));
            AlterColumn("dbo.Questions", "Title", c => c.String());
            AlterColumn("dbo.Answers", "Title", c => c.String());
            DropColumn("dbo.Questions", "Category");
            DropTable("dbo.QuestionCategories");
        }
    }
}
