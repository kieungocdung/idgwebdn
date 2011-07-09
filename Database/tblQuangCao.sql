USE [vdc_com_vn]
GO
/****** Object:  Table [dbo].[tblQuangCao]    Script Date: 07/09/2011 00:59:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblQuangCao](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TieuDe] [nvarchar](80) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MoTa] [nvarchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[URL_Image] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Links] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ThuTu] [int] NULL,
	[NgayKetThuc] [datetime] NULL,
	[Vung] [int] NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_tblQuangCao] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
