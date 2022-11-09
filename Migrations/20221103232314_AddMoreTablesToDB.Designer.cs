﻿// <auto-generated />
using System;
using CommerceProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CommerceProject.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20221103232314_AddMoreTablesToDB")]
    partial class AddMoreTablesToDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CommerceProject.Models.DonationForm", b =>
                {
                    b.Property<int>("FormID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FormID"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("DonationAmount")
                        .HasColumnType("float");

                    b.Property<string>("DonationType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FormID");

                    b.ToTable("donationForms");
                });

            modelBuilder.Entity("CommerceProject.Models.Donor", b =>
                {
                    b.Property<int>("DonorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DonorId"), 1L, 1);

                    b.Property<DateTime>("DateOfDonation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fundraiser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FundraiserID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("donatedAmount")
                        .HasColumnType("float");

                    b.HasKey("DonorId");

                    b.HasIndex("FundraiserID");

                    b.ToTable("Donors");
                });

            modelBuilder.Entity("CommerceProject.Models.Donor_1", b =>
                {
                    b.Property<int>("DonorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DonorID"), 1L, 1);

                    b.Property<double>("DonorAmount")
                        .HasColumnType("float");

                    b.Property<DateTime>("DonorDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DonorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DonorID");

                    b.ToTable("Donor_1s");
                });

            modelBuilder.Entity("CommerceProject.Models.Fundraiser", b =>
                {
                    b.Property<int>("FundraiserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FundraiserID"), 1L, 1);

                    b.Property<double>("CurrentAmount")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Goal")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserProfileUserId")
                        .HasColumnType("int");

                    b.HasKey("FundraiserID");

                    b.HasIndex("UserProfileUserId");

                    b.ToTable("Fundraisers");
                });

            modelBuilder.Entity("CommerceProject.Models.Fundraiser_1", b =>
                {
                    b.Property<int>("FundraiserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FundraiserId"), 1L, 1);

                    b.Property<double>("FundraiserCurrentAmount")
                        .HasColumnType("float");

                    b.Property<string>("FundraiserDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("FundraiserGoal")
                        .HasColumnType("float");

                    b.Property<string>("FundraiserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FundraiserId");

                    b.ToTable("Fundraiser_1s");
                });

            modelBuilder.Entity("CommerceProject.Models.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SecurityQuestion1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityQuestion2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityQuestion3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("CommerceProject.Models.User_1", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dob")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SequrityQuestion1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SequrityQuestion2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SequrityQuestion3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User_1s");
                });

            modelBuilder.Entity("CommerceProject.Models.UserProfile", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DOB")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("CommerceProject.Models.Donor", b =>
                {
                    b.HasOne("CommerceProject.Models.Fundraiser", null)
                        .WithMany("donors")
                        .HasForeignKey("FundraiserID");
                });

            modelBuilder.Entity("CommerceProject.Models.Fundraiser", b =>
                {
                    b.HasOne("CommerceProject.Models.UserProfile", null)
                        .WithMany("Fundraisers")
                        .HasForeignKey("UserProfileUserId");
                });

            modelBuilder.Entity("CommerceProject.Models.Fundraiser", b =>
                {
                    b.Navigation("donors");
                });

            modelBuilder.Entity("CommerceProject.Models.UserProfile", b =>
                {
                    b.Navigation("Fundraisers");
                });
#pragma warning restore 612, 618
        }
    }
}
