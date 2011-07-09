USE [vdc_com_vn]
GO
/****** Object:  Table [dbo].[tblSlideHome]    Script Date: 07/09/2011 00:58:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSlideHome](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Anh] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Tieude] [nchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TrangThai] [bit] NULL CONSTRAINT [DF_tblSlideHome_TrangThai]  DEFAULT ((1)),
 CONSTRAINT [PK_tblSlideHome] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
