using System;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;

namespace IDG.Dnn.AdminSideLinks.Components
{
    public class AdminSideLinksInfo
    {
        public AdminSideLinksInfo()
	 {
	 }
	 private int _ID ;
	 private int _SlideHome ;
	 private string _TieuDe ;
	 private string _Link ;
 

	 public int ID
	 {
	    get { return _ID ; }
	    set { _ID = value ; }
	 }
	 public int SlideHome
	 {
	    get { return _SlideHome ; }
	    set { _SlideHome = value ; }
	 }
	 public string TieuDe
	 {
	    get { return _TieuDe ; }
	    set { _TieuDe = value ; }
	 }
	 public string Link
	 {
	    get { return _Link ; }
	    set { _Link = value ; }
	 }
    }
}
