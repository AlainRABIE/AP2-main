﻿// <auto-generated />
using System;
using ASPBookProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ASPBookProject.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("ASPBookProject.Models.Antecedent", b =>
                {
                    b.Property<int>("AntecedentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("AntecedentId"));

                    b.HasKey("AntecedentId");

                    b.ToTable("Antecedents");
                });

            modelBuilder.Entity("ASPBookProject.Models.Incompatibilite", b =>
                {
                    b.Property<int>("IncompatibiliteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IncompatibiliteId"));

                    b.Property<int>("Interdiction")
                        .HasColumnType("int");

                    b.HasKey("IncompatibiliteId");

                    b.ToTable("Incompatibilites");
                });

            modelBuilder.Entity("ASPBookProject.Models.Medecin", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Identifiant")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("ASPBookProject.Models.Medicament", b =>
                {
                    b.Property<int>("MedicamentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("MedicamentId"));

                    b.Property<string>("Allergie")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("IncompatibiliteId")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Posologie")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("MedicamentId");

                    b.HasIndex("IncompatibiliteId");

                    b.ToTable("Medicaments");
                });

            modelBuilder.Entity("ASPBookProject.Models.Ordonnance", b =>
                {
                    b.Property<int>("OrdonnanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("OrdonnanceId"));

                    b.Property<string>("MedecinId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("Patologie")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("OrdonnanceId");

                    b.HasIndex("MedecinId");

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.ToTable("Ordonnances");
                });

            modelBuilder.Entity("ASPBookProject.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("PatientId"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PatientId");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("AntecedentMedicament", b =>
                {
                    b.Property<int>("AntecedentsAntecedentId")
                        .HasColumnType("int");

                    b.Property<int>("MedicamentsMedicamentId")
                        .HasColumnType("int");

                    b.HasKey("AntecedentsAntecedentId", "MedicamentsMedicamentId");

                    b.HasIndex("MedicamentsMedicamentId");

                    b.ToTable("AntecedentMedicament", (string)null);
                });

            modelBuilder.Entity("AntecedentPatient", b =>
                {
                    b.Property<int>("AntecedentsAntecedentId")
                        .HasColumnType("int");

                    b.Property<int>("PatientsPatientId")
                        .HasColumnType("int");

                    b.HasKey("AntecedentsAntecedentId", "PatientsPatientId");

                    b.HasIndex("PatientsPatientId");

                    b.ToTable("AntecedentPatient", (string)null);
                });

            modelBuilder.Entity("IncompatibilitePatient", b =>
                {
                    b.Property<int>("IncompatibilitesIncompatibiliteId")
                        .HasColumnType("int");

                    b.Property<int>("PatientsPatientId")
                        .HasColumnType("int");

                    b.HasKey("IncompatibilitesIncompatibiliteId", "PatientsPatientId");

                    b.HasIndex("PatientsPatientId");

                    b.ToTable("IncompatibilitesPatient", (string)null);
                });

            modelBuilder.Entity("MedicamentOrdonnance", b =>
                {
                    b.Property<int>("MedicamentsMedicamentId")
                        .HasColumnType("int");

                    b.Property<int>("OrdonnancesOrdonnanceId")
                        .HasColumnType("int");

                    b.HasKey("MedicamentsMedicamentId", "OrdonnancesOrdonnanceId");

                    b.HasIndex("OrdonnancesOrdonnanceId");

                    b.ToTable("OrdonnanceMedicament", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ASPBookProject.Models.Medicament", b =>
                {
                    b.HasOne("ASPBookProject.Models.Incompatibilite", null)
                        .WithMany("Medicaments")
                        .HasForeignKey("IncompatibiliteId");
                });

            modelBuilder.Entity("ASPBookProject.Models.Ordonnance", b =>
                {
                    b.HasOne("ASPBookProject.Models.Medecin", "Medecin")
                        .WithMany("Ordonnances")
                        .HasForeignKey("MedecinId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASPBookProject.Models.Patient", "Patient")
                        .WithOne("Ordonnance")
                        .HasForeignKey("ASPBookProject.Models.Ordonnance", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medecin");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("AntecedentMedicament", b =>
                {
                    b.HasOne("ASPBookProject.Models.Antecedent", null)
                        .WithMany()
                        .HasForeignKey("AntecedentsAntecedentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASPBookProject.Models.Medicament", null)
                        .WithMany()
                        .HasForeignKey("MedicamentsMedicamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AntecedentPatient", b =>
                {
                    b.HasOne("ASPBookProject.Models.Antecedent", null)
                        .WithMany()
                        .HasForeignKey("AntecedentsAntecedentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASPBookProject.Models.Patient", null)
                        .WithMany()
                        .HasForeignKey("PatientsPatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IncompatibilitePatient", b =>
                {
                    b.HasOne("ASPBookProject.Models.Incompatibilite", null)
                        .WithMany()
                        .HasForeignKey("IncompatibilitesIncompatibiliteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASPBookProject.Models.Patient", null)
                        .WithMany()
                        .HasForeignKey("PatientsPatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MedicamentOrdonnance", b =>
                {
                    b.HasOne("ASPBookProject.Models.Medicament", null)
                        .WithMany()
                        .HasForeignKey("MedicamentsMedicamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASPBookProject.Models.Ordonnance", null)
                        .WithMany()
                        .HasForeignKey("OrdonnancesOrdonnanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ASPBookProject.Models.Medecin", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ASPBookProject.Models.Medecin", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASPBookProject.Models.Medecin", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ASPBookProject.Models.Medecin", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ASPBookProject.Models.Incompatibilite", b =>
                {
                    b.Navigation("Medicaments");
                });

            modelBuilder.Entity("ASPBookProject.Models.Medecin", b =>
                {
                    b.Navigation("Ordonnances");
                });

            modelBuilder.Entity("ASPBookProject.Models.Patient", b =>
                {
                    b.Navigation("Ordonnance");
                });
#pragma warning restore 612, 618
        }
    }
}
