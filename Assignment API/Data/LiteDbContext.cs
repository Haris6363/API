using AspNetCore.Identity.LiteDB.Data;
using Assignment.Models;
using LiteDB;
using Microsoft.Extensions.Options;

namespace Assignment.Data
{
    public class LiteDbContext : ILiteDbContext
    {
        public LiteDatabase LiteDatabase { get; }
        public LiteDbContext(IOptions<LiteDbOptions> options)
        {
            var databaseLocation = options.Value.DatabaseLocation;
            Console.WriteLine($"Database location: {databaseLocation}");
            LiteDatabase = new LiteDatabase("LiteDbOptions");
        }


    }
}
