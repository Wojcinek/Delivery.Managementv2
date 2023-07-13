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
    [Migration("20230713165150_TypesCorrection")]
    partial class TypesCorrection
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
                            Id = 1,
                            Section = "1",
                            Warehouse = "Warehouse 1"
                        },
                        new
                        {
                            Id = 2,
                            Section = "2",
                            Warehouse = "Warehouse 1"
                        },
                        new
                        {
                            Id = 3,
                            Section = "3",
                            Warehouse = "Warehouse 1"
                        },
                        new
                        {
                            Id = 4,
                            Section = "1",
                            Warehouse = "Warehouse 2"
                        },
                        new
                        {
                            Id = 5,
                            Section = "2",
                            Warehouse = "Warehouse 2"
                        },
                        new
                        {
                            Id = 6,
                            Section = "3",
                            Warehouse = "Warehouse 2"
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
