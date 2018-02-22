USE [AnyaSpa]
GO

/****** Object:  Table [dbo].[Services]    Script Date: 22/02/2018 12:21:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Services](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ShopId] [int] NOT NULL,
	[TreatmentId] [int] NOT NULL,
	[Alias] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[DurationMinute] [int] NOT NULL,
	[Price] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


