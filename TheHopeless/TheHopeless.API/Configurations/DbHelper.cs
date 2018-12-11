using Microsoft.EntityFrameworkCore;
using TheHopeless.API.Database;

namespace TheHopeless.API.Configurations
{
    public class DbHelper
    {
        public static void Initialize(EshopDbContext context)
        {
            context.Database.Migrate();
        }
    }

}
