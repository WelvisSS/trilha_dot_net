﻿// <auto-generated />
using System;
using BarberApp.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BarberApp.Infrastructure.Migrations
{
    [DbContext(typeof(BarberAppDbContext))]
    partial class BarberAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.16");

            modelBuilder.Entity("BarberApp.Domain.Entities.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CEP")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<int>("PersonId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Role")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("ClientId");

                    b.ToTable("Clients", (string)null);
                });

            modelBuilder.Entity("BarberApp.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<int>("PersonId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees", (string)null);
                });

            modelBuilder.Entity("BarberApp.Domain.Entities.LegalPerson", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CNPJ")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("PersonId");

                    b.ToTable("LegalPersons", (string)null);
                });

            modelBuilder.Entity("BarberApp.Domain.Entities.PhysicalPerson", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPF")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("PersonId");

                    b.ToTable("PhysicalPersons", (string)null);
                });

            modelBuilder.Entity("BarberApp.Domain.Entities.Request", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<double?>("RequiredAmount")
                        .HasColumnType("REAL");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("RequestId");

                    b.HasIndex("ClientId");

                    b.ToTable("Requests", (string)null);
                });

            modelBuilder.Entity("BarberApp.Domain.Entities.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Amount")
                        .HasColumnType("REAL");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RequestId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ServiceType")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("ServiceId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Services", (string)null);
                });

            modelBuilder.Entity("BarberApp.Domain.Entities.Request", b =>
                {
                    b.HasOne("BarberApp.Domain.Entities.Client", null)
                        .WithMany("Requests")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BarberApp.Domain.Entities.Service", b =>
                {
                    b.HasOne("BarberApp.Domain.Entities.Employee", null)
                        .WithMany("Services")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BarberApp.Domain.Entities.Client", b =>
                {
                    b.Navigation("Requests");
                });

            modelBuilder.Entity("BarberApp.Domain.Entities.Employee", b =>
                {
                    b.Navigation("Services");
                });
#pragma warning restore 612, 618
        }
    }
}
