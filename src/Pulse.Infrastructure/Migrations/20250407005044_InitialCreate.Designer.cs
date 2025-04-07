﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Pulse.Infrastructure;

#nullable disable

namespace Pulse.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250407005044_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "special_types", new[] { "food", "drink", "entertainment" });
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "postgis");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Pulse.Core.Models.Entities.Special", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("content");

                    b.Property<LocalTime?>("EndTime")
                        .HasColumnType("time")
                        .HasColumnName("end_time");

                    b.Property<LocalDate?>("ExpirationDate")
                        .HasColumnType("date")
                        .HasColumnName("expiration_date");

                    b.Property<bool>("IsRecurring")
                        .HasColumnType("boolean")
                        .HasColumnName("is_recurring");

                    b.Property<string>("RecurringSchedule")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("recurring_schedule");

                    b.Property<LocalDate>("StartDate")
                        .HasColumnType("date")
                        .HasColumnName("start_date");

                    b.Property<LocalTime>("StartTime")
                        .HasColumnType("time")
                        .HasColumnName("start_time");

                    b.Property<int>("Type")
                        .HasColumnType("integer")
                        .HasColumnName("type");

                    b.Property<int>("VenueId")
                        .HasColumnType("integer")
                        .HasColumnName("venue_id");

                    b.HasKey("Id")
                        .HasName("pk_specials");

                    b.HasIndex("VenueId")
                        .HasDatabaseName("ix_specials_venue_id");

                    b.ToTable("specials", (string)null);
                });

            modelBuilder.Entity("Pulse.Core.Models.Entities.Venue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("address_line1");

                    b.Property<string>("AddressLine2")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("address_line2");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("category");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("country");

                    b.Property<string>("CountryCode")
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("country_code");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("description");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("email");

                    b.Property<Point>("Location")
                        .HasColumnType("geography")
                        .HasColumnName("location");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("phone_number");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("region");

                    b.Property<string>("Website")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("website");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("zip_code");

                    b.HasKey("Id")
                        .HasName("pk_venues");

                    b.ToTable("venues", (string)null);
                });

            modelBuilder.Entity("Pulse.Core.Models.Entities.Special", b =>
                {
                    b.HasOne("Pulse.Core.Models.Entities.Venue", "Venue")
                        .WithMany("Specials")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_specials_venues_venue_id");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("Pulse.Core.Models.Entities.Venue", b =>
                {
                    b.Navigation("Specials");
                });
#pragma warning restore 612, 618
        }
    }
}
