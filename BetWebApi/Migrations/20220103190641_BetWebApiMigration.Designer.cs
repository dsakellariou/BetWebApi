﻿// <auto-generated />
using System;
using BetWebApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BetWebApi.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20220103190641_BetWebApiMigration")]
    partial class BetWebApiMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BetWebApi.Models.Match", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MatchDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("MatchTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("TeamA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamB")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("sport")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("BetWebApi.Models.MatchOdds", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MatchID")
                        .HasColumnType("int");

                    b.Property<double>("Odd")
                        .HasColumnType("float");

                    b.Property<string>("Specifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)")
                        .HasMaxLength(1);

                    b.HasKey("ID");

                    b.HasIndex("MatchID");

                    b.ToTable("MatchOdds");
                });

            modelBuilder.Entity("BetWebApi.Models.MatchOdds", b =>
                {
                    b.HasOne("BetWebApi.Models.Match", null)
                        .WithMany("MatchOdds")
                        .HasForeignKey("MatchID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}