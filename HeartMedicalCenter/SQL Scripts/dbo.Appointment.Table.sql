USE [HeartMedicalCenter]
GO
/****** Object:  Table [dbo].[Appointment]    Script Date: 9/10/2018 1:26:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointment](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](127) NOT NULL,
	[Address] [nvarchar](127) NOT NULL,
	[City] [nvarchar](127) NOT NULL,
	[State] [nvarchar](50) NOT NULL,
	[ZipCode] [nvarchar](25) NOT NULL,
	[HomePhone] [nvarchar](25) NOT NULL,
	[CellPhone] [nvarchar](25) NOT NULL,
	[AllowTextContact] [bit] NOT NULL,
	[PatientBirthDate] [date] NOT NULL,
	[IsNewPatient] [bit] NOT NULL,
	[InsuranceProvider] [nvarchar](127) NOT NULL,
	[MemberNumber] [nvarchar](50) NOT NULL,
	[AppointmentDate] [date] NOT NULL,
	[ReasonForAppointment] [nvarchar](127) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
