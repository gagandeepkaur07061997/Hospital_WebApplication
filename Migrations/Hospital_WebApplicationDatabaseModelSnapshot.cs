﻿// <auto-generated />
using System;
using Hospital_WebApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hospital_WebApplication.Migrations
{
    [DbContext(typeof(Hospital_WebApplicationDatabase))]
    partial class Hospital_WebApplicationDatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("Hospital_WebApplication.Models.Companydetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile_Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companydetail");
                });

            modelBuilder.Entity("Hospital_WebApplication.Models.Parcel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CompantdetailId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Content_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Delivery_address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Parcel_weight")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RecieverId")
                        .HasColumnType("int");

                    b.Property<int?>("RecieverdetailId")
                        .HasColumnType("int");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.Property<int?>("SenderdetailId")
                        .HasColumnType("int");

                    b.Property<decimal>("Shipping_cost")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CompantdetailId");

                    b.HasIndex("RecieverdetailId");

                    b.HasIndex("SenderdetailId");

                    b.ToTable("Parcel");
                });

            modelBuilder.Entity("Hospital_WebApplication.Models.Recieverdetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile_Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Recieverdetail");
                });

            modelBuilder.Entity("Hospital_WebApplication.Models.Senderdetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile_Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Senderdetail");
                });

            modelBuilder.Entity("Hospital_WebApplication.Models.Tracking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Expected_date_of_delivery")
                        .HasColumnType("datetime2");

                    b.Property<int>("ParcelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParcelId");

                    b.ToTable("Tracking");
                });

            modelBuilder.Entity("Hospital_WebApplication.Models.Parcel", b =>
                {
                    b.HasOne("Hospital_WebApplication.Models.Companydetail", "Compantdetail")
                        .WithMany()
                        .HasForeignKey("CompantdetailId");

                    b.HasOne("Hospital_WebApplication.Models.Recieverdetail", "Recieverdetail")
                        .WithMany()
                        .HasForeignKey("RecieverdetailId");

                    b.HasOne("Hospital_WebApplication.Models.Senderdetail", "Senderdetail")
                        .WithMany()
                        .HasForeignKey("SenderdetailId");

                    b.Navigation("Compantdetail");

                    b.Navigation("Recieverdetail");

                    b.Navigation("Senderdetail");
                });

            modelBuilder.Entity("Hospital_WebApplication.Models.Tracking", b =>
                {
                    b.HasOne("Hospital_WebApplication.Models.Parcel", "Parcel")
                        .WithMany()
                        .HasForeignKey("ParcelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parcel");
                });
#pragma warning restore 612, 618
        }
    }
}
