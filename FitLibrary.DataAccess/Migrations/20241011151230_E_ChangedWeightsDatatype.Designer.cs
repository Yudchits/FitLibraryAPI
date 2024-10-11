﻿// <auto-generated />
using System;
using FitLibrary.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FitLibrary.DataAccess.Migrations
{
    [DbContext(typeof(FitLibraryContext))]
    [Migration("20241011151230_E_ChangedWeightsDatatype")]
    partial class E_ChangedWeightsDatatype
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FitLibrary.DataAccess.Common.Models.ExerciseDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ExerciseName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int?>("Repetitions")
                        .HasColumnType("int");

                    b.Property<string>("RestPeriod")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int?>("Sets")
                        .HasColumnType("int");

                    b.Property<string>("Time")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("TrainingPlanId")
                        .HasColumnType("int");

                    b.Property<int?>("Week")
                        .HasColumnType("int");

                    b.Property<decimal?>("Weight")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("TrainingPlanId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("FitLibrary.DataAccess.Common.Models.TrainingPlanDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal?>("Rating")
                        .HasPrecision(3, 2)
                        .HasColumnType("decimal(3,2)");

                    b.Property<string>("Sport")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("TrainingPlans");
                });

            modelBuilder.Entity("FitLibrary.DataAccess.Common.Models.UserDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FitLibrary.DataAccess.Common.Models.ExerciseDb", b =>
                {
                    b.HasOne("FitLibrary.DataAccess.Common.Models.TrainingPlanDb", "TrainingPlan")
                        .WithMany("Exercises")
                        .HasForeignKey("TrainingPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TrainingPlan");
                });

            modelBuilder.Entity("FitLibrary.DataAccess.Common.Models.TrainingPlanDb", b =>
                {
                    b.HasOne("FitLibrary.DataAccess.Common.Models.UserDb", "Creator")
                        .WithMany("TrainingPlans")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("FitLibrary.DataAccess.Common.Models.TrainingPlanDb", b =>
                {
                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("FitLibrary.DataAccess.Common.Models.UserDb", b =>
                {
                    b.Navigation("TrainingPlans");
                });
#pragma warning restore 612, 618
        }
    }
}
