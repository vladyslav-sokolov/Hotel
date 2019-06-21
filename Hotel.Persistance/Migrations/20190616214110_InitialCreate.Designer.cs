﻿// <auto-generated />
using System;
using Hotel.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hotel.Persistance.Migrations
{
    [DbContext(typeof(HotelDbContext))]
    [Migration("20190616214110_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("Hotel.Domain.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateTo");

                    b.Property<int?>("GuestId");

                    b.Property<int?>("ManagerId");

                    b.Property<int>("RoomId");

                    b.HasKey("Id");

                    b.HasIndex("GuestId");

                    b.HasIndex("ManagerId");

                    b.HasIndex("RoomId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Hotel.Domain.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Floor");

                    b.Property<int>("Number");

                    b.Property<int>("RoomTypeId");

                    b.HasKey("Id");

                    b.HasIndex("Number")
                        .IsUnique();

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Hotel.Domain.Models.RoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BedType")
                        .HasMaxLength(255);

                    b.Property<string>("Categories")
                        .HasMaxLength(255);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("Cost");

                    b.Property<string>("Facilities")
                        .HasMaxLength(255);

                    b.Property<string>("Image");

                    b.Property<int>("Size");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("RoomTypes");
                });

            modelBuilder.Entity("Hotel.Domain.Models.User", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("AdditionalInfo");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(255);

                    b.Property<string>("FirstName")
                        .HasMaxLength(255);

                    b.Property<string>("Image");

                    b.Property<string>("LastName")
                        .HasMaxLength(255);

                    b.Property<int>("UserType");

                    b.Property<string>("Username")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("Hotel.Domain.Models.Guest", b =>
                {
                    b.HasBaseType("Hotel.Domain.Models.User");

                    b.Property<DateTime>("RegisterDate");

                    b.HasDiscriminator().HasValue("Guest");
                });

            modelBuilder.Entity("Hotel.Domain.Models.Manager", b =>
                {
                    b.HasBaseType("Hotel.Domain.Models.User");

                    b.Property<int>("Salary");

                    b.HasDiscriminator().HasValue("Manager");
                });

            modelBuilder.Entity("Hotel.Domain.Models.Booking", b =>
                {
                    b.HasOne("Hotel.Domain.Models.Guest", "Guest")
                        .WithMany("Bookings")
                        .HasForeignKey("GuestId");

                    b.HasOne("Hotel.Domain.Models.Manager", "Manager")
                        .WithMany("Bookings")
                        .HasForeignKey("ManagerId");

                    b.HasOne("Hotel.Domain.Models.Room", "Room")
                        .WithMany("Bookings")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hotel.Domain.Models.Room", b =>
                {
                    b.HasOne("Hotel.Domain.Models.RoomType", "RoomType")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
