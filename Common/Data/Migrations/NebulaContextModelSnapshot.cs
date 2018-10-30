﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nebula.Common.Data;

namespace Data.Migrations
{
    [DbContext(typeof(NebulaContext))]
    partial class NebulaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Nebula.SDK.Objects.Server.Plugin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Author");

                    b.Property<string>("Description");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Name");

                    b.Property<DateTime>("Published");

                    b.Property<string>("RepositoryUrl");

                    b.Property<Guid>("UploadedById");

                    b.Property<bool>("Verified");

                    b.HasKey("Id");

                    b.HasIndex("UploadedById");

                    b.ToTable("Plugins");
                });

            modelBuilder.Entity("Nebula.SDK.Objects.Server.Template", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Author");

                    b.Property<string>("Description");

                    b.Property<Guid?>("LanguagePluginId");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Name");

                    b.Property<DateTime>("Published");

                    b.Property<string>("RepositoryUrl");

                    b.Property<Guid>("UploadedById");

                    b.Property<bool>("Verified");

                    b.HasKey("Id");

                    b.HasIndex("LanguagePluginId");

                    b.HasIndex("UploadedById");

                    b.ToTable("Templates");
                });

            modelBuilder.Entity("Nebula.SDK.Objects.Shared.PluginDependency", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<Guid?>("PluginId");

                    b.Property<string>("VersionPattern");

                    b.HasKey("Id");

                    b.HasIndex("PluginId");

                    b.ToTable("PluginDependency");
                });

            modelBuilder.Entity("Nebula.SDK.Objects.Shared.PluginVersion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CommitSha");

                    b.Property<DateTime>("DateAdded");

                    b.Property<Guid?>("PluginId");

                    b.Property<string>("Version");

                    b.HasKey("Id");

                    b.HasIndex("PluginId");

                    b.ToTable("PluginVersion");
                });

            modelBuilder.Entity("Nebula.SDK.Objects.Shared.TemplateLanguagePlugin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Version");

                    b.HasKey("Id");

                    b.ToTable("TemplateLanguagePlugin");
                });

            modelBuilder.Entity("Nebula.SDK.Objects.Shared.TemplateVersion", b =>
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

            modelBuilder.Entity("Nebula.SDK.Objects.Shared.User", b =>
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

            modelBuilder.Entity("Nebula.SDK.Objects.Server.Plugin", b =>
                {
                    b.HasOne("Nebula.SDK.Objects.Shared.User", "UploadedBy")
                        .WithMany()
                        .HasForeignKey("UploadedById")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Nebula.SDK.Objects.Server.Template", b =>
                {
                    b.HasOne("Nebula.SDK.Objects.Shared.TemplateLanguagePlugin", "LanguagePlugin")
                        .WithMany()
                        .HasForeignKey("LanguagePluginId");

                    b.HasOne("Nebula.SDK.Objects.Shared.User", "UploadedBy")
                        .WithMany()
                        .HasForeignKey("UploadedById")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Nebula.SDK.Objects.Shared.PluginDependency", b =>
                {
                    b.HasOne("Nebula.SDK.Objects.Server.Plugin")
                        .WithMany("Dependencies")
                        .HasForeignKey("PluginId");
                });

            modelBuilder.Entity("Nebula.SDK.Objects.Shared.PluginVersion", b =>
                {
                    b.HasOne("Nebula.SDK.Objects.Server.Plugin")
                        .WithMany("Versions")
                        .HasForeignKey("PluginId");
                });

            modelBuilder.Entity("Nebula.SDK.Objects.Shared.TemplateVersion", b =>
                {
                    b.HasOne("Nebula.SDK.Objects.Server.Template")
                        .WithMany("Versions")
                        .HasForeignKey("TemplateId");
                });
#pragma warning restore 612, 618
        }
    }
}
