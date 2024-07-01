﻿// <auto-generated />
using System;
using Emodiario.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Emodiario.Data.Migrations;

[DbContext(typeof(AppDbContext))]
partial class AppDbContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasAnnotation("ProductVersion", "6.0.31")
            .HasAnnotation("Relational:MaxIdentifierLength", 63);

        NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

        modelBuilder.Entity("Emodiario.Models.Avaliacao", b =>
            {
                b.Property<int>("IdUsuario")
                    .HasColumnType("integer");

                b.Property<int>("IdCategoria")
                    .HasColumnType("integer");

                b.Property<int?>("CategoriaId")
                    .HasColumnType("integer");

                b.Property<DateTime>("DataAtualizacao")
                    .HasColumnType("timestamp with time zone");

                b.Property<string>("Descricao")
                    .HasColumnType("text");

                b.Property<int>("Id")
                    .HasColumnType("integer");

                b.Property<int?>("UsuarioId")
                    .HasColumnType("integer");

                b.Property<int>("Valor")
                    .HasColumnType("integer");

                b.HasKey("IdUsuario", "IdCategoria");

                b.HasIndex("CategoriaId");

                b.HasIndex("UsuarioId");

                b.ToTable("Avaliacoes", (string)null);
            });

        modelBuilder.Entity("Emodiario.Models.Categoria", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                b.Property<string>("Descricao")
                    .HasColumnType("text");

                b.Property<string>("Nome")
                    .HasColumnType("text");

                b.HasKey("Id");

                b.ToTable("Categorias", (string)null);
            });

        modelBuilder.Entity("Emodiario.Models.Usuario", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                b.Property<string>("Email")
                    .HasColumnType("text");

                b.Property<string>("Nome")
                    .HasColumnType("text");

                b.Property<string>("SenhaHash")
                    .HasColumnType("text");

                b.Property<string>("Telefone")
                    .HasColumnType("text");

                b.HasKey("Id");

                b.ToTable("Usuarios", (string)null);
            });

        modelBuilder.Entity("Emodiario.Models.Avaliacao", b =>
            {
                b.HasOne("Emodiario.Models.Categoria", "Categoria")
                    .WithMany()
                    .HasForeignKey("CategoriaId");

                b.HasOne("Emodiario.Models.Usuario", "Usuario")
                    .WithMany()
                    .HasForeignKey("UsuarioId");

                b.Navigation("Categoria");

                b.Navigation("Usuario");
            });
#pragma warning restore 612, 618
    }
}
