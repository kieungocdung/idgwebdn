USE [vdc_com_vn]
GO
/****** Object:  Table [dbo].[tblSlideLink]    Script Date: 07/09/2011 00:58:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSlideLink](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SlideHome] [int] NULL,
	[TieuDe] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Link] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_tblSlideLink] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
USE [vdc_com_vn]
GO
ALTER TABLE [dbo].[tblSlideLink]  WITH CHECK ADD  CONSTRAINT [FK_tblSlideLink_tblSlideHome] FOREIGN KEY([SlideHome])
REFERENCES [dbo].[tblSlideHome] ([ID])