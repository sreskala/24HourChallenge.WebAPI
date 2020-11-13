namespace _24HourChallenge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedVirtuals : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comment", "PostId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comment", "PostId");
            CreateIndex("dbo.Like", "PostId");
            CreateIndex("dbo.Reply", "CommentId");
            AddForeignKey("dbo.Comment", "PostId", "dbo.Post", "PostId", cascadeDelete: true);
            AddForeignKey("dbo.Like", "PostId", "dbo.Post", "PostId", cascadeDelete: true);
            AddForeignKey("dbo.Reply", "CommentId", "dbo.Comment", "CommentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reply", "CommentId", "dbo.Comment");
            DropForeignKey("dbo.Like", "PostId", "dbo.Post");
            DropForeignKey("dbo.Comment", "PostId", "dbo.Post");
            DropIndex("dbo.Reply", new[] { "CommentId" });
            DropIndex("dbo.Like", new[] { "PostId" });
            DropIndex("dbo.Comment", new[] { "PostId" });
            AlterColumn("dbo.Comment", "PostId", c => c.Int());
        }
    }
}
