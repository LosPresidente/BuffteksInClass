﻿// <auto-generated />
using Buffteks.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace Buffteks.Migrations
{
    [DbContext(typeof(BuffteksContext))]
    partial class BuffteksContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("Buffteks.Models.BuffClient", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClientName");

                    b.HasKey("ID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Buffteks.Models.BuffMember", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("ID");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("Buffteks.Models.BuffProject", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ProjectName");

                    b.HasKey("ID");

                    b.ToTable("Project");
                });
#pragma warning restore 612, 618
        }
    }
}
