using FluentMigrator;
using System;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000050)]
    public class Migration000050_AddedDefaultRoles : Migration
    {
        public override void Down()
        {
            Delete.FromTable("AspNetRoles").InSchema(Schemas.Dbo).AllRows();
        }

        public override void Up()
        {
            Insert.IntoTable("AspNetRoles").InSchema(Schemas.Dbo).Row(new { Id = Guid.NewGuid().ToString("N"), Name = "Admin", NormalizedName = "Admin" });
            Insert.IntoTable("AspNetRoles").InSchema(Schemas.Dbo).Row(new { Id = Guid.NewGuid().ToString("N"), Name = "LibraryAdmin", NormalizedName = "LibraryAdmin" });
            Insert.IntoTable("AspNetRoles").InSchema(Schemas.Dbo).Row(new { Id = Guid.NewGuid().ToString("N"), Name = "Writer", NormalizedName = "Writer" });
        }
    }
}