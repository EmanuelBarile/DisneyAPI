﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(DisneyContext))]
    [Migration("20230124025352_Initial Commit")]
    partial class InitialCommit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.Property<int>("CharactersId_Character")
                        .HasColumnType("int");

                    b.Property<int>("MoviesId_Movie")
                        .HasColumnType("int");

                    b.HasKey("CharactersId_Character", "MoviesId_Movie");

                    b.HasIndex("MoviesId_Movie");

                    b.ToTable("CharacterMovie");
                });

            modelBuilder.Entity("DataAccess.Models.Character", b =>
                {
                    b.Property<int>("Id_Character")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Character"), 1L, 1);

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("History")
                        .HasColumnType("VARCHAR(500)");

                    b.Property<string>("Image_Character")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int?>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id_Character");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("DataAccess.Models.Genre", b =>
                {
                    b.Property<int>("Id_Genre")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Genre"), 1L, 1);

                    b.Property<string>("Image_Genre")
                        .IsRequired()
                        .HasColumnType("VARCHAR(25)");

                    b.HasKey("Id_Genre");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("DataAccess.Models.Movie", b =>
                {
                    b.Property<int>("Id_Movie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Movie"), 1L, 1);

                    b.Property<DateTime>("Creation_Date")
                        .HasColumnType("DATE");

                    b.Property<int>("Genre_Id")
                        .HasColumnType("int");

                    b.Property<string>("Image_Movie")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id_Movie");

                    b.HasIndex("Genre_Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.HasOne("DataAccess.Models.Character", null)
                        .WithMany()
                        .HasForeignKey("CharactersId_Character")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId_Movie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccess.Models.Movie", b =>
                {
                    b.HasOne("DataAccess.Models.Genre", "Genre")
                        .WithMany("Movies")
                        .HasForeignKey("Genre_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("DataAccess.Models.Genre", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}