using System;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;

namespace IDG.Dnn.AdminTinTuc.Components
{
    public class AdminTinTucInfo
    {
        public AdminTinTucInfo()
        {
        }
        private int _ID;
        private int _LoaiTinID;
        private string _TieuDe;
        private string _TomTat;
        private string _NoiDung;
        private string _TacGia;
        private string _NguoiTao;
        private string _Anh;
        private DateTime _NgayTao;
        private int _LuotXem;
        private string _NguonTin;
        private bool _NoiBat;
        private string _Lang;
        private bool _TinhTrang;


        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public int LoaiTinID
        {
            get { return _LoaiTinID; }
            set { _LoaiTinID = value; }
        }
        public string TieuDe
        {
            get { return _TieuDe; }
            set { _TieuDe = value; }
        }
        public string TomTat
        {
            get { return _TomTat; }
            set { _TomTat = value; }
        }
        public string NoiDung
        {
            get { return _NoiDung; }
            set { _NoiDung = value; }
        }
        public string TacGia
        {
            get { return _TacGia; }
            set { _TacGia = value; }
        }
        public string NguoiTao
        {
            get { return _NguoiTao; }
            set { _NguoiTao = value; }
        }
        public string Anh
        {
            get { return _Anh; }
            set { _Anh = value; }
        }
        public DateTime NgayTao
        {
            get { return _NgayTao; }
            set { _NgayTao = value; }
        }
        public int LuotXem
        {
            get { return _LuotXem; }
            set { _LuotXem = value; }
        }
        public string NguonTin
        {
            get { return _NguonTin; }
            set { _NguonTin = value; }
        }
        public bool NoiBat
        {
            get { return _NoiBat; }
            set { _NoiBat = value; }
        }
        public string Lang
        {
            get { return _Lang; }
            set { _Lang = value; }
        }
        public bool TinhTrang
        {
            get { return _TinhTrang; }
            set { _TinhTrang = value; }
        }
    }
}
