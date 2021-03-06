// <auto-generated />
using System;
using FavourAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FavourAPI.Migrations
{
    [DbContext(typeof(WorkFavourDbContext))]
    [Migration("20190322110010_oneOneCompanyUserFifth")]
    partial class oneOneCompanyUserFifth
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FavourAPI.Models.CompanyProvider", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Description");

                    b.Property<DateTime>("FoundedYear");

                    b.Property<string>("Name");

                    b.Property<int>("NumberOfEmployees");

                    b.Property<byte[]>("Picture");

                    b.HasKey("Id");

                    b.ToTable("CompanyProviders");
                });

            modelBuilder.Entity("FavourAPI.Models.Email", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmailAdress");

                    b.Property<string>("Label");

                    b.Property<string>("OfficeId");

                    b.Property<string>("PersonProviderId");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId");

                    b.HasIndex("PersonProviderId");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("FavourAPI.Models.Industry", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyProviderId");

                    b.Property<string>("Name");

                    b.Property<string>("OfficeId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyProviderId");

                    b.HasIndex("OfficeId");

                    b.ToTable("Industries");
                });

            modelBuilder.Entity("FavourAPI.Models.Office", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyProviderId");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CompanyProviderId");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("FavourAPI.Models.PersonProvider", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Description");

                    b.Property<string>("FirstName");

                    b.Property<byte[]>("Image");

                    b.Property<string>("LastName");

                    b.Property<string>("Location");

                    b.HasKey("Id");

                    b.ToTable("PersonProviders");
                });

            modelBuilder.Entity("FavourAPI.Models.PhoneNumber", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Label");

                    b.Property<string>("Number");

                    b.Property<string>("OfficeId");

                    b.Property<string>("PersonProviderId");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId");

                    b.HasIndex("PersonProviderId");

                    b.ToTable("PhoneNumbers");
                });

            modelBuilder.Entity("FavourAPI.Models.Position", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyProviderId");

                    b.Property<string>("IndustryId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyProviderId");

                    b.HasIndex("IndustryId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("FavourAPI.Models.Skill", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("PositionId");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("FavourAPI.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Token");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FavourAPI.Models.CompanyProvider", b =>
                {
                    b.HasOne("FavourAPI.Models.User", "User")
                        .WithOne("CompanyProvider")
                        .HasForeignKey("FavourAPI.Models.CompanyProvider", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FavourAPI.Models.Email", b =>
                {
                    b.HasOne("FavourAPI.Models.Office")
                        .WithMany("Emails")
                        .HasForeignKey("OfficeId");

                    b.HasOne("FavourAPI.Models.PersonProvider")
                        .WithMany("Emails")
                        .HasForeignKey("PersonProviderId");
                });

            modelBuilder.Entity("FavourAPI.Models.Industry", b =>
                {
                    b.HasOne("FavourAPI.Models.CompanyProvider")
                        .WithMany("Industries")
                        .HasForeignKey("CompanyProviderId");

                    b.HasOne("FavourAPI.Models.Office")
                        .WithMany("Industries")
                        .HasForeignKey("OfficeId");
                });

            modelBuilder.Entity("FavourAPI.Models.Office", b =>
                {
                    b.HasOne("FavourAPI.Models.CompanyProvider", "CompanyProvider")
                        .WithMany("Offices")
                        .HasForeignKey("CompanyProviderId");
                });

            modelBuilder.Entity("FavourAPI.Models.PersonProvider", b =>
                {
                    b.HasOne("FavourAPI.Models.User", "User")
                        .WithOne("PersonProvider")
                        .HasForeignKey("FavourAPI.Models.PersonProvider", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FavourAPI.Models.PhoneNumber", b =>
                {
                    b.HasOne("FavourAPI.Models.Office")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("OfficeId");

                    b.HasOne("FavourAPI.Models.PersonProvider")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("PersonProviderId");
                });

            modelBuilder.Entity("FavourAPI.Models.Position", b =>
                {
                    b.HasOne("FavourAPI.Models.CompanyProvider")
                        .WithMany("TargetedPositions")
                        .HasForeignKey("CompanyProviderId");

                    b.HasOne("FavourAPI.Models.Industry", "Industry")
                        .WithMany("Positions")
                        .HasForeignKey("IndustryId");
                });

            modelBuilder.Entity("FavourAPI.Models.Skill", b =>
                {
                    b.HasOne("FavourAPI.Models.Position", "Position")
                        .WithMany("Skills")
                        .HasForeignKey("PositionId");
                });
#pragma warning restore 612, 618
        }
    }
}
