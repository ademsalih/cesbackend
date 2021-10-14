using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Reflection;
using TelstarLogistics.DAL.Classes;

namespace TelstarLogistics.DAL
{
    public class TelstarLogisticsContext : DbContext 
    {
        public DbSet<Employee> Persons { get; set; }
        private readonly Stack<ValueTuple<string, IEnumerable<SqlParameter>>> _sqlCommands = new Stack<ValueTuple<string, IEnumerable<SqlParameter>>>();

        public TelstarLogisticsContext() : base("name=TLDB")
        {
            Database.SetInitializer<TelstarLogisticsContext>(null);
            this.Database.CommandTimeout = 60;

            Database.SetInitializer<TelstarLogisticsContext>(new CreateDatabaseIfNotExists<TelstarLogisticsContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));

            base.OnModelCreating(modelBuilder);
        }
        
    }
}