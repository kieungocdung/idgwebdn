using System;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;

namespace IDG.Dnn.AdminVideo.Components
{
    public class AdminVideoInfo
    {
        public AdminVideoInfo()
	 {
	 }
	 private int _ID ;
	 private string _TenVideo ;
	 private string _MoTa ;
	 private string _VideoPath ;
	 private bool _TrangThai ;
 

	 public int ID
	 {
	    get { return _ID ; }
	    set { _ID = value ; }
	 }
	 public string TenVideo
	 {
	    get { return _TenVideo ; }
	    set { _TenVideo = value ; }
	 }
	 public string MoTa
	 {
	    get { return _MoTa ; }
	    set { _MoTa = value ; }
	 }
	 public string VideoPath
	 {
	    get { return _VideoPath ; }
	    set { _VideoPath = value ; }
	 }
	 public bool TrangThai
	 {
	    get { return _TrangThai ; }
	    set { _TrangThai = value ; }
	 }
    }
}
