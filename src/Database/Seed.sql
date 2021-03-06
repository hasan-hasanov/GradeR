USE [GradeR]

SET IDENTITY_INSERT [dbo].[Courses] ON 
INSERT [dbo].[Courses] ([Id], [Name], [StartDate], [EndDate]) VALUES (1, N'C# Programming Basics', CAST(N'2020-03-11T00:00:00.0000000' AS DateTime2), CAST(N'2020-08-11T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Courses] ([Id], [Name], [StartDate], [EndDate]) VALUES (2, N'C# Programming Advanced', CAST(N'2020-03-11T00:00:00.0000000' AS DateTime2), CAST(N'2020-08-11T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Courses] ([Id], [Name], [StartDate], [EndDate]) VALUES (3, N'Java Programming Basics', CAST(N'2021-03-11T00:00:00.0000000' AS DateTime2), CAST(N'2021-08-11T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Courses] ([Id], [Name], [StartDate], [EndDate]) VALUES (4, N'Java Programming Advanced', CAST(N'2021-03-11T00:00:00.0000000' AS DateTime2), CAST(N'2021-08-11T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Courses] OFF

SET IDENTITY_INSERT [dbo].[Students] ON 
INSERT [dbo].[Students] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (1, N'Hasan', N'Hasanov', CAST(N'1993-09-22T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Students] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (2, N'Krasimir', N'Atanasov', CAST(N'1990-10-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Students] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (3, N'Martin', N'Bozhilov', CAST(N'1989-12-11T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Students] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (4, N'Tonicha', N'Madden', CAST(N'1985-05-06T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Students] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (5, N'Juno', N'Medina', CAST(N'1958-09-18T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Students] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (6, N'Elizabeth', N'Thompson', CAST(N'1994-10-14T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Students] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (7, N'Carla', N'Riojas', CAST(N'1993-01-09T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Students] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (8, N'Eric', N'Duffin', CAST(N'1963-11-13T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Students] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (9, N'Mareen', N'Whelchel', CAST(N'1987-04-17T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Students] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (10, N'Linda', N'Braun', CAST(N'1979-09-03T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Students] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (11, N'Steve', N'Payne', CAST(N'1960-02-10T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Students] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (12, N'Angelo', N'Crawford', CAST(N'1961-04-08T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Students] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (13, N'Michael', N'Kurtz', CAST(N'1974-12-22T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Students] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (14, N'Toni', N'Franklin', CAST(N'1993-09-20T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Students] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (15, N'Wilma', N'Goodson', CAST(N'1989-02-23T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Students] OFF

SET IDENTITY_INSERT [dbo].[Ranks] ON 
INSERT [dbo].[Ranks] ([Id], [Name]) VALUES (1, N'Assistant Professor')
INSERT [dbo].[Ranks] ([Id], [Name]) VALUES (2, N'Senior Assistant Professor')
INSERT [dbo].[Ranks] ([Id], [Name]) VALUES (3, N'Aossociate Professor')
INSERT [dbo].[Ranks] ([Id], [Name]) VALUES (4, N'Professor')
SET IDENTITY_INSERT [dbo].[Ranks] OFF

SET IDENTITY_INSERT [dbo].[Teachers] ON 
INSERT [dbo].[Teachers] ([Id], [FirstName], [LastName], [BirthDate], [RankId]) VALUES (1, N'George', N'Withrow', CAST(N'1963-10-16T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Teachers] ([Id], [FirstName], [LastName], [BirthDate], [RankId]) VALUES (2, N'Teresa', N'Reel', CAST(N'1980-03-31T00:00:00.0000000' AS DateTime2), 4)
INSERT [dbo].[Teachers] ([Id], [FirstName], [LastName], [BirthDate], [RankId]) VALUES (3, N'Nancy', N'Flinn', CAST(N'1985-09-04T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[Teachers] ([Id], [FirstName], [LastName], [BirthDate], [RankId]) VALUES (4, N'Tara', N'Stanley', CAST(N'1957-11-19T00:00:00.0000000' AS DateTime2), 4)
SET IDENTITY_INSERT [dbo].[Teachers] OFF

SET IDENTITY_INSERT [dbo].[Grades] ON 
INSERT [dbo].[Grades] ([Id], [StudentGrade], [StudentId], [TeacherId], [CourseId]) VALUES (1, 78, 1, 1, 1)
INSERT [dbo].[Grades] ([Id], [StudentGrade], [StudentId], [TeacherId], [CourseId]) VALUES (2, 99, 2, 1, 1)
INSERT [dbo].[Grades] ([Id], [StudentGrade], [StudentId], [TeacherId], [CourseId]) VALUES (3, 37, 3, 1, 1)
INSERT [dbo].[Grades] ([Id], [StudentGrade], [StudentId], [TeacherId], [CourseId]) VALUES (4, 87, 4, 1, 1)
INSERT [dbo].[Grades] ([Id], [StudentGrade], [StudentId], [TeacherId], [CourseId]) VALUES (5, 68, 5, 1, 1)
INSERT [dbo].[Grades] ([Id], [StudentGrade], [StudentId], [TeacherId], [CourseId]) VALUES (6, 78, 1, 2, 2)
INSERT [dbo].[Grades] ([Id], [StudentGrade], [StudentId], [TeacherId], [CourseId]) VALUES (7, 98, 2, 2, 2)
INSERT [dbo].[Grades] ([Id], [StudentGrade], [StudentId], [TeacherId], [CourseId]) VALUES (9, 77, 6, 2, 2)
INSERT [dbo].[Grades] ([Id], [StudentGrade], [StudentId], [TeacherId], [CourseId]) VALUES (10, 43, 7, 2, 2)
INSERT [dbo].[Grades] ([Id], [StudentGrade], [StudentId], [TeacherId], [CourseId]) VALUES (11, 17, 8, 2, 2)
SET IDENTITY_INSERT [dbo].[Grades] OFF

SET IDENTITY_INSERT [dbo].[StudentCourse] ON 
INSERT [dbo].[StudentCourse] ([Id], [StudentId], [CourseId]) VALUES (1, 1, 1)
INSERT [dbo].[StudentCourse] ([Id], [StudentId], [CourseId]) VALUES (2, 2, 1)
INSERT [dbo].[StudentCourse] ([Id], [StudentId], [CourseId]) VALUES (3, 3, 1)
INSERT [dbo].[StudentCourse] ([Id], [StudentId], [CourseId]) VALUES (4, 4, 1)
INSERT [dbo].[StudentCourse] ([Id], [StudentId], [CourseId]) VALUES (5, 5, 1)
INSERT [dbo].[StudentCourse] ([Id], [StudentId], [CourseId]) VALUES (6, 1, 2)
INSERT [dbo].[StudentCourse] ([Id], [StudentId], [CourseId]) VALUES (7, 2, 2)
INSERT [dbo].[StudentCourse] ([Id], [StudentId], [CourseId]) VALUES (8, 6, 2)
INSERT [dbo].[StudentCourse] ([Id], [StudentId], [CourseId]) VALUES (9, 7, 2)
INSERT [dbo].[StudentCourse] ([Id], [StudentId], [CourseId]) VALUES (10, 8, 2)
INSERT [dbo].[StudentCourse] ([Id], [StudentId], [CourseId]) VALUES (11, 9, 3)
INSERT [dbo].[StudentCourse] ([Id], [StudentId], [CourseId]) VALUES (12, 10, 3)
INSERT [dbo].[StudentCourse] ([Id], [StudentId], [CourseId]) VALUES (13, 11, 3)
INSERT [dbo].[StudentCourse] ([Id], [StudentId], [CourseId]) VALUES (14, 12, 3)
INSERT [dbo].[StudentCourse] ([Id], [StudentId], [CourseId]) VALUES (15, 13, 3)
INSERT [dbo].[StudentCourse] ([Id], [StudentId], [CourseId]) VALUES (16, 14, 4)
INSERT [dbo].[StudentCourse] ([Id], [StudentId], [CourseId]) VALUES (18, 15, 4)
INSERT [dbo].[StudentCourse] ([Id], [StudentId], [CourseId]) VALUES (19, 10, 4)
INSERT [dbo].[StudentCourse] ([Id], [StudentId], [CourseId]) VALUES (20, 11, 4)
INSERT [dbo].[StudentCourse] ([Id], [StudentId], [CourseId]) VALUES (21, 12, 4)
SET IDENTITY_INSERT [dbo].[StudentCourse] OFF

SET IDENTITY_INSERT [dbo].[TeacherCourse] ON 
INSERT [dbo].[TeacherCourse] ([Id], [TeacherId], [CourseId]) VALUES (1, 1, 1)
INSERT [dbo].[TeacherCourse] ([Id], [TeacherId], [CourseId]) VALUES (2, 2, 2)
INSERT [dbo].[TeacherCourse] ([Id], [TeacherId], [CourseId]) VALUES (3, 3, 3)
INSERT [dbo].[TeacherCourse] ([Id], [TeacherId], [CourseId]) VALUES (4, 4, 4)
SET IDENTITY_INSERT [dbo].[TeacherCourse] OFF