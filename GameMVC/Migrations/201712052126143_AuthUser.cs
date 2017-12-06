namespace GameMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuthUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator], [Email]) VALUES (N'd638fabd-21fa-4686-bf6a-7672422cb607', N'lucas1', N'AALyTlaXS0cIwCTXTUyM/H/bRZJ/mmHjSUIy+jxZ2HkoQVl+N9IL3TGGgxhWzHK+og==', N'cf5ff8ad-28c3-45ae-a06a-6faddf6d5700', N'ApplicationUser', N'lucas1@gmail.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7d1b8293-6e73-4235-9f9f-dead1c519acc', N'CanManageVideoGames')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a7d3e8d8-edff-4cc9-a9c6-be2e60f02e4e', N'CanManageComputers')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'fd2033d2-d16b-49c0-8672-e87d75d2fb80', N'CanManageCustomers')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'fe112f52-93eb-4a70-b9e1-93698b36278b', N'CanManageGames')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd638fabd-21fa-4686-bf6a-7672422cb607', N'7d1b8293-6e73-4235-9f9f-dead1c519acc')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd638fabd-21fa-4686-bf6a-7672422cb607', N'a7d3e8d8-edff-4cc9-a9c6-be2e60f02e4e')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd638fabd-21fa-4686-bf6a-7672422cb607', N'fd2033d2-d16b-49c0-8672-e87d75d2fb80')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd638fabd-21fa-4686-bf6a-7672422cb607', N'fe112f52-93eb-4a70-b9e1-93698b36278b')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
