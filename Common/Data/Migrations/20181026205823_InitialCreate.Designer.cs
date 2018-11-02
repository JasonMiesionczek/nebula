﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nebula.Common.Data;

namespace Data.Migrations
{
    [DbContext(typeof(NebulaContext))]
    [Migration("20181026205823_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Nebula.Common.Data.Models.Template", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<Guid>("AuthorId");

                    b.Property<string>("Description");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Name");

                    b.Property<DateTime>("Published");

                    b.Property<bool>("Verified");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Templates");
                });

            modelBuilder.Entity("Nebula.Common.Data.Models.TemplateVersion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CommitSha");

                    b.Property<DateTime>("DateAdded");

                    b.Property<Guid?>("TemplateId");

                    b.Property<string>("Version");

                    b.HasKey("Id");

                    b.HasIndex("TemplateId");

                    b.ToTable("TemplateVersion");
                });

            modelBuilder.Entity("Nebula.Common.Data.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<DateTime>("Joined");

                    b.Property<DateTime>("LastLogin");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Nebula.Common.Data.Models.Template", b =>
                {
                    b.HasOne("Nebula.Common.Data.Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Nebula.Common.Data.Models.TemplateVersion", b =>
                {
                    b.HasOne("Nebula.Common.Data.Models.Template")
                        .WithMany("Versions")
                        .HasForeignKey("TemplateId");
                });
#pragma warning restore 612, 618
        }
    }
}