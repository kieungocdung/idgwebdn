using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI.WebControls;


using System.Web.UI;
using System.IO;
using System.Data;

using System.Security.Cryptography;
using System.Text;
using System.Reflection;

namespace IDG.Dnn.AdminTinTuc
{

    public class Common
    {


        public static bool UploadImage(FileUpload ful, string root, string folderContain, ref string url)
        {
            bool ret = false;
            DateTime dt = DateTime.Now;
            string fileName = dt.Year.ToString() + dt.Month.ToString() + dt.Day.ToString() + dt.Hour.ToString() + dt.Minute.ToString() + dt.Second.ToString() + dt.Millisecond.ToString();

            url = folderContain + fileName + Path.GetExtension(ful.FileName);
            try
            {
                ful.SaveAs(root + url);
                ret = true;
            }
            catch
            {
                ret = false;
            }
            //TODO: Upload image lên folderContain

            return ret;
        }

        public static bool CheckContainImage(FileUpload ful)
        {
            //TODO: Kiem tra anh xem ng dùng có chọn ko?
            if (ful.HasFile)
                return true;
            else return false;
        }

        public static bool CheckExistImage(string url)
        {
            bool ret = false;
            try
            {
                //TODO: Kiem tra anh xem ng dùng có chọn ko?
                ret = File.Exists(url);
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public static bool DeleteImage(string url)
        {
            //TODO: Kiem tra anh xem ng dùng có chọn ko?
            try
            {
                File.Delete(url);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Hàm cắt chuỗi
        /// </summary>
        /// <param name="_strInput">Chuỗi đầu vào</param>
        /// <param name="_lenght">Số phần tử muốn lấy</param>
        /// <returns>Chuỗi được cắt đi tới _lenght kí tự</returns>
        public static string CutString(string _strInput, int _lenght)
        {
            string _ret = _strInput;
            if (_ret.Length > _lenght)
            {
                string ret = _strInput.Substring(0, _lenght);
                int temp = ret.LastIndexOf(" ");
                _ret = ret.Substring(0, temp) + " ...";

            }
            return _ret;
        }

        /// <summary>
        /// Remove HTML tags from string using char array.
        /// </summary>
        public static string StripTagsCharArray(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }
    }
}