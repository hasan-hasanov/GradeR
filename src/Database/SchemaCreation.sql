USE [master]

CREATE DATABASE [GradeR]
GO

USE [GradeR]
GO

CREATE TABLE [dbo].[Courses](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)) 

CREATE TABLE [dbo].[Grades](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[StudentGrade] [smallint] NOT NULL,
	[StudentId] [bigint] NULL,
	[TeacherId] [bigint] NULL,
	[CourseId] [bigint] NULL,
 CONSTRAINT [PK_Grades] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
))

CREATE TABLE [dbo].[Ranks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Ranks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
))

CREATE TABLE [dbo].[StudentCourse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [bigint] NULL,
	[CourseId] [bigint] NULL,
 CONSTRAINT [PK_StudentCourse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
))

CREATE TABLE [dbo].[Students](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](200) NOT NULL,
	[LastName] [nvarchar](200) NOT NULL,
	[BirthDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
))

CREATE TABLE [dbo].[TeacherCourse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeacherId] [bigint] NULL,
	[CourseId] [bigint] NULL,
 CONSTRAINT [PK_TeacherCourse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
))

CREATE TABLE [dbo].[Teachers](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](200) NOT NULL,
	[LastName] [nvarchar](200) NOT NULL,
	[BirthDate] [datetime2](7) NOT NULL,
	[RankId] [int] NULL,
 CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
))

CREATE NONCLUSTERED INDEX [IX_Grades_CourseId] ON [dbo].[Grades]
(
	[CourseId] ASC
)

CREATE NONCLUSTERED INDEX [IX_Grades_StudentId] ON [dbo].[Grades]
(
	[StudentId] ASC
)

CREATE NONCLUSTERED INDEX [IX_Grades_TeacherId] ON [dbo].[Grades]
(
	[TeacherId] ASC
)

CREATE NONCLUSTERED INDEX [IX_StudentCourse_CourseId] ON [dbo].[StudentCourse]
(
	[CourseId] ASC
)

CREATE NONCLUSTERED INDEX [IX_StudentCourse_StudentId] ON [dbo].[StudentCourse]
(
	[StudentId] ASC
)

CREATE NONCLUSTERED INDEX [IX_TeacherCourse_CourseId] ON [dbo].[TeacherCourse]
(
	[CourseId] ASC
)

CREATE NONCLUSTERED INDEX [IX_TeacherCourse_TeacherId] ON [dbo].[TeacherCourse]
(
	[TeacherId] ASC
)

CREATE NONCLUSTERED INDEX [IX_Teachers_RankId] ON [dbo].[Teachers]
(
	[RankId] ASC
)

ALTER TABLE [dbo].[Grades]  WITH CHECK ADD  CONSTRAINT [FK_Grades_Courses_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])

ALTER TABLE [dbo].[Grades] CHECK CONSTRAINT [FK_Grades_Courses_CourseId]

ALTER TABLE [dbo].[Grades]  WITH CHECK ADD  CONSTRAINT [FK_Grades_Students_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])

ALTER TABLE [dbo].[Grades] CHECK CONSTRAINT [FK_Grades_Students_StudentId]

ALTER TABLE [dbo].[Grades]  WITH CHECK ADD  CONSTRAINT [FK_Grades_Teachers_TeacherId] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teachers] ([Id])

ALTER TABLE [dbo].[Grades] CHECK CONSTRAINT [FK_Grades_Teachers_TeacherId]

ALTER TABLE [dbo].[StudentCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourse_Courses_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])

ALTER TABLE [dbo].[StudentCourse] CHECK CONSTRAINT [FK_StudentCourse_Courses_CourseId]

ALTER TABLE [dbo].[StudentCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourse_Students_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])

ALTER TABLE [dbo].[StudentCourse] CHECK CONSTRAINT [FK_StudentCourse_Students_StudentId]

ALTER TABLE [dbo].[TeacherCourse]  WITH CHECK ADD  CONSTRAINT [FK_TeacherCourse_Courses_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])

ALTER TABLE [dbo].[TeacherCourse] CHECK CONSTRAINT [FK_TeacherCourse_Courses_CourseId]

ALTER TABLE [dbo].[TeacherCourse]  WITH CHECK ADD  CONSTRAINT [FK_TeacherCourse_Teachers_TeacherId] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teachers] ([Id])

ALTER TABLE [dbo].[TeacherCourse] CHECK CONSTRAINT [FK_TeacherCourse_Teachers_TeacherId]

ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Ranks_RankId] FOREIGN KEY([RankId])
REFERENCES [dbo].[Ranks] ([Id])

ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Teachers_Ranks_RankId]
