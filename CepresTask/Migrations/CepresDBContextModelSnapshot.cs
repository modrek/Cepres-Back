﻿// <auto-generated />
using System;
using CepresTask.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CepresTask.Migrations
{
    [DbContext(typeof(CepresDBContext))]
    partial class CepresDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CepresTask.Domain.Models.MetaDataModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("MetaData");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5d0de0e4-16f6-4d09-91cd-97a2fc9119a9"),
                            Key = "Age",
                            PatientId = new Guid("72cbc713-aeed-43db-a48e-d2d8ee2bb35c"),
                            Value = "56"
                        },
                        new
                        {
                            Id = new Guid("6f16b16e-e82a-41cd-9942-0d5ef7571773"),
                            Key = "Diabetes",
                            PatientId = new Guid("72cbc713-aeed-43db-a48e-d2d8ee2bb35c"),
                            Value = "yes"
                        },
                        new
                        {
                            Id = new Guid("c0d3ce46-954d-4c9a-893a-90a6f8d08c61"),
                            Key = "city",
                            PatientId = new Guid("72cbc713-aeed-43db-a48e-d2d8ee2bb35c"),
                            Value = "Salfeet "
                        },
                        new
                        {
                            Id = new Guid("0e32bf51-c055-46bd-b0d7-25ff216fde26"),
                            Key = "heart",
                            PatientId = new Guid("72cbc713-aeed-43db-a48e-d2d8ee2bb35c"),
                            Value = "open surgery"
                        },
                        new
                        {
                            Id = new Guid("b707da9e-e038-4357-bb86-a50b81caf93a"),
                            Key = "Age",
                            PatientId = new Guid("7ba98012-25fe-4c8d-846e-6c9a6b65ac04"),
                            Value = "35"
                        },
                        new
                        {
                            Id = new Guid("8f43e70e-189b-41ef-bd3b-1263b8e7b002"),
                            Key = "city",
                            PatientId = new Guid("7ba98012-25fe-4c8d-846e-6c9a6b65ac04"),
                            Value = "Ramallah"
                        },
                        new
                        {
                            Id = new Guid("fee49da6-39cb-4bf8-afbb-36629ff442f9"),
                            Key = "Age",
                            PatientId = new Guid("460c3d13-ad5f-4824-ab48-cc96a3456c5e"),
                            Value = "20"
                        },
                        new
                        {
                            Id = new Guid("c64c6a90-5816-4ad3-987c-511f3ed9a89c"),
                            Key = "city",
                            PatientId = new Guid("460c3d13-ad5f-4824-ab48-cc96a3456c5e"),
                            Value = "Jenin"
                        },
                        new
                        {
                            Id = new Guid("e223e727-7f6c-4f98-ae38-6c898bbf0ea2"),
                            Key = "Age",
                            PatientId = new Guid("5a1fd3b3-81ab-43e1-b989-865415a9754e"),
                            Value = "60"
                        },
                        new
                        {
                            Id = new Guid("07a194fd-3c1c-46dc-8c2b-60638ae8f0d6"),
                            Key = "Cancer",
                            PatientId = new Guid("5a1fd3b3-81ab-43e1-b989-865415a9754e"),
                            Value = "yes"
                        },
                        new
                        {
                            Id = new Guid("70765fc9-bfc5-4be8-9b95-8cbe450adf89"),
                            Key = "Asthma",
                            PatientId = new Guid("5a1fd3b3-81ab-43e1-b989-865415a9754e"),
                            Value = "yes"
                        });
                });

            modelBuilder.Entity("CepresTask.Domain.Models.PatientModel", b =>
                {
                    b.Property<Guid>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("OfficialID")
                        .HasColumnType("bigint");

                    b.Property<string>("PatientName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientId");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            PatientId = new Guid("72cbc713-aeed-43db-a48e-d2d8ee2bb35c"),
                            EmailAddress = "test@test.com",
                            OfficialID = 1901L,
                            PatientName = "Ahmad"
                        },
                        new
                        {
                            PatientId = new Guid("7ba98012-25fe-4c8d-846e-6c9a6b65ac04"),
                            EmailAddress = "test@test.com",
                            OfficialID = 1902L,
                            PatientName = "sami"
                        },
                        new
                        {
                            PatientId = new Guid("460c3d13-ad5f-4824-ab48-cc96a3456c5e"),
                            EmailAddress = "test@test.com",
                            OfficialID = 1903L,
                            PatientName = "Mohammad"
                        },
                        new
                        {
                            PatientId = new Guid("5a1fd3b3-81ab-43e1-b989-865415a9754e"),
                            EmailAddress = "test@test.com",
                            OfficialID = 1904L,
                            PatientName = "Jane"
                        });
                });

            modelBuilder.Entity("CepresTask.Domain.Models.RecordModel", b =>
                {
                    b.Property<Guid>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Bill")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiseaseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("TimeOfEntry")
                        .HasColumnType("datetime2");

                    b.HasKey("RecordId");

                    b.HasIndex("PatientId");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("CepresTask.Domain.Models.MetaDataModel", b =>
                {
                    b.HasOne("CepresTask.Domain.Models.PatientModel", null)
                        .WithMany("MetaData")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CepresTask.Domain.Models.RecordModel", b =>
                {
                    b.HasOne("CepresTask.Domain.Models.PatientModel", "Patient")
                        .WithMany("Records")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
