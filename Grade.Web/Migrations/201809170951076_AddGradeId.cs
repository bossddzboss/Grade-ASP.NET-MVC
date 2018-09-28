namespace Grade.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGradeId : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.GradeModels");
            AddColumn("dbo.GradeModels", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.GradeModels", "GradeName", c => c.String(nullable: false));
            AddPrimaryKey("dbo.GradeModels", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.GradeModels");
            AlterColumn("dbo.GradeModels", "GradeName", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.GradeModels", "Id");
            AddPrimaryKey("dbo.GradeModels", "GradeName");
        }
    }
}
