﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NWSInventaire.Server.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NWSInventaire.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230219012023_AddMaterialCategorie01")]
    partial class AddMaterialCategorie01
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NWSInventaire.Shared.Models.Material", b =>
                {
                    b.Property<int>("MaterialId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("EndLend")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("LastReminder")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MaterialDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MaterialName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("StartLend")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("StudentId")
                        .HasColumnType("integer");

                    b.HasKey("MaterialId");

                    b.HasIndex("StudentId");

                    b.ToTable("materials");
                });

            modelBuilder.Entity("NWSInventaire.Shared.Models.MaterialCategorie", b =>
                {
                    b.Property<int>("MaterialCategorieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MaterialCategorieId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("MaterialCategorieId");

                    b.ToTable("materialCategories");
                });

            modelBuilder.Entity("NWSInventaire.Shared.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StudentId"));

                    b.Property<string>("StudentFirstName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("StudentLastName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("StudentMail")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("StudentId");

                    b.ToTable("students");
                });

            modelBuilder.Entity("NWSInventaire.Shared.Models.Material", b =>
                {
                    b.HasOne("NWSInventaire.Shared.Models.MaterialCategorie", "MaterialCategorie")
                        .WithOne("material")
                        .HasForeignKey("NWSInventaire.Shared.Models.Material", "MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NWSInventaire.Shared.Models.Student", "student")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.Navigation("MaterialCategorie");

                    b.Navigation("student");
                });

            modelBuilder.Entity("NWSInventaire.Shared.Models.MaterialCategorie", b =>
                {
                    b.Navigation("material");
                });
#pragma warning restore 612, 618
        }
    }
}
