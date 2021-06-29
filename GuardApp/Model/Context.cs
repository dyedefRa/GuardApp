using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardApp.Model
{
    public class Context : DbContext
    {

        public Context() : base("GuardApp")
        {

            //Database.SetInitializer(new DropCreateDatabaseAlways<Context>());
            //Database.Initialize(true);
            //Database.CreateIfNotExists();
            if (!Database.Exists())
            {
                Database.CreateIfNotExists();
            }
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
        }

        public DbSet<Guard> Guard { get; set; }
        public DbSet<GuardProgram> GuardPrograms { get; set; }
        public DbSet<Personal> Personals { get; set; }
        public DbSet<Rank> Ranks { get; set; }
    }



}
