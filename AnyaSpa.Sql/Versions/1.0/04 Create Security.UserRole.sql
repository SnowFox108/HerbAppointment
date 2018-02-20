USE [AnyaSpa]
GO

/****** Object:  Table [Security].[UserRole]    Script Date: 20/02/2018 10:23:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Security].[UserRole](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_Security_UserRole] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [Security].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_Security_UserRole_Role] FOREIGN KEY([RoleId])
REFERENCES [Security].[Role] ([Id])
GO

ALTER TABLE [Security].[UserRole] CHECK CONSTRAINT [FK_Security_UserRole_Role]
GO

ALTER TABLE [Security].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_Security_UserRole_User] FOREIGN KEY([UserId])
REFERENCES [Security].[User] ([Id])
GO

ALTER TABLE [Security].[UserRole] CHECK CONSTRAINT [FK_Security_UserRole_User]
GO


