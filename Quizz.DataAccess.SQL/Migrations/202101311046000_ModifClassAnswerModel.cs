namespace Quizz.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifClassAnswerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Answers", "Title", c => c.String());
            DropColumn("dbo.Answers", "Question");
            DropTable("dbo.AnswerQuestions");
        }
        
        public override void Down()
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
            AlterColumn("dbo.Answers", "Title", c => c.String(nullable: false));
            DropColumn("dbo.Answers", "Name");
        }
    }
}
