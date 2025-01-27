USE [ETIQA_DB]
GO

/****** Object:  Table [dbo].[FreelancerSkills_Tbl]    Script Date: 01/24/2025 11:30:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FreelancerSkills_Tbl](
	[Id] [int] IDENTITY(100,1) NOT NULL,
	[SkillSet] [varchar](300) NULL,
	[Hobbies] [varchar](500) NULL,
	[Freelancer_User_Id] [int] NOT NULL,
 CONSTRAINT [PK_FreelancerSkills] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[FreelancerSkills_Tbl]  WITH CHECK ADD  CONSTRAINT [FK_FreelancerSkills_FreelancerSkills] FOREIGN KEY([Freelancer_User_Id])
REFERENCES [dbo].[FreeLancers_Tbl] ([UserId])
GO

ALTER TABLE [dbo].[FreelancerSkills_Tbl] CHECK CONSTRAINT [FK_FreelancerSkills_FreelancerSkills]
GO


