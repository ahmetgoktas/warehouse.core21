﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Warehouse.Api;

namespace Warehouse.Api.Migrations
{
    [DbContext(typeof(WarehouseContext))]
    [Migration("20190313140159_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065");

            modelBuilder.Entity("Warehouse.Api.WarehouseContext+Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("code");

                    b.Property<string>("coords");

                    b.Property<DateTime>("createdDate");

                    b.Property<int?>("createdUserId");

                    b.Property<DateTime>("lastUpdatedDate");

                    b.Property<int?>("lastUpdatedUserId");

                    b.Property<int>("locationTypeId");

                    b.Property<string>("name");

                    b.Property<string>("outline");

                    b.Property<int?>("parentLocationId");

                    b.HasKey("LocationId");

                    b.HasIndex("createdUserId");

                    b.HasIndex("lastUpdatedUserId");

                    b.HasIndex("locationTypeId");

                    b.HasIndex("parentLocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Warehouse.Api.WarehouseContext+LocationType", b =>
                {
                    b.Property<int>("LocationTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("code");

                    b.Property<DateTime>("createdDate");

                    b.Property<int?>("createdUserId");

                    b.Property<DateTime>("lastUpdatedDate");

                    b.Property<int?>("lastUpdatedUserId");

                    b.Property<string>("name");

                    b.HasKey("LocationTypeId");

                    b.HasIndex("createdUserId");

                    b.HasIndex("lastUpdatedUserId");

                    b.ToTable("LocationTypes");
                });

            modelBuilder.Entity("Warehouse.Api.WarehouseContext+MovementType", b =>
                {
                    b.Property<int>("MovementTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("code");

                    b.Property<DateTime>("createdDate");

                    b.Property<int?>("createdUserId");

                    b.Property<DateTime>("lastUpdatedDate");

                    b.Property<int?>("lastUpdatedUserId");

                    b.Property<string>("name");

                    b.HasKey("MovementTypeId");

                    b.HasIndex("createdUserId");

                    b.HasIndex("lastUpdatedUserId");

                    b.ToTable("MovementTypes");
                });

            modelBuilder.Entity("Warehouse.Api.WarehouseContext+Plant", b =>
                {
                    b.Property<int>("PlantId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("code");

                    b.Property<DateTime>("createdDate");

                    b.Property<int?>("createdUserId");

                    b.Property<DateTime>("lastUpdatedDate");

                    b.Property<int?>("lastUpdatedUserId");

                    b.Property<int>("locationId");

                    b.Property<string>("name");

                    b.Property<string>("plantCoords");

                    b.HasKey("PlantId");

                    b.HasIndex("createdUserId");

                    b.HasIndex("lastUpdatedUserId");

                    b.HasIndex("locationId");

                    b.ToTable("Plants");
                });

            modelBuilder.Entity("Warehouse.Api.WarehouseContext+Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("articlecode");

                    b.Property<string>("code");

                    b.Property<DateTime>("createdDate");

                    b.Property<int?>("createdUserId");

                    b.Property<string>("gtin");

                    b.Property<DateTime>("lastUpdatedDate");

                    b.Property<int?>("lastUpdatedUserId");

                    b.Property<string>("name");

                    b.HasKey("ProductId");

                    b.HasIndex("createdUserId");

                    b.HasIndex("lastUpdatedUserId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Warehouse.Api.WarehouseContext+Sequence", b =>
                {
                    b.Property<int>("SequenceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("entityname");

                    b.Property<int>("seq");

                    b.HasKey("SequenceId");

                    b.ToTable("Sequences");
                });

            modelBuilder.Entity("Warehouse.Api.WarehouseContext+Stock", b =>
                {
                    b.Property<int>("StockId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("barcode");

                    b.Property<DateTime>("createdDate");

                    b.Property<int?>("createdUserId");

                    b.Property<DateTime>("lastUpdatedDate");

                    b.Property<int?>("lastUpdatedUserId");

                    b.Property<int>("movementTypeId");

                    b.Property<int?>("parentStockId");

                    b.Property<int>("plantId");

                    b.Property<int>("productId");

                    b.Property<int>("quantity");

                    b.HasKey("StockId");

                    b.HasIndex("createdUserId");

                    b.HasIndex("lastUpdatedUserId");

                    b.HasIndex("movementTypeId");

                    b.HasIndex("parentStockId");

                    b.HasIndex("plantId");

                    b.HasIndex("productId");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("Warehouse.Api.WarehouseContext+User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("code");

                    b.Property<DateTime>("createdDate");

                    b.Property<DateTime>("lastUpdatedDate");

                    b.Property<string>("name");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Warehouse.Api.WarehouseContext+Location", b =>
                {
                    b.HasOne("Warehouse.Api.WarehouseContext+User", "createdUser")
                        .WithMany()
                        .HasForeignKey("createdUserId");

                    b.HasOne("Warehouse.Api.WarehouseContext+User", "lastUpdatedUser")
                        .WithMany()
                        .HasForeignKey("lastUpdatedUserId");

                    b.HasOne("Warehouse.Api.WarehouseContext+LocationType", "locationType")
                        .WithMany()
                        .HasForeignKey("locationTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Warehouse.Api.WarehouseContext+Location", "parentLocation")
                        .WithMany()
                        .HasForeignKey("parentLocationId");
                });

            modelBuilder.Entity("Warehouse.Api.WarehouseContext+LocationType", b =>
                {
                    b.HasOne("Warehouse.Api.WarehouseContext+User", "createdUser")
                        .WithMany()
                        .HasForeignKey("createdUserId");

                    b.HasOne("Warehouse.Api.WarehouseContext+User", "lastUpdatedUser")
                        .WithMany()
                        .HasForeignKey("lastUpdatedUserId");
                });

            modelBuilder.Entity("Warehouse.Api.WarehouseContext+MovementType", b =>
                {
                    b.HasOne("Warehouse.Api.WarehouseContext+User", "createdUser")
                        .WithMany()
                        .HasForeignKey("createdUserId");

                    b.HasOne("Warehouse.Api.WarehouseContext+User", "lastUpdatedUser")
                        .WithMany()
                        .HasForeignKey("lastUpdatedUserId");
                });

            modelBuilder.Entity("Warehouse.Api.WarehouseContext+Plant", b =>
                {
                    b.HasOne("Warehouse.Api.WarehouseContext+User", "createdUser")
                        .WithMany()
                        .HasForeignKey("createdUserId");

                    b.HasOne("Warehouse.Api.WarehouseContext+User", "lastUpdatedUser")
                        .WithMany()
                        .HasForeignKey("lastUpdatedUserId");

                    b.HasOne("Warehouse.Api.WarehouseContext+Location", "location")
                        .WithMany()
                        .HasForeignKey("locationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Warehouse.Api.WarehouseContext+Product", b =>
                {
                    b.HasOne("Warehouse.Api.WarehouseContext+User", "createdUser")
                        .WithMany()
                        .HasForeignKey("createdUserId");

                    b.HasOne("Warehouse.Api.WarehouseContext+User", "lastUpdatedUser")
                        .WithMany()
                        .HasForeignKey("lastUpdatedUserId");
                });

            modelBuilder.Entity("Warehouse.Api.WarehouseContext+Stock", b =>
                {
                    b.HasOne("Warehouse.Api.WarehouseContext+User", "createdUser")
                        .WithMany()
                        .HasForeignKey("createdUserId");

                    b.HasOne("Warehouse.Api.WarehouseContext+User", "lastUpdatedUser")
                        .WithMany()
                        .HasForeignKey("lastUpdatedUserId");

                    b.HasOne("Warehouse.Api.WarehouseContext+MovementType", "movementType")
                        .WithMany()
                        .HasForeignKey("movementTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Warehouse.Api.WarehouseContext+Stock", "parentStock")
                        .WithMany()
                        .HasForeignKey("parentStockId");

                    b.HasOne("Warehouse.Api.WarehouseContext+Plant", "plant")
                        .WithMany()
                        .HasForeignKey("plantId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Warehouse.Api.WarehouseContext+Product", "product")
                        .WithMany()
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
