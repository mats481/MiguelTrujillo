﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiguelTrujillo.Data;

#nullable disable

namespace MiguelTrujillo.Migrations
{
    [DbContext(typeof(PlayerContext))]
    [Migration("20230609141806_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MiguelTrujillo.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("MiguelTrujillo.Models.RegisterCleanAndJerk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId")
                        .IsUnique();

                    b.ToTable("RegisterCleanAndJerk");
                });

            modelBuilder.Entity("MiguelTrujillo.Models.RegisterSnatch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId")
                        .IsUnique();

                    b.ToTable("RegisterSnatch");
                });

            modelBuilder.Entity("MiguelTrujillo.Models.RegisterCleanAndJerk", b =>
                {
                    b.HasOne("MiguelTrujillo.Models.Player", "Player")
                        .WithOne("CleanAndJerkRecord")
                        .HasForeignKey("MiguelTrujillo.Models.RegisterCleanAndJerk", "PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("MiguelTrujillo.Models.RegisterSnatch", b =>
                {
                    b.HasOne("MiguelTrujillo.Models.Player", "Player")
                        .WithOne("SnatchRecord")
                        .HasForeignKey("MiguelTrujillo.Models.RegisterSnatch", "PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("MiguelTrujillo.Models.Player", b =>
                {
                    b.Navigation("CleanAndJerkRecord")
                        .IsRequired();

                    b.Navigation("SnatchRecord")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}