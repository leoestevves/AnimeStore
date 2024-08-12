﻿// <auto-generated />
using System;
using AnimeStore.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AnimeStore.API.Data.Migrations
{
    [DbContext(typeof(AnimeStoreContext))]
    partial class AnimeStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("AnimeStore.API.Entities.AnimeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GenreId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NumberEpisodes")
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Animes");
                });

            modelBuilder.Entity("AnimeStore.API.Entities.GenreEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("AnimeStore.API.Entities.AnimeEntity", b =>
                {
                    b.HasOne("AnimeStore.API.Entities.GenreEntity", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });
#pragma warning restore 612, 618
        }
    }
}
