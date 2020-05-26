﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Website.Models;

namespace Website.Data.Migrations
{
    [DbContext(typeof(GameContext))]
    partial class GameContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Website.Models.Card", b =>
                {
                    b.Property<int>("CardID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CharacterID")
                        .HasColumnType("int");

                    b.Property<int>("Economy1")
                        .HasColumnType("int");

                    b.Property<int>("Economy2")
                        .HasColumnType("int");

                    b.Property<int>("Happiness1")
                        .HasColumnType("int");

                    b.Property<int>("Happiness2")
                        .HasColumnType("int");

                    b.Property<string>("ImageRef")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Military1")
                        .HasColumnType("int");

                    b.Property<int>("Military2")
                        .HasColumnType("int");

                    b.Property<int>("Relations1")
                        .HasColumnType("int");

                    b.Property<int>("Relations2")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CardID");

                    b.ToTable("Card");
                });
#pragma warning restore 612, 618
        }
    }
}
