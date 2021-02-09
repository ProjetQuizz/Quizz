namespace Quizz.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifClassAnswerAndFix : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnswerQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Answers", "Question", c => c.String());
            DropColumn("dbo.Answers", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Answers", "Title", c => c.String());
            DropColumn("dbo.Answers", "Question");
            DropTable("dbo.AnswerQuestions");
        }
    }
}
