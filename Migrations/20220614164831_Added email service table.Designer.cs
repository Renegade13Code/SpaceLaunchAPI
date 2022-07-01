﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpaceLaunchAPI.Data;

#nullable disable

namespace SpaceLaunchAPI.Migrations
{
    [DbContext(typeof(SpaceLaunchDbContext))]
    [Migration("20220614164831_Added email service table")]
    partial class Addedemailservicetable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SpaceLaunchAPI.Models.Domain.Astronaut", b =>
                {
                    b.Property<string>("AstronautId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Craft")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AstronautId");

                    b.ToTable("Astronauts");
                });

            modelBuilder.Entity("SpaceLaunchAPI.Models.Domain.Capsule", b =>
                {
                    b.Property<string>("CapsuleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("LandLandings")
                        .HasColumnType("int");

                    b.Property<string>("LaunchId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ReuseCount")
                        .HasColumnType("int");

                    b.Property<string>("Serial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WaterLandings")
                        .HasColumnType("int");

                    b.HasKey("CapsuleId");

                    b.HasIndex("LaunchId");

                    b.ToTable("Capsules");
                });

            modelBuilder.Entity("SpaceLaunchAPI.Models.Domain.EmailObserver", b =>
                {
                    b.Property<string>("EmailId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LaunchId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmailId");

                    b.ToTable("EmailRecipient");
                });

            modelBuilder.Entity("SpaceLaunchAPI.Models.Domain.Launch", b =>
                {
                    b.Property<string>("LaunchId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Failures")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LaunchpadId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RocketId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Success")
                        .HasColumnType("bit");

                    b.HasKey("LaunchId");

                    b.HasIndex("LaunchpadId");

                    b.HasIndex("RocketId");

                    b.ToTable("Launches");
                });

            modelBuilder.Entity("SpaceLaunchAPI.Models.Domain.LaunchPad", b =>
                {
                    b.Property<string>("LaunchpadId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<string>("Locality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TimeZone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LaunchpadId");

                    b.ToTable("LaunchPads");
                });

            modelBuilder.Entity("SpaceLaunchAPI.Models.Domain.Payload", b =>
                {
                    b.Property<string>("PayloadId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LaunchId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Manufacturers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("MassKg")
                        .HasColumnType("float");

                    b.Property<double?>("MassLb")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Orbit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReferenceSystem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Regime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Reused")
                        .HasColumnType("bit");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PayloadId");

                    b.HasIndex("LaunchId");

                    b.ToTable("PayLoads");
                });

            modelBuilder.Entity("SpaceLaunchAPI.Models.Domain.Rocket", b =>
                {
                    b.Property<string>("RocketId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Boosters")
                        .HasColumnType("int");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("CostPerLaunch")
                        .HasColumnType("float");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("DiameterFt")
                        .HasColumnType("float");

                    b.Property<double>("DiameterMt")
                        .HasColumnType("float");

                    b.Property<string>("Engines")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<double>("HeightFt")
                        .HasColumnType("float");

                    b.Property<double>("HeightMt")
                        .HasColumnType("float");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<double>("MassKg")
                        .HasColumnType("float");

                    b.Property<double>("MassLb")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stages")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RocketId");

                    b.ToTable("Rockets");
                });

            modelBuilder.Entity("SpaceLaunchAPI.Models.Domain.Capsule", b =>
                {
                    b.HasOne("SpaceLaunchAPI.Models.Domain.Launch", "LaunchModel")
                        .WithMany("Capsules")
                        .HasForeignKey("LaunchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LaunchModel");
                });

            modelBuilder.Entity("SpaceLaunchAPI.Models.Domain.Launch", b =>
                {
                    b.HasOne("SpaceLaunchAPI.Models.Domain.LaunchPad", "LaunchPadModel")
                        .WithMany()
                        .HasForeignKey("LaunchpadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpaceLaunchAPI.Models.Domain.Rocket", "RocketModel")
                        .WithMany()
                        .HasForeignKey("RocketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LaunchPadModel");

                    b.Navigation("RocketModel");
                });

            modelBuilder.Entity("SpaceLaunchAPI.Models.Domain.Payload", b =>
                {
                    b.HasOne("SpaceLaunchAPI.Models.Domain.Launch", "LaunchModel")
                        .WithMany("Payloads")
                        .HasForeignKey("LaunchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LaunchModel");
                });

            modelBuilder.Entity("SpaceLaunchAPI.Models.Domain.Launch", b =>
                {
                    b.Navigation("Capsules");

                    b.Navigation("Payloads");
                });
#pragma warning restore 612, 618
        }
    }
}
