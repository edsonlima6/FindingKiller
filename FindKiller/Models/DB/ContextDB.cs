using System;
using System.Data.Entity;

namespace FindKiller.Models.DB
{
    public class ContextDB : DbContext
    {
        public ContextDB() : base(@"Server=(localdb)\\MSSQLLocalDB;Initial Catalog=Tome;Trusted_Connection=True;\")
        {
        }



    }
}
