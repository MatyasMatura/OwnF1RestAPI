using Microsoft.EntityFrameworkCore;
using OwnRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OwnRestAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Driver>().HasData(new Driver { Name = "Sebastian Vettel", Podiums = 5, Points = 48, TeamName = "Aston Martin", Titles = 4, Wins = 3 });
            modelBuilder.Entity<Driver>().HasData(new Driver { Name = "David Goliáš", Podiums = 4, Points = 52, TeamName = "Ferrari", Titles = 0, Wins = 4 });
            modelBuilder.Entity<Driver>().HasData(new Driver { Name = "Adam Alkaz", Podiums = 1, Points = 27, TeamName = "Aston Martin", Titles = 0, Wins = 0 });
            modelBuilder.Entity<Driver>().HasData(new Driver { Name = "Mick Schumacher", Podiums = 0, Points = 1, TeamName = "Haas", Titles = 0, Wins = 0 });

            modelBuilder.Entity<Team>().HasData(new Team { Name = "Ferrari", CarName = "SF1000", Points = 64, TeamChampionships = 10, Wins = 5 });
            modelBuilder.Entity<Team>().HasData(new Team { Name = "Aston Martin", CarName = "AM21", Points = 75, TeamChampionships = 0, Wins = 3 });
            modelBuilder.Entity<Team>().HasData(new Team { Name = "Haas", CarName = "Beast", Points = 1, TeamChampionships = 0, Wins = 0 });
        }
    }
}
