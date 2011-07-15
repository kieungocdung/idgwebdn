<%@ Control Language="C#" AutoEventWireup="true" Codebehind="View.ascx.cs" Inherits="IDG.Dnn.DetailTinTuc.View" %>
<link href="/DesktopModules/Trangchitiet/Style.css" rel="stylesheet" type="text/css" />
<div class="chitiet">
    <div class="mail_chitiet">
        <h3>
            Hướng dẫn thiết kế module dotnetnuke</h3>
        Ngày đăng: 31/05/2011 Lượt xem:766 Share:Google BookmarksFacebook
        <p>
            Hiển thị n ký tự đầu tiên của chuỗi mà không cắt từ nửa chừng của một từ nào là
            một yêu cầu phổ biến, nhưng nếu đúng ký tự thứ n lại là ký tự nằm giữa 1 từ nào
            đó thì sao?. Bài viết này minh họa cho bạn cách giải quyết vấn đề này. Khi lướt
            web nếu để ý bạn sẽ thấy một số trang hoặc diễn đàn có tiêu đề bài viết quá dài
            và họ không muốn trình bày tiêu đề bài đó thành nhiều hơn 1 dòng, và tiêu đề bài
            đó được cắt n ký tự đầu (giả sử 200) nhưng nếu đúng ký tự thứ 200 lại là ký tự nằm
            giữa 1 từ nào đó, như vậy nếu không giải quyết vấn đề thì số ký tự ta cắt sẽ có
            từ cuỗi không có ý nghĩa.<br />
            Bạn tham khảo code sau đây để áp dụng: using System; using System.Collections; using
            System.Configuration; using System.Data; using System.Linq; using System.Web; using
            System.Web.Security; using System.Web.UI; using System.Web.UI.HtmlControls; using
            System.Web.UI.WebControls; using System.Web.UI.WebControls.WebParts; using System.Xml.Linq;
            using System.Text;
            <br />
            public partial class Default2 : System.Web.UI.Page { protected void Page_Load(object
            sender, EventArgs e) { string str1 = @"Với tinh thần chia sẻ, giao lưu và học hỏi
            với các bạn tôi lập website hmweb Chia sẻ là niềm vui. Chia sẻ những gì có thể cũng
            là một phần trong những sở thích của tôi. Tôi hy vọng qua hmweb bạn có thể tìm kiếm
            được những thông tin hữu ích cho các bạn"; string str2 = str1.CatChuoi(30); } }
            public static class StringExtensions { /// public static string CatChuoi(this string
            s, int length) { if (String.IsNullOrEmpty(s)) throw new ArgumentNullException(s);
            var words = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); if (words[0].Length
            > length)<br />
            throw new ArgumentException("Từ đầu tiên dài hơn chuỗi cần cắt"); var sb = new StringBuilder();
            foreach (var word in words) { if ((sb + word).Length > length) return string.Format("{0}...",
            sb.ToString().TrimEnd(' ')); sb.Append(word + " "); } return string.Format("{0}...",
            sb.ToString().TrimEnd(' ')); } } Giải thích qua về phương pháp trên ta thấy có 2
            tham số đầu vào là chuỗi đầu vào s và length là số ký tự tối
            <br />
            ta ta sẽ cắt (Tối đa nghĩa là nếu ký tự thứ length là khoảng trắng thí chuỗi cắt
            được có độ dài là length ngược lại sẽ lấy đến khoảng trắng cuối cũng trước length
            ).<br />
            Chúng ta sử dụng String.Split để chia chuỗi ra mảng phân cách bởi khoảng trắng và
            StringSplitOptions.RemoveEmptyEntries xử lý trường hợp giửa các từ có nhiều hơn
            1 dấu cách, sau đó ta dùng vòng lặp foreach để tiến hành cắt chuỗi</p>
        <div class="video">
        </div>
        <ul>
            <li>Gửi tin nhắn</li>
            <li>Chia sẻ</li>
            <li>Download soure</li>
            <li>Download video chat lượng</li>
        </ul>
    </div>
    <div class="listchitiet">
        <h4>
            Các bài viết liên quan</h4>
        <ul>
            <li><a href="#">Skin cho ban5.6.7 co nhung gi dac biet</a></li>
            <li><a href="#">Skin cho ban5.6.7 co nhung gi dac biet</a></li>
            <li><a href="#">Skin cho ban5.6.7 co nhung gi dac biet</a></li>
            <li><a href="#">Skin cho ban5.6.7 co nhung gi dac biet</a></li>
            <li><a href="#">Skin cho ban5.6.7 co nhung gi dac biet</a></li>
            <li><a href="#">Skin cho ban5.6.7 co nhung gi dac biet</a></li>
        </ul>
    </div>
</div>
