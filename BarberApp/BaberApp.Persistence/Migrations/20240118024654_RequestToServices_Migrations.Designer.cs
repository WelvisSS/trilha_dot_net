﻿// <auto-generated />
using System;
using BarberApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BaberApp.Persistence.Migrations
{
    [DbContext(typeof(BarberAppContext))]
    [Migration("20240118024654_RequestToServices_Migrations")]
    partial class RequestToServices_Migrations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BarberApp.Domain.Entities.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("ClientId");

                    b.ToTable("Clients", (string)null);
                });

            modelBuilder.Entity("BarberApp.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employeess", (string)null);
                });

            modelBuilder.Entity("BarberApp.Domain.Entities.LegalPerson", b =>
                {
                    b.Property<int>("LegalPersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("LegalPersonId");

                    b.ToTable("LegalPersons", (string)null);
                });

            modelBuilder.Entity("BarberApp.Domain.Entities.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("PersonId");

                    b.ToTable("Persons", (string)null);
                });

            modelBuilder.Entity("BarberApp.Domain.Entities.PhysicalPerson", b =>
                {
                    b.Property<int>("PhysicalPersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PhysicalPersonId");

                    b.ToTable("PhysicalPersonss", (string)null);
                });

            modelBuilder.Entity("BarberApp.Domain.Entities.Request", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("RequiredAmount")
                        .HasColumnType("double");

                    b.HasKey("RequestId");

                    b.HasIndex("ClientId");

                    b.ToTable("Requests", (string)null);
                });

            modelBuilder.Entity("BarberApp.Domain.Entities.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Amount")
                        .HasColumnType("double");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("RequestId")
                        .HasColumnType("int");

                    b.Property<string>("ServieType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ServiceId");

                    b.HasIndex("RequestId");

                    b.ToTable("Services", (string)null);
                });

            modelBuilder.Entity("BarberApp.Domain.Entities.Person", b =>
                {
                    b.HasOne("BarberApp.Domain.Entities.Client", "Client")
                        .WithOne("Person")
                        .HasForeignKey("BarberApp.Domain.Entities.Person", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BarberApp.Domain.Entities.Employee", "Employee")
                        .WithOne("Person")
                        .HasForeignKey("BarberApp.Domain.Entities.Person", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BarberApp.Domain.Entities.LegalPerson", "LegalPerson")
                        .WithOne("Person")
                        .HasForeignKey("BarberApp.Domain.Entities.Person", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BarberApp.Domain.Entities.PhysicalPerson", "PhysicalPerson")
                        .WithOne("Person")
                        .HasForeignKey("BarberApp.Domain.Entities.Person", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Employee");

                    b.Navigation("LegalPerson");

                    b.Navigation("PhysicalPerson");
                });

            modelBuilder.Entity("BarberApp.Domain.Entities.Request", b =>
                {
                    b.HasOne("BarberApp.Domain.Entities.Client", "Client")
                        .WithMany("Requests")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("BarberApp.Domain.Entities.Service", b =>
                {
                    b.HasOne("BarberApp.Domain.Entities.Request", "Request")
                        .WithMany("Services")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Request");
                });

            modelBuilder.Entity("BarberApp.Domain.Entities.Client", b =>
                {
                    b.Navigation("Person")
                        .IsRequired();

                    b.Navigation("Requests");
                });

            modelBuilder.Entity("BarberApp.Domain.Entities.Employee", b =>
                {
                    b.Navigation("Person")
                        .IsRequired();
                });

            modelBuilder.Entity("BarberApp.Domain.Entities.LegalPerson", b =>
                {
                    b.Navigation("Person")
                        .IsRequired();
                });

            modelBuilder.Entity("BarberApp.Domain.Entities.PhysicalPerson", b =>
                {
                    b.Navigation("Person")
                        .IsRequired();
                });

            modelBuilder.Entity("BarberApp.Domain.Entities.Request", b =>
                {
                    b.Navigation("Services");
                });
#pragma warning restore 612, 618
        }
    }
}
