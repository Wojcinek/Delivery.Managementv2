﻿// <auto-generated />
using Delivery.Management.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Delivery.Management.Persistence.Migrations
{
    [DbContext(typeof(DeliveryManagementDbContext))]
    [Migration("20230714093915_NewData")]
    partial class NewData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Delivery.Management.Domain.DeliveryAllocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Section")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Warehouse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DeliveryAllocations");

                    b.HasData(
                        new
                        {
                            Id = 101,
                            Section = "3",
                            Warehouse = "Standard"
                        },
                        new
                        {
                            Id = 102,
                            Section = "2",
                            Warehouse = "Express"
                        },
                        new
                        {
                            Id = 103,
                            Section = "5",
                            Warehouse = "Palette"
                        },
                        new
                        {
                            Id = 104,
                            Section = "14",
                            Warehouse = "International By Plane"
                        },
                        new
                        {
                            Id = 105,
                            Section = "45",
                            Warehouse = "International by Ship"
                        });
                });

            modelBuilder.Entity("Delivery.Management.Domain.DeliveryRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DeliveryAllocationId")
                        .HasColumnType("int");

                    b.Property<int>("DeliveryTypeId")
                        .HasColumnType("int");

                    b.Property<int>("HouseNumber")
                        .HasColumnType("int");

                    b.Property<string>("RequestComments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryAllocationId");

                    b.HasIndex("DeliveryTypeId");

                    b.ToTable("DeliveryRequests");
                });

            modelBuilder.Entity("Delivery.Management.Domain.DeliveryType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DeliveryTypes");

                    b.HasData(
                        new
                        {
                            Id = 1000,
                            Name = "Unloading"
                        },
                        new
                        {
                            Id = 1001,
                            Name = "Preparing"
                        },
                        new
                        {
                            Id = 1002,
                            Name = "Sent"
                        });
                });

            modelBuilder.Entity("Delivery.Management.Domain.DeliveryRequest", b =>
                {
                    b.HasOne("Delivery.Management.Domain.DeliveryAllocation", "DeliveryAllocation")
                        .WithMany()
                        .HasForeignKey("DeliveryAllocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Delivery.Management.Domain.DeliveryType", "DeliveryType")
                        .WithMany()
                        .HasForeignKey("DeliveryTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeliveryAllocation");

                    b.Navigation("DeliveryType");
                });
#pragma warning restore 612, 618
        }
    }
}