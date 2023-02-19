using Microsoft.EntityFrameworkCore;
using NWSInventaire.Server.Data;

namespace NWSInventaire.Server.Repository
{
    public class RepositoryBase
    {
        protected DataContext Context;

        public RepositoryBase(DataContext context)
        {
            Context = context;

            if (!DataContext.Migrated)
            {
                
                try
                {
                    Console.WriteLine("Start Migrate");
                    Context.Database.Migrate();
                    DataContext.Migrated = true;
                    Console.WriteLine("Migrate Finish");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Migrante Fail");
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
