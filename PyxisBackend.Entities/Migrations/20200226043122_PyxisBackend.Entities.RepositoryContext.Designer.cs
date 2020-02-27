﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PyxisBackend.Entities;

namespace PyxisBackend.Entities.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20200226043122_PyxisBackend.Entities.RepositoryContext")]
    partial class PyxisBackendEntitiesRepositoryContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PyxisBackend.Entities.Models.Person", b =>
                {
                    b.Property<long>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PersonEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("PersonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("PersonPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("PersonId");

                    b.ToTable("persons");
                });

            modelBuilder.Entity("PyxisBackend.Entities.Models.Pet", b =>
                {
                    b.Property<long>("PetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnimalType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PersonId")
                        .HasColumnType("bigint");

                    b.Property<string>("PetName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PetId");

                    b.HasIndex("PersonId");

                    b.ToTable("pets");
                });

            modelBuilder.Entity("PyxisBackend.Entities.Models.Pet", b =>
                {
                    b.HasOne("PyxisBackend.Entities.Models.Person", "Person")
                        .WithMany("Pets")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
