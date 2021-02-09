namespace Quizz.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteAnswerQuestion : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Questions", "Answer");
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
            
            AddColumn("dbo.Questions", "Answer", c => c.String());
        }
    }
}
