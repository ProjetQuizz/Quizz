namespace Quizz.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifClassModelAnswerAndQuestion : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Answers", name: "Question_Id", newName: "QuestionId");
            RenameIndex(table: "dbo.Answers", name: "IX_Question_Id", newName: "IX_QuestionId");
            AddColumn("dbo.Answers", "QuestionObj", c => c.String());
            DropColumn("dbo.Answers", "Question");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Answers", "Question", c => c.String());
            DropColumn("dbo.Answers", "QuestionObj");
            RenameIndex(table: "dbo.Answers", name: "IX_QuestionId", newName: "IX_Question_Id");
            RenameColumn(table: "dbo.Answers", name: "QuestionId", newName: "Question_Id");
        }
    }
}
