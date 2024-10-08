﻿// <auto-generated />
using System;
using DotNetCore_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DotNetCore_API.Migrations
{
    [DbContext(typeof(DotNetCoreDbcontext))]
    [Migration("20241001102008_Seeding Data for Difficulties and Regions")]
    partial class SeedingDataforDifficultiesandRegions
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DotNetCore_API.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ff373f74-3563-4ce0-82c0-99f0c065f738"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("ee6159ac-8734-473c-a145-16c2e9f89960"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("4f0ef889-2941-493d-8fe7-0a9db0a56ed2"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("DotNetCore_API.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9e4a3927-533c-48e2-8866-2f8f150df78e"),
                            Code = "MDU",
                            Name = "Madurai",
                            RegionImageUrl = "https://stock.adobe.com/in/images/sri-meenakshi-temple/47862528"
                        },
                        new
                        {
                            Id = new Guid("dedf0bf4-074e-48ea-a46e-a7ad48ee67cb"),
                            Code = "TPJ",
                            Name = "Tiruchirappalli",
                            RegionImageUrl = "https://stock.adobe.com/in/images/sri-meenakshi-temple/47862528"
                        },
                        new
                        {
                            Id = new Guid("c3b44ff9-3a3a-45e5-90cd-6345dfcc2d6c"),
                            Code = "DG",
                            Name = "Dindigul",
                            RegionImageUrl = "https://stock.adobe.com/in/images/sri-meenakshi-temple/47862528"
                        },
                        new
                        {
                            Id = new Guid("6637ea22-e7a9-465d-9a98-f5226b0bc3bd"),
                            Code = "TJ",
                            Name = "Thanjavur",
                            RegionImageUrl = "https://stock.adobe.com/in/images/sri-meenakshi-temple/47862528"
                        },
                        new
                        {
                            Id = new Guid("a6c98bc3-381f-4826-86c6-e4b7f0877876"),
                            Code = "CHN",
                            Name = "Chennai",
                            RegionImageUrl = "https://stock.adobe.com/in/images/sri-meenakshi-temple/47862528"
                        },
                        new
                        {
                            Id = new Guid("c0ef2d24-a848-41c6-8e87-4066faed8bbf"),
                            Code = "TLR",
                            Name = "Tiruvallur",
                            RegionImageUrl = "https://stock.adobe.com/in/images/sri-meenakshi-temple/47862528"
                        },
                        new
                        {
                            Id = new Guid("e293c64f-bb48-4165-8f51-51d974e774d2"),
                            Code = "RMM",
                            Name = "Rameswaram",
                            RegionImageUrl = "https://stock.adobe.com/in/images/sri-meenakshi-temple/47862528"
                        },
                        new
                        {
                            Id = new Guid("6b3066bb-856d-429c-b759-f11e7b1fe14f"),
                            Code = "GI",
                            Name = "Guduvancheri"
                        },
                        new
                        {
                            Id = new Guid("40070409-302c-4a4a-a43a-45a600381531"),
                            Code = "TN",
                            Name = "Tuticorin"
                        });
                });

            modelBuilder.Entity("DotNetCore_API.Models.Domain.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LengthInKm")
                        .HasColumnType("float");

                    b.Property<Guid>("MyProperty")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("DotNetCore_API.Models.Domain.Walk", b =>
                {
                    b.HasOne("DotNetCore_API.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DotNetCore_API.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
