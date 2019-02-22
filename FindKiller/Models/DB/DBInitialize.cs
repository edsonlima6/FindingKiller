using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindKiller.Models.DB
{
    public class DBInitialize : System.Data.Entity.DropCreateDatabaseIfModelChanges<ContextDB>
    {
        protected override void Seed(ContextDB context)
        {
           
        }
    }
}