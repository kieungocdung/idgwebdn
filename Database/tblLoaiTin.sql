USE [vdc_com_vn]
GO
/****** Object:  Table [dbo].[tblLoaiTin]    Script Date: 07/09/2011 00:56:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblLoaiTin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Cha] [int] NULL,
	[ThuTu] [int] NULL,
	[NgayTao] [datetime] NULL,
	[IconLoaiTin] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[NguonTin] [int] NULL,
	[Lang] [nchar](5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TinhTrang] [bit] NULL,
 CONSTRAINT [PK_tblLoaiTin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nguon lay tin, VDC=0, VNPT=1, Khac=2' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'tblLoaiTin', @level2type=N'COLUMN', @level2name=N'NguonTin'

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

