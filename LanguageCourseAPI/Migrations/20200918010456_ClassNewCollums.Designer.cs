﻿// <auto-generated />
using System;
using LanguageCourseAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LanguageCourseAPI.Migrations
{
    [DbContext(typeof(DataContextAPI))]
    [Migration("20200918010456_ClassNewCollums")]
    partial class ClassNewCollums
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LanguageCourseAPI.Models.ClassRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("turma_ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnName("Idioma")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Module")
                        .IsRequired()
                        .HasColumnName("Modulo")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("TeachingMethodology")
                        .IsRequired()
                        .HasColumnName("MetodologiaDeEnsino")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("shift")
                        .HasColumnName("Turno")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("tbl_Turma");
                });

            modelBuilder.Entity("LanguageCourseAPI.Models.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("estudante_ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnName("Endereco")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnName("Data_Nascimento")
                        .HasColumnType("Date");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnName("CPF")
                        .HasColumnType("char(11)");

                    b.Property<int>("ClassRoomID")
                        .HasColumnType("int");

                    b.Property<string>("Enrollment")
                        .IsRequired()
                        .HasColumnName("Matricula")
                        .HasColumnType("char(10)")
                        .HasMaxLength(10);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnName("Nome_Completo")
                        .HasColumnType("varchar(120)")
                        .HasMaxLength(100);

                    b.Property<string>("Phone")
                        .HasColumnName("Telefone")
                        .HasColumnType("char(9)")
                        .HasMaxLength(10);

                    b.Property<string>("RG")
                        .HasColumnName("Identidade")
                        .HasColumnType("char(9)");

                    b.HasKey("ID");

                    b.HasIndex("ClassRoomID");

                    b.HasIndex("Enrollment")
                        .IsUnique();

                    b.ToTable("tbl_Aluno");
                });

            modelBuilder.Entity("LanguageCourseAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("User_ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("Senha")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Role")
                        .HasColumnName("Cargo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnName("Usuario")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("LanguageCourseAPI.Models.Student", b =>
                {
                    b.HasOne("LanguageCourseAPI.Models.ClassRoom", "ClassRoom")
                        .WithMany("Students")
                        .HasForeignKey("ClassRoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
