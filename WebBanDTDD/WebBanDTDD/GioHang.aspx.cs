using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBanDTDD
{
    public partial class GioHang : System.Web.UI.Page
    {
        string connect = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\STUDY\ASP_webform\WebBanDTDD\WebBanDTDD\App_Data\QLDTDD.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            if (Request.Cookies["tendangnhap"] == null)
            {
                this.lblThanhTien.Text = "Đăng Nhập Để Xem Giỏ Hàng";
                Server.Transfer("MatHang.aspx");
                return;
            }
            string ten = Request.Cookies["tendangnhap"].Value;
            try
            {
                string query = "select h.MASP as N'Mã Sản Phẩm', s.TENSP as N'Tên Sản Phẩm', s.MOTA as N'Mô Tả', s.DONGIA as N'Đơn Giá',h.SOLUONG as N'Số Lượng', (h.SOLUONG*s.DONGIA) as thanhtien from SANPHAM as s,HOADON as h where s.MASP=h.MASP and h.USERNAME like '"+ten+"'";
                SqlDataAdapter adt = new SqlDataAdapter(query,connect);
                DataTable dt = new DataTable();
                adt.Fill(dt);
                this.GridView1.DataSource = dt;
                this.GridView1.DataBind();
                // tính tổng tiền
                double tongtien = 0;
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    double thanhtien = Convert.ToDouble(dt.Rows[i]["thanhtien"]);
                    tongtien += thanhtien;
                }
                this.lblThanhTien.Text = "Tổng tiền hàng: "+tongtien+" VND";
            }
            catch(SqlException ex) { Response.Write(ex.Message); }
        }
    }
}