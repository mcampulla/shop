namespace com.marcoelaura.shop.api.Migrations
{
    using com.marcoelaura.shop.api.DataObjects;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<com.marcoelaura.shop.api.Models.MobileServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(com.marcoelaura.shop.api.Models.MobileServiceContext context)
        {
            //context.TodoItems.AddOrUpdate(
            //  p => p.Id,
            //  new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Clean the car." },
            //  new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Read a book" }
            //);
        }
    }
}
