﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleProject.Db;

#nullable disable

namespace SimpleProject.Migrations
{
    [DbContext(typeof(SimpleProjectDbContext))]
    partial class SimpleProjectDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SimpleProject.Db.Entities.Bet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<decimal>("Multiplier")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("Result")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Bet");
                });

            modelBuilder.Entity("SimpleProject.Db.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("FirstWinnerMultiplier")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("SecondWinnerMultiplier")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("SimpleProject.Db.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(10,2)")
                        .HasDefaultValue(1000);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("SimpleProject.Db.Entities.Bet", b =>
                {
                    b.HasOne("SimpleProject.Db.Entities.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SimpleProject.Db.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}