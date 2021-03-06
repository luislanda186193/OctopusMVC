﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Octopus.Data;

namespace Octopus.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200502180616_nueva")]
    partial class nueva
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

        

            modelBuilder.Entity("Octopus.Models.Carrier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarrierName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Carriers");
                });

            modelBuilder.Entity("Octopus.Models.Lada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FK_RegionId")
                        .HasColumnType("int");

                    b.Property<string>("LadaName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FK_RegionId");

                    b.ToTable("Ladas");
                });

            modelBuilder.Entity("Octopus.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FK_CarrierId")
                        .HasColumnType("int");

                    b.Property<string>("RegionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FK_CarrierId");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("Octopus.Models.WebServRegion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<int>("WebServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("WebServRegions");
                });

            modelBuilder.Entity("Octopus.Models.WebService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("URL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WebServRegionId")
                        .HasColumnType("int");

                    b.Property<string>("WebServiceName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("WebServRegionId");

                    b.ToTable("WebServices");
                });


            modelBuilder.Entity("Octopus.Models.Lada", b =>
                {
                    b.HasOne("Octopus.Models.Region", "FK_Region")
                        .WithMany()
                        .HasForeignKey("FK_RegionId");
                });

            modelBuilder.Entity("Octopus.Models.Region", b =>
                {
                    b.HasOne("Octopus.Models.Carrier", "FK_Carrier")
                        .WithMany()
                        .HasForeignKey("FK_CarrierId");
                });

            modelBuilder.Entity("Octopus.Models.WebServRegion", b =>
                {
                    b.HasOne("Octopus.Models.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Octopus.Models.WebService", b =>
                {
                    b.HasOne("Octopus.Models.WebServRegion", null)
                        .WithMany("WebService")
                        .HasForeignKey("WebServRegionId");
                });
#pragma warning restore 612, 618
        }
    }
}
