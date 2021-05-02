﻿// <auto-generated />
using System;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infraestructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210502015118_Final_FourthMigration")]
    partial class Final_FourthMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApplicationCore.Entities.Paquete", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contenido_Paquete")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("Envio_Prioridad")
                        .HasColumnType("bit");

                    b.Property<bool>("Estado_Pago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Estado_Paquete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Pendiente");

                    b.Property<DateTime>("Fecha_Entrega")
                        .HasColumnType("datetime2");

                    b.Property<double>("Monto_Pagar_Prop")
                        .HasColumnType("float");

                    b.Property<double>("Peso_Contenido")
                        .HasColumnType("float");

                    b.Property<string>("String_Fotografia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tipo_Contenido")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Paquetes");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Registro_Pago", b =>
                {
                    b.Property<int>("Id_Pago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha_Pago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 5, 1, 19, 51, 17, 746, DateTimeKind.Local).AddTicks(3847));

                    b.Property<double>("Monto_Pagado")
                        .HasColumnType("float");

                    b.Property<int>("PaqueteId")
                        .HasColumnType("int");

                    b.HasKey("Id_Pago");

                    b.HasIndex("PaqueteId");

                    b.ToTable("Registro_Pagos");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Registro_Pago", b =>
                {
                    b.HasOne("ApplicationCore.Entities.Paquete", "Paquete")
                        .WithMany()
                        .HasForeignKey("PaqueteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paquete");
                });
#pragma warning restore 612, 618
        }
    }
}
