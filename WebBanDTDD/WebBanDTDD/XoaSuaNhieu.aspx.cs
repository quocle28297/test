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
    public partial class XoaSuaNhieu : System.Web.UI.Page
    {
        string connect = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\STUDY\ASP_webform\WebBanDTDD\WebBanDTDD\App_Data\QLDTDD.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            if (Request.Cookies["tendangnhap"] == null)
            {
                this.lblTongTien.Text = "Đăng Nhập Để Xem Giỏ Hàng";
                Server.Transfer("MatHang.aspx");
                return;
            }
            this.readData();
        }

        private void readData()
        {
            try
            {
                string ten = Request.Cookies["tendangnhap"].Value;
                string query = "select h.MASP, s.TENSP, s.MOTA, s.DONGIA ,h.SOLUONG , (h.SOLUONG*s.DONGIA) as THANHTIEN from SANPHAM as s,HOADON as h where s.MASP=h.MASP and h.USERNAME like '" + ten + "'";
                SqlDataAdapter adt = new SqlDataAdapter(query, connect);
                DataTable dt = new DataTable();
                adt.Fill(dt);
                this.GridView1.DataSource = dt;
                this.GridView1.DataBind();
                // tính tổng tiền
                double tongtien = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    double thanhtien = Convert.ToDouble(dt.Rows[i]["thanhtien"]);
                    tongtien += thanhtien;
                }
                this.lblTongTien.Text = "Tổng tiền hàng: " + tongtien + " VND";
            }
            catch (SqlException ex) { Response.Write(ex.Message); }
        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            
            if (Request.Cookies["tendangnhap"] == null)
            {
                this.lblTongTien.Text = "Đăng Nhập Để Xem Giỏ Hàng";
                Server.Transfer("MatHang.aspx");
                return;
            }
            string ten = Request.Cookies["tendangnhap"].Value;

            foreach (GridViewRow row in GridView1.Rows)
            {
                if (((CheckBox)row.FindControl("CheckBox1")).Checked)
                {
                    string mahang = ((HiddenField)row.FindControl("HiddenField1")).Value;
                    int soluong = Convert.ToInt16(((TextBox)row.FindControl("TextBox1")).Text);
                    string query = "UPDATE HOADON set SOLUONG =" + Convert.ToInt32(soluong) + " where MASP=" + Convert.ToInt16(mahang) + " AND USERNAME='" + ten + "'";
                    SqlConnection con = new SqlConnection(connect);
                    try
                    {
                        con.Open();
                        SqlCommand command = new SqlCommand(query, con);
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex) { Response.Write(ex.Message); }
                    finally { con.Close(); }
                    this.readData();
                }
            }


        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["tendangnhap"] == null)
            {
                this.lblTongTien.Text = "Đăng Nhập Để Xem Giỏ Hàng";
                Server.Transfer("MatHang.aspx");
                return;
            }

            string ten = Request.Cookies["tendangnhap"].Value;
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (((CheckBox)row.FindControl("CheckBox1")).Checked)
                {
                    string mahang = ((HiddenField)row.FindControl("HiddenField1")).Value;
                    string query = "Delete FROM HOADON where MASP=" + Convert.ToInt16(mahang) + " AND USERNAME='" + ten + "'";
                    SqlConnection con = new SqlConnection(connect);
                    try
                    {
                        con.Open();
                        SqlCommand command = new SqlCommand(query, con);
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex) { Response.Write(ex.Message); }
                    finally { con.Close(); }
                    this.readData();
                }
            }
        }
    }
}