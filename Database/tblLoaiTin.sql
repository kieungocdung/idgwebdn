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
