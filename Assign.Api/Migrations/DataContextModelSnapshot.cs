﻿// <auto-generated />
using Assign.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assign.Api.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Assign.Api.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PricePerSqM")
                        .HasColumnType("int");

                    b.HasKey("CityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Assign.Api.Models.CityExtras", b =>
                {
                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("ExtrasId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("CityId", "ExtrasId");

                    b.HasIndex("ExtrasId");

                    b.ToTable("CityExtras");
                });

            modelBuilder.Entity("Assign.Api.Models.Extras", b =>
                {
                    b.Property<int>("ExtrasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExtrasId"), 1L, 1);

                    b.Property<string>("ExtrasName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExtrasId");

                    b.ToTable("Extras");
                });

            modelBuilder.Entity("Assign.Api.Models.CityExtras", b =>
                {
                    b.HasOne("Assign.Api.Models.City", "City")
                        .WithMany("CityExtras")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assign.Api.Models.Extras", "Extras")
                        .WithMany("CityExtras")
                        .HasForeignKey("ExtrasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Extras");
                });

            modelBuilder.Entity("Assign.Api.Models.City", b =>
                {
                    b.Navigation("CityExtras");
                });

            modelBuilder.Entity("Assign.Api.Models.Extras", b =>
                {
                    b.Navigation("CityExtras");
                });
#pragma warning restore 612, 618
        }
    }
}
