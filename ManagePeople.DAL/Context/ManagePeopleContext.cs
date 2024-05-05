using ManagePeople.DAL.Configuration;
using ManagePeople.Domain;
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

        public ManagePeopleContext(DbContextOptions options) : base(options) 
        {
           
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.EnableSensitiveDataLogging();
        //}

        //Seeders
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //If you want to configure your table into DB:
            //modelBuilder.ApplyConfiguration(new PersonConfiguration());

            modelBuilder.Entity<Person>().HasData(DataSeeders.InitPeople());
        }
    }
}
