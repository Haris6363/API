using AspNetCore.Identity.LiteDB.Data;
using LiteDB;
using Microsoft.Extensions.Options;

namespace Assignment.Data
{
    public class EventLiteDbContext : ILiteDbContext
    {
        public LiteDatabase LiteDatabase { get; set; }  
        public EventLiteDbContext(IOptions<LiteDbOptions> dbOptions)
        {
            var database= dbOptions.Value.EventDatabase;
            Console.WriteLine("Database is:"+" "+database);
            LiteDatabase = new LiteDatabase("LiteDbOptions");
        }
    }
    
}
