﻿// <auto-generated />
using System;
using CLG.OperationsAPI.Application.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MediatorPatternAPI.Migrations
{
    [DbContext(typeof(OperationContext))]
    partial class OperationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("CLG.OperationsAPI.Application.Entity.Operation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id");

                    b.Property<DateTime>("DateOp")
                        .HasColumnType("TEXT")
                        .HasColumnName("DateOp");

                    b.Property<string>("DescriptionOp")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("DescriptionOp");

                    b.Property<int>("TypeOp")
                        .HasColumnType("INTEGER")
                        .HasColumnName("TypeOp");

                    b.Property<double>("ValueOp")
                        .HasColumnType("REAL")
                        .HasColumnName("ValueOp");

                    b.HasKey("Id");

                    b.ToTable("operations");
                });
#pragma warning restore 612, 618
        }
    }
}
