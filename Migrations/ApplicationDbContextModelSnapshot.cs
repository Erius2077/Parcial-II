﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pasteleria.Data;

#nullable disable

namespace Pasteleria.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Pasteleria.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("Pasteleria.Models.ReservationStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ReservationId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.ToTable("ReservationStatus");
                });

            modelBuilder.Entity("Pasteleria.Models.Calendary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ReservationId")
                        .HasColumnType("int");

                    b.Property<int?>("ReservationId1")
                        .HasColumnType("int");

                    b.Property<int?>("ReservationId2")
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.HasIndex("ReservationId1");

                    b.HasIndex("ReservationId2");

                    b.ToTable("Calendary");
                });

            modelBuilder.Entity("Pasteleria.Models.Cake", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("ReservationId")
                        .HasColumnType("int");

                    b.Property<int?>("ReservationId1")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.HasIndex("ReservationId1");

                    b.ToTable("Cake");
                });

            modelBuilder.Entity("Pasteleria.Models.CakeTime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CalendaryId")
                        .HasColumnType("int");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CalendaryId");

                    b.ToTable("CakeTime");
                });

            modelBuilder.Entity("Pasteleria.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ReservationId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastNames")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CalendaryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.HasIndex("CalendaryId");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Pasteleria.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Pasteleria.Models.ReservationStatus", b =>
                {
                    b.HasOne("Pasteleria.Models.Reservation", null)
                        .WithMany("Status")
                        .HasForeignKey("ReservationId");
                });

            modelBuilder.Entity("Pasteleria.Models.Calendary", b =>
                {
                    b.HasOne("Pasteleria.Models.Reservation", null)
                        .WithMany("Date")
                        .HasForeignKey("ReservationId");

                    b.HasOne("Pasteleria.Models.Reservation", null)
                        .WithMany("Cake")
                        .HasForeignKey("ReservationId1");

                    b.HasOne("Pasteleria.Models.Reservation", null)
                        .WithMany("Time")
                        .HasForeignKey("ReservationId2");
                });

            modelBuilder.Entity("Pasteleria.Models.Treatment", b =>
                {
                    b.HasOne("Pasteleria.Models.Reservation", null)
                        .WithMany("Name")
                        .HasForeignKey("ReservationId");

                    b.HasOne("Pasteleria.Models.Reservation", null)
                        .WithMany("Price")
                        .HasForeignKey("ReservationId1");
                });

            modelBuilder.Entity("Spa.Models.CakeTime", b =>
                {
                    b.HasOne("Pasteleria.Models.Calendary", null)
                        .WithMany("Time")
                        .HasForeignKey("CalendaryId");
                });

            modelBuilder.Entity("Pasteleria.Models.Client", b =>
                {
                    b.HasOne("Pasteleria.Models.Reservation", null)
                        .WithMany("Client")
                        .HasForeignKey("ReservationId");

                    b.HasOne("Pasteleria.Models.Client", null)
                        .WithMany("User")
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("Pasteleria.Models.UserRole", b =>
                {
                    b.HasOne("Pasteleria.Models.Client", null)
                        .WithMany("Roles")
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("Pasteleria.Models.Reservation", b =>
                {
                    b.Navigation("Date");

                    b.Navigation("Cake");

                    b.Navigation("Name");

                    b.Navigation("Price");

                    b.Navigation("Status");

                    b.Navigation("Time");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Pasteleria.Models.Calendary", b =>
                {
                    b.Navigation("Time");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Pasteleria.Models.Client", b =>
                {
                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
