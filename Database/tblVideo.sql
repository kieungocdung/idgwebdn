USE [vdc_com_vn]
GO
/****** Object:  Table [dbo].[tblVideo]    Script Date: 07/09/2011 00:55:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVideo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenVideo] [nvarchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MoTa] [nvarchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VideoPath] [nvarchar](512) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_tblVideo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
