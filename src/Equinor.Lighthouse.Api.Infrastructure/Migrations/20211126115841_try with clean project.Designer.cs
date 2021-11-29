﻿// <auto-generated />
using System;
using Equinor.Lighthouse.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Equinor.Lighthouse.Api.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20211126115841_try with clean project")]
    partial class trywithcleanproject
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Equinor.Lighthouse.Api.Domain.AggregateModels.PersonAggregate.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<DateTime?>("ModifiedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedById")
                        .HasColumnType("int");

                    b.Property<Guid>("Oid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("ModifiedById");

                    b.HasIndex("Oid")
                        .IsUnique();

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Equinor.Lighthouse.Api.Domain.AggregateModels.PersonAggregate.SavedFilter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<string>("Criteria")
                        .IsRequired()
                        .HasMaxLength(8000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DefaultFilter")
                        .HasColumnType("bit");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("Plant")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("PersonId");

                    b.HasIndex("ProjectId");

                    b.ToTable("SavedFilters");
                });

            modelBuilder.Entity("Equinor.Lighthouse.Api.Domain.AggregateModels.ProjectAggregate.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedById")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Plant")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.HasIndex("Name")
                        .HasDatabaseName("IX_Projects_Name_ASC");

                    SqlServerIndexBuilderExtensions.IncludeProperties(b.HasIndex("Name"), new[] { "Plant" });

                    b.HasIndex("Plant")
                        .HasDatabaseName("IX_Projects_Plant_ASC");

                    SqlServerIndexBuilderExtensions.IncludeProperties(b.HasIndex("Plant"), new[] { "Name", "IsClosed", "CreatedAtUtc", "ModifiedAtUtc" });

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Equinor.Lighthouse.Api.Domain.AggregateModels.ResponsibleAggregate.Responsible", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsVoided")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedById")
                        .HasColumnType("int");

                    b.Property<string>("Plant")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.HasIndex("Plant")
                        .HasDatabaseName("IX_Responsibles_Plant_ASC");

                    SqlServerIndexBuilderExtensions.IncludeProperties(b.HasIndex("Plant"), new[] { "CreatedAtUtc", "IsVoided", "ModifiedAtUtc", "Description" });

                    b.ToTable("Responsibles");
                });

            modelBuilder.Entity("Equinor.Lighthouse.Api.Domain.AggregateModels.SettingAggregate.Setting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<DateTime?>("DateTimeUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Plant")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Equinor.Lighthouse.Api.Domain.AggregateModels.PersonAggregate.Person", b =>
                {
                    b.HasOne("Equinor.Lighthouse.Api.Domain.AggregateModels.PersonAggregate.Person", null)
                        .WithMany()
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("Equinor.Lighthouse.Api.Domain.AggregateModels.PersonAggregate.SavedFilter", b =>
                {
                    b.HasOne("Equinor.Lighthouse.Api.Domain.AggregateModels.PersonAggregate.Person", null)
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Equinor.Lighthouse.Api.Domain.AggregateModels.PersonAggregate.Person", null)
                        .WithMany("SavedFilters")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Equinor.Lighthouse.Api.Domain.AggregateModels.ProjectAggregate.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Equinor.Lighthouse.Api.Domain.AggregateModels.ProjectAggregate.Project", b =>
                {
                    b.HasOne("Equinor.Lighthouse.Api.Domain.AggregateModels.PersonAggregate.Person", null)
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Equinor.Lighthouse.Api.Domain.AggregateModels.PersonAggregate.Person", null)
                        .WithMany()
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("Equinor.Lighthouse.Api.Domain.AggregateModels.ResponsibleAggregate.Responsible", b =>
                {
                    b.HasOne("Equinor.Lighthouse.Api.Domain.AggregateModels.PersonAggregate.Person", null)
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Equinor.Lighthouse.Api.Domain.AggregateModels.PersonAggregate.Person", null)
                        .WithMany()
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("Equinor.Lighthouse.Api.Domain.AggregateModels.PersonAggregate.Person", b =>
                {
                    b.Navigation("SavedFilters");
                });
#pragma warning restore 612, 618
        }
    }
}
