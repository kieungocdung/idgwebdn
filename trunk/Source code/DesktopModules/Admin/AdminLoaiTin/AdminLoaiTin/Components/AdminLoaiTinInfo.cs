using System;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;

namespace IDG.Dnn.AdminLoaiTin.Components
{
    public class AdminLoaiTinInfo
    {
        public AdminLoaiTinInfo()
	 {
	 }
	 private int _ID ;
	 private string _Ten ;
	 private int _Cha ;
	 private int _ThuTu ;
	 private DateTime _NgayTao ;
	 private string _IconLoaiTin ;
	 private int _NguonTin ;
	 private string _Lang ;
	 private bool _TinhTrang ;
 

	 public int ID
	 {
	    get { return _ID ; }
	    set { _ID = value ; }
	 }
	 public string Ten
	 {
	    get { return _Ten ; }
	    set { _Ten = value ; }
	 }
	 public int Cha
	 {
	    get { return _Cha ; }
	    set { _Cha = value ; }
	 }
	 public int ThuTu
	 {
	    get { return _ThuTu ; }
	    set { _ThuTu = value ; }
	 }
	 public DateTime NgayTao
	 {
	    get { return _NgayTao ; }
	    set { _NgayTao = value ; }
	 }
	 public string IconLoaiTin
	 {
	    get { return _IconLoaiTin ; }
	    set { _IconLoaiTin = value ; }
	 }
	 public int NguonTin
	 {
	    get { return _NguonTin ; }
	    set { _NguonTin = value ; }
	 }
	 public string Lang
	 {
	    get { return _Lang ; }
	    set { _Lang = value ; }
	 }
	 public bool TinhTrang
	 {
	    get { return _TinhTrang ; }
	    set { _TinhTrang = value ; }
	 }
    }
}
