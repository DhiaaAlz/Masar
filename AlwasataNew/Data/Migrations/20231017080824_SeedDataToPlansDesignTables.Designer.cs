﻿// <auto-generated />
using System;
using AlwasataNew.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AlwasataNew.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231017080824_SeedDataToPlansDesignTables")]
    partial class SeedDataToPlansDesignTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AlwasataNew.Models.AirConditioningPlans", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AirConditioningPlans");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "Admin",
                            Name = "مخطط التكييف للقبو"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "Admin",
                            Name = "مخطط التكييف للأرضي"
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "Admin",
                            Name = "مخطط التكييف للأول"
                        },
                        new
                        {
                            Id = 4,
                            CreatedBy = "Admin",
                            Name = "مخطط التكييف للملاحق العلوية"
                        },
                        new
                        {
                            Id = 5,
                            CreatedBy = "Admin",
                            Name = "مواقع وحدات التكييف في الاسطح"
                        },
                        new
                        {
                            Id = 6,
                            CreatedBy = "Admin",
                            Name = "حساب الاحمال للتكييف"
                        });
                });

            modelBuilder.Entity("AlwasataNew.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<byte[]>("ProfilePicture")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users", "security");
                });

            modelBuilder.Entity("AlwasataNew.Models.Architecturalplans", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Architecturalplans");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "Admin",
                            Name = "الموقع العام"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "Admin",
                            Name = "معماري دور القبو"
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "Admin",
                            Name = "معماري الدور الارضي"
                        },
                        new
                        {
                            Id = 4,
                            CreatedBy = "Admin",
                            Name = "معماري الدور الاول"
                        },
                        new
                        {
                            Id = 5,
                            CreatedBy = "Admin",
                            Name = "معماري الملاحق العلوية"
                        },
                        new
                        {
                            Id = 6,
                            CreatedBy = "Admin",
                            Name = "مخططات فرش القبو"
                        },
                        new
                        {
                            Id = 7,
                            CreatedBy = "Admin",
                            Name = "مخططات فرش الدور الارضي"
                        },
                        new
                        {
                            Id = 8,
                            CreatedBy = "Admin",
                            Name = "مخططات فرش الدور الاول"
                        },
                        new
                        {
                            Id = 9,
                            CreatedBy = "Admin",
                            Name = "قطاعين عرضي وطولي"
                        },
                        new
                        {
                            Id = 10,
                            CreatedBy = "Admin",
                            Name = "4 واجهات"
                        },
                        new
                        {
                            Id = 11,
                            CreatedBy = "Admin",
                            Name = "جداول الابواب والنوافذ"
                        },
                        new
                        {
                            Id = 12,
                            CreatedBy = "Admin",
                            Name = "تفاصيل الادراج"
                        },
                        new
                        {
                            Id = 13,
                            CreatedBy = "Admin",
                            Name = "مخططات الاسوار"
                        },
                        new
                        {
                            Id = 14,
                            CreatedBy = "Admin",
                            Name = "لوحة تفاصيل المصعد"
                        },
                        new
                        {
                            Id = 15,
                            CreatedBy = "Admin",
                            Name = "لوحة ارضيات"
                        },
                        new
                        {
                            Id = 16,
                            CreatedBy = "Admin",
                            Name = "سقف"
                        });
                });

            modelBuilder.Entity("AlwasataNew.Models.ConstructionDrawings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ConstructionDrawings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "Admin",
                            Name = "مخطط المحاور والاعمدة"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "Admin",
                            Name = "مخطط اللبشة"
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "Admin",
                            Name = "مخطط القواعد المسلحة"
                        },
                        new
                        {
                            Id = 4,
                            CreatedBy = "Admin",
                            Name = "مخطط الميد والارضيات"
                        },
                        new
                        {
                            Id = 5,
                            CreatedBy = "Admin",
                            Name = "مخطط سقف الدور القبو"
                        },
                        new
                        {
                            Id = 6,
                            CreatedBy = "Admin",
                            Name = "مخطط سقف الدور الارضي"
                        },
                        new
                        {
                            Id = 7,
                            CreatedBy = "Admin",
                            Name = "مخطط سقف الدور الاول"
                        },
                        new
                        {
                            Id = 8,
                            CreatedBy = "Admin",
                            Name = "مخطط سقف الملحق العلوي"
                        },
                        new
                        {
                            Id = 9,
                            CreatedBy = "Admin",
                            Name = "الجداول"
                        },
                        new
                        {
                            Id = 10,
                            CreatedBy = "Admin",
                            Name = "مخططات تفصيلية"
                        });
                });

            modelBuilder.Entity("AlwasataNew.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FollowBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("AlwasataNew.Models.ElectricityPlans", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ElectricityPlans");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "Admin",
                            Name = "مخطط اضاءة القبو"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "Admin",
                            Name = "مخطط اضاءة الدور الارضي"
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "Admin",
                            Name = "مخطط اضاءة الدور الاول"
                        },
                        new
                        {
                            Id = 4,
                            CreatedBy = "Admin",
                            Name = "مخطط اضاءة دور الملحق"
                        },
                        new
                        {
                            Id = 5,
                            CreatedBy = "Admin",
                            Name = "مخطط القوى للقبو"
                        },
                        new
                        {
                            Id = 6,
                            CreatedBy = "Admin",
                            Name = "مخطط القوى للأرضي"
                        },
                        new
                        {
                            Id = 7,
                            CreatedBy = "Admin",
                            Name = " مخطط القوى للأول"
                        },
                        new
                        {
                            Id = 8,
                            CreatedBy = "Admin",
                            Name = "مخطط القوى للملحق العلوي"
                        },
                        new
                        {
                            Id = 9,
                            CreatedBy = "Admin",
                            Name = "مخطط التيار المنخفض"
                        },
                        new
                        {
                            Id = 10,
                            CreatedBy = "Admin",
                            Name = "مخطط التيار المنخفض للقبو"
                        },
                        new
                        {
                            Id = 11,
                            CreatedBy = "Admin",
                            Name = "مخطط التيار المنخفض للأرضي"
                        },
                        new
                        {
                            Id = 12,
                            CreatedBy = "Admin",
                            Name = "مخطط التيار المنخفض للأول"
                        },
                        new
                        {
                            Id = 13,
                            CreatedBy = "Admin",
                            Name = "مخطط التيار المنخفض للملحق العلوي"
                        },
                        new
                        {
                            Id = 14,
                            CreatedBy = "Admin",
                            Name = "تأسيس الطاقة الشمسية"
                        },
                        new
                        {
                            Id = 15,
                            CreatedBy = "Admin",
                            Name = "مخططات كميرات المراقبة"
                        },
                        new
                        {
                            Id = 16,
                            CreatedBy = "Admin",
                            Name = "جداول الاحمال"
                        },
                        new
                        {
                            Id = 17,
                            CreatedBy = "Admin",
                            Name = "مخططات تأريض"
                        },
                        new
                        {
                            Id = 18,
                            CreatedBy = "Admin",
                            Name = "جداول ورموز توضيحية"
                        },
                        new
                        {
                            Id = 19,
                            CreatedBy = "Admin",
                            Name = "مخطط كفاءة الطاقة"
                        });
                });

            modelBuilder.Entity("AlwasataNew.Models.MechanicalDiagrams", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MechanicalDiagrams");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "Admin",
                            Name = " مخططات صرف الامطار"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "Admin",
                            Name = "مخططات الصرف العام"
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "Admin",
                            Name = "مخطط التهوية"
                        },
                        new
                        {
                            Id = 4,
                            CreatedBy = "Admin",
                            Name = "مخطط التغذية"
                        },
                        new
                        {
                            Id = 5,
                            CreatedBy = "Admin",
                            Name = "موقع الخزانات والبيارة"
                        },
                        new
                        {
                            Id = 6,
                            CreatedBy = "Admin",
                            Name = "مخطط كفاءة الطاقة"
                        });
                });

            modelBuilder.Entity("AlwasataNew.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDone")
                        .HasColumnType("bit");

                    b.Property<double>("LandAreaByM")
                        .HasColumnType("float");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("AlwasataNew.Models.ProjectDesignStages", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("ArchitecturalDesigns")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArchitecturalPlans")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConstructionPlans")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ElectricityPlans")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InitialThoughts")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Interfaces")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MechanicsDiagrams")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifyAndDevelop")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Review")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId");

                    b.ToTable("ProjectDesignStages");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles", "security");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims", "security");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims", "security");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins", "security");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", "security");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens", "security");
                });

            modelBuilder.Entity("AlwasataNew.Models.Project", b =>
                {
                    b.HasOne("AlwasataNew.Models.Customer", "Customer")
                        .WithMany("Projects")
                        .HasForeignKey("CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("AlwasataNew.Models.ProjectDesignStages", b =>
                {
                    b.HasOne("AlwasataNew.Models.Project", null)
                        .WithOne()
                        .HasForeignKey("AlwasataNew.Models.ProjectDesignStages", "ProjectId")
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
                    b.HasOne("AlwasataNew.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("AlwasataNew.Models.ApplicationUser", null)
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

                    b.HasOne("AlwasataNew.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("AlwasataNew.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AlwasataNew.Models.Customer", b =>
                {
                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
