﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(GradeRContext))]
    partial class GradeRContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Entities.Course", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            EndDate = new DateTime(2020, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "C# Programming Basics",
                            StartDate = new DateTime(2020, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2L,
                            EndDate = new DateTime(2020, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "C# Programming Advanced",
                            StartDate = new DateTime(2020, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3L,
                            EndDate = new DateTime(2021, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Java Programming Basics",
                            StartDate = new DateTime(2021, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4L,
                            EndDate = new DateTime(2021, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Java Programming Advanced",
                            StartDate = new DateTime(2021, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Core.Entities.Grade", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<short>("StudentGrade")
                        .HasColumnType("smallint");

                    b.Property<long>("StudentId")
                        .HasColumnType("bigint");

                    b.Property<long>("TeacherId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Grades");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CourseId = 1L,
                            StudentGrade = (short)78,
                            StudentId = 1L,
                            TeacherId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            CourseId = 1L,
                            StudentGrade = (short)99,
                            StudentId = 2L,
                            TeacherId = 1L
                        },
                        new
                        {
                            Id = 3L,
                            CourseId = 1L,
                            StudentGrade = (short)37,
                            StudentId = 3L,
                            TeacherId = 1L
                        },
                        new
                        {
                            Id = 4L,
                            CourseId = 1L,
                            StudentGrade = (short)87,
                            StudentId = 4L,
                            TeacherId = 1L
                        },
                        new
                        {
                            Id = 5L,
                            CourseId = 1L,
                            StudentGrade = (short)68,
                            StudentId = 5L,
                            TeacherId = 1L
                        },
                        new
                        {
                            Id = 6L,
                            CourseId = 2L,
                            StudentGrade = (short)78,
                            StudentId = 1L,
                            TeacherId = 2L
                        },
                        new
                        {
                            Id = 7L,
                            CourseId = 2L,
                            StudentGrade = (short)98,
                            StudentId = 2L,
                            TeacherId = 2L
                        },
                        new
                        {
                            Id = 8L,
                            CourseId = 2L,
                            StudentGrade = (short)77,
                            StudentId = 6L,
                            TeacherId = 2L
                        },
                        new
                        {
                            Id = 9L,
                            CourseId = 2L,
                            StudentGrade = (short)43,
                            StudentId = 7L,
                            TeacherId = 2L
                        },
                        new
                        {
                            Id = 10L,
                            CourseId = 2L,
                            StudentGrade = (short)17,
                            StudentId = 8L,
                            TeacherId = 2L
                        });
                });

            modelBuilder.Entity("Core.Entities.Rank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Ranks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Assistant Professor"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Senior Assistant Professor"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Associate Professor"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Professor"
                        });
                });

            modelBuilder.Entity("Core.Entities.Student", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            BirthDate = new DateTime(1993, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Hasan",
                            LastName = "Hasanov"
                        },
                        new
                        {
                            Id = 2L,
                            BirthDate = new DateTime(1990, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Krasimir",
                            LastName = "Atanasov"
                        },
                        new
                        {
                            Id = 3L,
                            BirthDate = new DateTime(1989, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Martin",
                            LastName = "Bozhilov"
                        },
                        new
                        {
                            Id = 4L,
                            BirthDate = new DateTime(1985, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Tonicha",
                            LastName = "Medina"
                        },
                        new
                        {
                            Id = 5L,
                            BirthDate = new DateTime(1958, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Juno",
                            LastName = "Thompson"
                        },
                        new
                        {
                            Id = 6L,
                            BirthDate = new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Elizabeth",
                            LastName = "Riojas"
                        },
                        new
                        {
                            Id = 7L,
                            BirthDate = new DateTime(1993, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Carla",
                            LastName = "Duffin"
                        },
                        new
                        {
                            Id = 8L,
                            BirthDate = new DateTime(1963, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Eric",
                            LastName = "Whelchel"
                        },
                        new
                        {
                            Id = 9L,
                            BirthDate = new DateTime(1987, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Mareen",
                            LastName = "Braun"
                        },
                        new
                        {
                            Id = 10L,
                            BirthDate = new DateTime(1979, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Linda",
                            LastName = "Payne"
                        },
                        new
                        {
                            Id = 11L,
                            BirthDate = new DateTime(1960, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Steve",
                            LastName = "Crawford"
                        },
                        new
                        {
                            Id = 12L,
                            BirthDate = new DateTime(1961, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Angelo",
                            LastName = "Kurtz"
                        },
                        new
                        {
                            Id = 13L,
                            BirthDate = new DateTime(1974, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Michael",
                            LastName = "Franklin"
                        },
                        new
                        {
                            Id = 14L,
                            BirthDate = new DateTime(1993, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Toni",
                            LastName = "Goodson"
                        },
                        new
                        {
                            Id = 15L,
                            BirthDate = new DateTime(1989, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Wilma",
                            LastName = "Madden"
                        });
                });

            modelBuilder.Entity("Core.Entities.StudentCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<long>("StudentId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentCourse");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseId = 1L,
                            StudentId = 1L
                        },
                        new
                        {
                            Id = 2,
                            CourseId = 1L,
                            StudentId = 2L
                        },
                        new
                        {
                            Id = 3,
                            CourseId = 1L,
                            StudentId = 3L
                        },
                        new
                        {
                            Id = 4,
                            CourseId = 1L,
                            StudentId = 4L
                        },
                        new
                        {
                            Id = 5,
                            CourseId = 1L,
                            StudentId = 5L
                        },
                        new
                        {
                            Id = 6,
                            CourseId = 2L,
                            StudentId = 1L
                        },
                        new
                        {
                            Id = 7,
                            CourseId = 2L,
                            StudentId = 2L
                        },
                        new
                        {
                            Id = 8,
                            CourseId = 2L,
                            StudentId = 6L
                        },
                        new
                        {
                            Id = 9,
                            CourseId = 2L,
                            StudentId = 7L
                        },
                        new
                        {
                            Id = 10,
                            CourseId = 2L,
                            StudentId = 8L
                        },
                        new
                        {
                            Id = 11,
                            CourseId = 3L,
                            StudentId = 9L
                        },
                        new
                        {
                            Id = 12,
                            CourseId = 3L,
                            StudentId = 10L
                        },
                        new
                        {
                            Id = 13,
                            CourseId = 3L,
                            StudentId = 11L
                        },
                        new
                        {
                            Id = 14,
                            CourseId = 3L,
                            StudentId = 12L
                        },
                        new
                        {
                            Id = 15,
                            CourseId = 3L,
                            StudentId = 13L
                        },
                        new
                        {
                            Id = 16,
                            CourseId = 4L,
                            StudentId = 14L
                        },
                        new
                        {
                            Id = 17,
                            CourseId = 4L,
                            StudentId = 15L
                        },
                        new
                        {
                            Id = 18,
                            CourseId = 4L,
                            StudentId = 10L
                        },
                        new
                        {
                            Id = 19,
                            CourseId = 4L,
                            StudentId = 11L
                        },
                        new
                        {
                            Id = 20,
                            CourseId = 4L,
                            StudentId = 12L
                        });
                });

            modelBuilder.Entity("Core.Entities.Teacher", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<int>("RankId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RankId");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            BirthDate = new DateTime(1963, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "George",
                            LastName = "Withrow",
                            RankId = 1
                        },
                        new
                        {
                            Id = 2L,
                            BirthDate = new DateTime(1980, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Teresa",
                            LastName = "Reel",
                            RankId = 4
                        },
                        new
                        {
                            Id = 3L,
                            BirthDate = new DateTime(1985, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Nancy",
                            LastName = "Flinn",
                            RankId = 2
                        },
                        new
                        {
                            Id = 4L,
                            BirthDate = new DateTime(1957, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Tara",
                            LastName = "Stanley",
                            RankId = 4
                        });
                });

            modelBuilder.Entity("Core.Entities.TeacherCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<long>("TeacherId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherCourse");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseId = 1L,
                            TeacherId = 1L
                        },
                        new
                        {
                            Id = 2,
                            CourseId = 2L,
                            TeacherId = 2L
                        },
                        new
                        {
                            Id = 3,
                            CourseId = 3L,
                            TeacherId = 3L
                        },
                        new
                        {
                            Id = 4,
                            CourseId = 4L,
                            TeacherId = 4L
                        });
                });

            modelBuilder.Entity("Core.Entities.Grade", b =>
                {
                    b.HasOne("Core.Entities.Course", "Course")
                        .WithMany("Grades")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Teacher", "Teacher")
                        .WithMany("Grades")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.StudentCourse", b =>
                {
                    b.HasOne("Core.Entities.Course", "Course")
                        .WithMany("Students")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Student", "Student")
                        .WithMany("Courses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.Teacher", b =>
                {
                    b.HasOne("Core.Entities.Rank", "Rank")
                        .WithMany("Teachers")
                        .HasForeignKey("RankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.TeacherCourse", b =>
                {
                    b.HasOne("Core.Entities.Course", "Course")
                        .WithMany("Teachers")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Teacher", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
