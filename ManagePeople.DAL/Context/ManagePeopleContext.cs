using ManagePeople.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePeople.DAL.Context
{
    public class ManagePeopleContext : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public ManagePeopleContext(DbContextOptions options) : base(options) { }

        //Seeders
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>().HasData(DataSeeders.InitPeople());
        }
    }
}
