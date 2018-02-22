USE [AnyaSpa]
GO

/****** Object:  Table [dbo].[Treatments]    Script Date: 22/02/2018 11:53:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Treatments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TreatmentType] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[DurationMinute] [int] NOT NULL,
 CONSTRAINT [PK_Treatments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


