namespace Quizz.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClassAnswerAndDbSet : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AnswerQuestions");
        }
    }
}
