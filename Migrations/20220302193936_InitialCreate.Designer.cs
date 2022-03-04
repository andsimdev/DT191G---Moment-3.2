﻿// <auto-generated />
using System;
using DT191G___Moment_3._2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DT191G___Moment_3._2.Migrations
{
    [DbContext(typeof(CdContext))]
    [Migration("20220302193936_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.2");

            modelBuilder.Entity("DT191G___Moment_3._2.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ArtistName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ArtistId");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("DT191G___Moment_3._2.Models.Borrow", b =>
                {
                    b.Property<int>("BorrowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BorrowDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("CdId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BorrowId");

                    b.HasIndex("CdId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Borrows");
                });

            modelBuilder.Entity("DT191G___Moment_3._2.Models.Cd", b =>
                {
                    b.Property<int>("CdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArtistId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CdName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("CdId");

                    b.HasIndex("ArtistId");

                    b.ToTable("Cds");
                });

            modelBuilder.Entity("DT191G___Moment_3._2.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("RegTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DT191G___Moment_3._2.Models.Borrow", b =>
                {
                    b.HasOne("DT191G___Moment_3._2.Models.Cd", "Cd")
                        .WithOne("Borrow")
                        .HasForeignKey("DT191G___Moment_3._2.Models.Borrow", "CdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DT191G___Moment_3._2.Models.User", "User")
                        .WithMany("Borrows")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cd");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DT191G___Moment_3._2.Models.Cd", b =>
                {
                    b.HasOne("DT191G___Moment_3._2.Models.Artist", "Artist")
                        .WithMany("Cds")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("DT191G___Moment_3._2.Models.Artist", b =>
                {
                    b.Navigation("Cds");
                });

            modelBuilder.Entity("DT191G___Moment_3._2.Models.Cd", b =>
                {
                    b.Navigation("Borrow");
                });

            modelBuilder.Entity("DT191G___Moment_3._2.Models.User", b =>
                {
                    b.Navigation("Borrows");
                });
#pragma warning restore 612, 618
        }
    }
}