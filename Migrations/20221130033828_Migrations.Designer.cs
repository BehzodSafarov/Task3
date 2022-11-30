﻿// <auto-generated />
using DotNet.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DotNet.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221130033828_Migrations")]
    partial class Migrations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true);

            modelBuilder.Entity("DotNet.Models.Attempt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("M")
                        .HasColumnType("INTEGER");

                    b.Property<int>("P")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Attempts");
                });

            modelBuilder.Entity("DotNet.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GamerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RandomNumber")
                        .HasColumnType("TEXT");

                    b.Property<int>("Step")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GamerId");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GamerId = 1,
                            RandomNumber = "3456",
                            Step = 7
                        });
                });

            modelBuilder.Entity("DotNet.Models.Gamer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Gamers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Behzod"
                        });
                });

            modelBuilder.Entity("DotNet.Models.Attempt", b =>
                {
                    b.HasOne("DotNet.Models.Game", "Game")
                        .WithMany("Attempts")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("DotNet.Models.Game", b =>
                {
                    b.HasOne("DotNet.Models.Gamer", "Gamer")
                        .WithMany("Games")
                        .HasForeignKey("GamerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gamer");
                });

            modelBuilder.Entity("DotNet.Models.Game", b =>
                {
                    b.Navigation("Attempts");
                });

            modelBuilder.Entity("DotNet.Models.Gamer", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
