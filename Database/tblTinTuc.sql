USE [vdc_com_vn]
GO
/****** Object:  Table [dbo].[tblTinTuc]    Script Date: 07/09/2011 00:57:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTinTuc](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LoaiTinID] [int] NOT NULL,
	[TieuDe] [nvarchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TomTat] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[NoiDung] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TacGia] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[NguoiTao] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Anh] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[NgayTao] [datetime] NULL,
	[LuotXem] [int] NULL,
	[NguonTin] [nvarchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[NoiBat] [bit] NULL CONSTRAINT [DF_tblTinTuc_NoiBat]  DEFAULT ((0)),
	[Lang] [nchar](5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TinhTrang] [bit] NULL CONSTRAINT [DF_tblTinTuc_TinhTrang]  DEFAULT ((1)),
 CONSTRAINT [PK_tblTinTuc] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
USE [vdc_com_vn]
GO
ALTER TABLE [dbo].[tblTinTuc]  WITH CHECK ADD  CONSTRAINT [FK_tblTinTuc_tblLoaiTin] FOREIGN KEY([LoaiTinID])
REFERENCES [dbo].[tblLoaiTin] ([ID])