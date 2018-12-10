namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
			Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'263d7ab0-f42a-4674-85d7-8dd1d76bff46', N'valeriaoshiro19@gmail.com', 0, N'AK/IXF3lcrn6eZQvJUTLLDE40yUQu5hWgIS9Gy6kaPGoLxYj7DWAY+rv0ElM63pnrg==', N'e2b42069-268b-4c4b-9aa6-a9d3bf036f4a', NULL, 0, 0, NULL, 1, 0, N'valeriaoshiro19@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4e01a949-b753-4b3d-87aa-6dc3ca68cd33', N'vkcao19@gmail.com', 0, N'AHjqErx7iuxoM4krI2W4vjfiDNyLuUTU6haIngDJip62wYZtapbrIY8SmaeUBS2qXQ==', N'51e84ca8-a443-45f1-8057-7a5689131711', NULL, 0, 0, NULL, 1, 0, N'vkcao19@gmail.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0e988b0f-b07a-4ef0-8c32-079035ee3b0a', N'CanManageMovie')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'263d7ab0-f42a-4674-85d7-8dd1d76bff46', N'0e988b0f-b07a-4ef0-8c32-079035ee3b0a')

");
        }
        
        public override void Down()
        {
        }
    }
}
