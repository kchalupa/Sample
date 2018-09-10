USE [HeartMedicalCenter]
GO
/****** Object:  Table [dbo].[PatientHistory]    Script Date: 9/10/2018 1:26:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientHistory](
	[Id] [uniqueidentifier] NOT NULL,
	[Conditions] [nvarchar](127) NULL,
	[Medications] [nvarchar](127) NULL,
	[Allergies] [nvarchar](127) NULL,
	[Physicians] [nvarchar](127) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PatientHistory]  WITH CHECK ADD  CONSTRAINT [fk_heartmedicalcenter_appointments_id] FOREIGN KEY([Id])
REFERENCES [dbo].[Appointment] ([Id])
GO
ALTER TABLE [dbo].[PatientHistory] CHECK CONSTRAINT [fk_heartmedicalcenter_appointments_id]
GO
