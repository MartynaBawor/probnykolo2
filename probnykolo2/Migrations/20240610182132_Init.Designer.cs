﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using probnykolo2.Data;

#nullable disable

namespace probnykolo2.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240610182132_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("probnykolo2.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("ID");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            FirstName = "Jan",
                            LastName = "Kowalski"
                        },
                        new
                        {
                            ID = 2,
                            FirstName = "Anna",
                            LastName = "Nowak"
                        });
                });

            modelBuilder.Entity("probnykolo2.Models.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("ID");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            FirstName = "Piotr",
                            LastName = "Nowak"
                        },
                        new
                        {
                            ID = 2,
                            FirstName = "Krzysztof",
                            LastName = "Kowalski"
                        });
                });

            modelBuilder.Entity("probnykolo2.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("AcceptedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<string>("Comments")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FulfilledAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            AcceptedAt = new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ClientID = 1,
                            Comments = "brak komentarza",
                            EmployeeID = 1,
                            FulfilledAt = new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = 2,
                            AcceptedAt = new DateTime(2021, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ClientID = 2,
                            Comments = "komentarz",
                            EmployeeID = 2,
                            FulfilledAt = new DateTime(2022, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = 3,
                            AcceptedAt = new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ClientID = 2,
                            EmployeeID = 1
                        });
                });

            modelBuilder.Entity("probnykolo2.Models.OrderPastry", b =>
                {
                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("PastryID")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Comments")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("OrderID", "PastryID");

                    b.HasIndex("PastryID");

                    b.ToTable("Order_Pastry");

                    b.HasData(
                        new
                        {
                            OrderID = 1,
                            PastryID = 1,
                            Amount = 2
                        },
                        new
                        {
                            OrderID = 2,
                            PastryID = 2,
                            Amount = 1,
                            Comments = "Lorem ipsum ..."
                        },
                        new
                        {
                            OrderID = 2,
                            PastryID = 1,
                            Amount = 3
                        },
                        new
                        {
                            OrderID = 1,
                            PastryID = 2,
                            Amount = 1
                        });
                });

            modelBuilder.Entity("probnykolo2.Models.Pastry", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("ID");

                    b.ToTable("Pastries");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Sernik",
                            Price = 15.99m,
                            Type = "ciasto"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Babka",
                            Price = 12.99m,
                            Type = "ciasto"
                        });
                });

            modelBuilder.Entity("probnykolo2.Models.Order", b =>
                {
                    b.HasOne("probnykolo2.Models.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("probnykolo2.Models.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("probnykolo2.Models.OrderPastry", b =>
                {
                    b.HasOne("probnykolo2.Models.Order", "Order")
                        .WithMany("OrderPastries")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("probnykolo2.Models.Pastry", "Pastry")
                        .WithMany("OrderPastries")
                        .HasForeignKey("PastryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Pastry");
                });

            modelBuilder.Entity("probnykolo2.Models.Client", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("probnykolo2.Models.Employee", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("probnykolo2.Models.Order", b =>
                {
                    b.Navigation("OrderPastries");
                });

            modelBuilder.Entity("probnykolo2.Models.Pastry", b =>
                {
                    b.Navigation("OrderPastries");
                });
#pragma warning restore 612, 618
        }
    }
}
