﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OwnRestAPI.Data;

namespace OwnRestAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OwnRestAPI.Models.Driver", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Podiums")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Titles")
                        .HasColumnType("int");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.HasIndex("TeamName");

                    b.ToTable("Drivers");

                    b.HasData(
                        new
                        {
                            Name = "Sebastian Vettel",
                            Podiums = 5,
                            Points = 48,
                            TeamName = "Aston Martin",
                            Titles = 4,
                            Wins = 3
                        },
                        new
                        {
                            Name = "David Goliáš",
                            Podiums = 4,
                            Points = 52,
                            TeamName = "Ferrari",
                            Titles = 0,
                            Wins = 4
                        },
                        new
                        {
                            Name = "Adam Alkaz",
                            Podiums = 1,
                            Points = 27,
                            TeamName = "Aston Martin",
                            Titles = 0,
                            Wins = 0
                        },
                        new
                        {
                            Name = "Mick Schumacher",
                            Podiums = 0,
                            Points = 1,
                            TeamName = "Haas",
                            Titles = 0,
                            Wins = 0
                        });
                });

            modelBuilder.Entity("OwnRestAPI.Models.Team", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CarName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("TeamChampionships")
                        .HasColumnType("int");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Name = "Ferrari",
                            CarName = "SF1000",
                            Points = 64,
                            TeamChampionships = 10,
                            Wins = 5
                        },
                        new
                        {
                            Name = "Aston Martin",
                            CarName = "AM21",
                            Points = 75,
                            TeamChampionships = 0,
                            Wins = 3
                        },
                        new
                        {
                            Name = "Haas",
                            CarName = "Beast",
                            Points = 1,
                            TeamChampionships = 0,
                            Wins = 0
                        });
                });

            modelBuilder.Entity("OwnRestAPI.Models.Driver", b =>
                {
                    b.HasOne("OwnRestAPI.Models.Team", "Team")
                        .WithMany("Drivers")
                        .HasForeignKey("TeamName");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("OwnRestAPI.Models.Team", b =>
                {
                    b.Navigation("Drivers");
                });
#pragma warning restore 612, 618
        }
    }
}
