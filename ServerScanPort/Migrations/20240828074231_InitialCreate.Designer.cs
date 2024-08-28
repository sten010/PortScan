﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ServerScanPort.Data;

#nullable disable

namespace ServerScanPort.Migrations
{
    [DbContext(typeof(ScanPortContext))]
    [Migration("20240828074231_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ServerScanPort.Data.Scaning", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateScan")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("IpAdress")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Scanings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateScan = new DateTime(2024, 8, 28, 7, 42, 31, 260, DateTimeKind.Utc).AddTicks(3690),
                            IpAdress = "123.123.123.123"
                        },
                        new
                        {
                            Id = 2,
                            DateScan = new DateTime(2024, 8, 28, 7, 42, 31, 260, DateTimeKind.Utc).AddTicks(3728),
                            IpAdress = "223.123.123.123"
                        },
                        new
                        {
                            Id = 3,
                            DateScan = new DateTime(2024, 8, 28, 7, 42, 31, 260, DateTimeKind.Utc).AddTicks(3729),
                            IpAdress = "323.123.123.123"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
