using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hometask_2._11.Entities;
using System.Security.Claims;
using System.Configuration;
using Hometask_2._11.EntityConfigs;
using Hometask_2._11.EntityConfigurations;

namespace Hometask_2._11
{
    public class ScheduleDbContext : DbContext
    {
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Client> Clients { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder
                .UseLazyLoadingProxies()
                .UseSqlServer("Data Source=.;Database=TestDb;Integrated Security=True;MultipleActiveResultSets=true");

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Schedule>()
                .HasOne<Client>(client => client.Client)
                .WithMany(schdule => schdule.Schedules)
                .HasForeignKey(schedule => schedule.ClientId);

            builder.ApplyConfiguration<Client>(new ClientConfiguration());
            builder.ApplyConfiguration<Schedule>(new ScheduleConfiguration());



        }
    }
}

