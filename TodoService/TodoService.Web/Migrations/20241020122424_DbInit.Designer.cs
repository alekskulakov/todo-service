﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoService.Web.Db;

#nullable disable

namespace TodoService.Web.Migrations
{
    [DbContext(typeof(TodoContext))]
    [Migration("20241020122424_DbInit")]
    partial class DbInit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("TodoService.Web.Db.Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                    MySqlPropertyBuilderExtensions.UseMySqlComputedColumn(b.Property<DateTime?>("UpdatedAt"));

                    b.HasKey("Id");

                    b.ToTable("Todos", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Description 1",
                            IsDeleted = false,
                            Title = "Title 1"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Description 2",
                            IsDeleted = false,
                            Title = "Title 2"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Description 3",
                            IsDeleted = false,
                            Title = "Title 3"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Description 4",
                            IsDeleted = false,
                            Title = "Title 4"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Description 5",
                            IsDeleted = false,
                            Title = "Title 5"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Description 6",
                            IsDeleted = false,
                            Title = "Title 6"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Description 7",
                            IsDeleted = false,
                            Title = "Title 7"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Description 8",
                            IsDeleted = false,
                            Title = "Title 8"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Description 9",
                            IsDeleted = false,
                            Title = "Title 9"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Description 10",
                            IsDeleted = false,
                            Title = "Title 10"
                        },
                        new
                        {
                            Id = 11,
                            Description = "Description 11",
                            IsDeleted = false,
                            Title = "Title 11"
                        },
                        new
                        {
                            Id = 12,
                            Description = "Description 12",
                            IsDeleted = false,
                            Title = "Title 12"
                        },
                        new
                        {
                            Id = 13,
                            Description = "Description 13",
                            IsDeleted = false,
                            Title = "Title 13"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
