using System;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;

namespace IDG.Dnn.AdminSideHome.Components
{
    public class AdminSideHomeInfo
    {
        public AdminSideHomeInfo()
	 {
	 }
	 private int _ID ;
	 private string _Anh ;
	 private string _Tieude ;
	 private bool _TrangThai ;
 

	 public int ID
	 {
	    get { return _ID ; }
	    set { _ID = value ; }
	 }
	 public string Anh
	 {
	    get { return _Anh ; }
	    set { _Anh = value ; }
	 }
	 public string Tieude
	 {
	    get { return _Tieude ; }
	    set { _Tieude = value ; }
	 }
	 public bool TrangThai
	 {
	    get { return _TrangThai ; }
	    set { _TrangThai = value ; }
	 }
    }
}
