﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Context;

namespace Persistence.Migrations
{
    [DbContext(typeof(CatalogContext))]
    [Migration("20210406202131_Init3")]
    partial class Init3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.Property<int>("ProductCategoriesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductCategoriesId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("CategoryProduct");
                });

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Domain.Entities.ProductAggregate.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Domain.Entities.ProductAggregate.Properties", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProductId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.HasOne("Domain.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("ProductCategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.ProductAggregate.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.HasOne("Domain.Entities.Category", null)
                        .WithMany("Items")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("Domain.Entities.ProductAggregate.Properties", b =>
                {
                    b.HasOne("Domain.Entities.Category", null)
                        .WithMany("Properties")
                        .HasForeignKey("CategoryId");

                    b.HasOne("Domain.Entities.ProductAggregate.Product", null)
                        .WithMany("Properties")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("Properties");
                });

            modelBuilder.Entity("Domain.Entities.ProductAggregate.Product", b =>
                {
                    b.Navigation("Properties");
                });
#pragma warning restore 612, 618
        }
    }
}
