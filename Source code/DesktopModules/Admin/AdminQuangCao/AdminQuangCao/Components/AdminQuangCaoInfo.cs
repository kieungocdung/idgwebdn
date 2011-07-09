using System;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;

namespace IDG.Dnn.AdminQuangCao.Components
{
    public class AdminQuangCaoInfo
    {
        public AdminQuangCaoInfo()
        {
        }
        private int _ID;
        private string _TieuDe;
        private string _MoTa;
        private string _URL_Image;
        private string _Links;
        private int _ThuTu;
        private DateTime _NgayKetThuc;
        private int _Vung;
        private bool _TrangThai;


        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string TieuDe
        {
            get { return _TieuDe; }
            set { _TieuDe = value; }
        }
        public string MoTa
        {
            get { return _MoTa; }
            set { _MoTa = value; }
        }
        public string URL_Image
        {
            get { return _URL_Image; }
            set { _URL_Image = value; }
        }
        public string Links
        {
            get { return _Links; }
            set { _Links = value; }
        }
        public int ThuTu
        {
            get { return _ThuTu; }
            set { _ThuTu = value; }
        }
        public DateTime NgayKetThuc
        {
            get { return _NgayKetThuc; }
            set { _NgayKetThuc = value; }
        }
        public int Vung
        {
            get { return _Vung; }
            set { _Vung = value; }
        }
        public bool TrangThai
        {
            get { return _TrangThai; }
            set { _TrangThai = value; }
        }
    }
}
