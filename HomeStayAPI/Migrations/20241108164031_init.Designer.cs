﻿// <auto-generated />
using System;
using HomeStayAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HomeStayAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241108164031_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("HomeStayAPI.Models.Booking", b =>
                {
                    b.Property<string>("BoookingId")
                        .HasColumnType("TEXT");

                    b.Property<string>("BookingDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("BookingName")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoomId")
                        .HasColumnType("TEXT");

                    b.HasKey("BoookingId");

                    b.HasIndex("RoomId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("HomeStayAPI.Models.Room", b =>
                {
                    b.Property<string>("RoomId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoomName")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("RoomPrice")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoomType")
                        .HasColumnType("TEXT");

                    b.HasKey("RoomId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("HomeStayAPI.Models.RoomAvailability", b =>
                {
                    b.Property<string>("RoomAvailabilityId")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("Availability")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoomId")
                        .HasColumnType("TEXT");

                    b.HasKey("RoomAvailabilityId");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomAvailabilities");
                });

            modelBuilder.Entity("HomeStayAPI.Models.Booking", b =>
                {
                    b.HasOne("HomeStayAPI.Models.Room", "Room")
                        .WithMany("Bookings")
                        .HasForeignKey("RoomId");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HomeStayAPI.Models.RoomAvailability", b =>
                {
                    b.HasOne("HomeStayAPI.Models.Room", "Room")
                        .WithMany("RoomAvailabilities")
                        .HasForeignKey("RoomId");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HomeStayAPI.Models.Room", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("RoomAvailabilities");
                });
#pragma warning restore 612, 618
        }
    }
}
