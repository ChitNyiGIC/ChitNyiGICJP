using CRUDWithMysqlAndAspNetCoreMVC.Data;
using System;
using System.Linq;

namespace ContosoUniversity.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MyDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Person.
            if (context.Person.Any())
            {
                return;   // DB has been seeded
            }

        }
    }
}