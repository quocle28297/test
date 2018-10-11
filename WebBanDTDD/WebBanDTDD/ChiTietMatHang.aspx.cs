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
    public partial class ChiTietMatHang : System.Web.UI.Page
    {
        string connect = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\GitHub\test\WebBanDTDD\WebBanDTDD\App_Data\QLDTDD.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            if (Request.Cookies["tendangnhap"] == null) { this.Label1.Text = "Đăng Nhập Để Xem Chi Tiết"; return; }

            if (Context.Items["msp"] == null) return;
            string msp = Context.Items["msp"].ToString();
            int mahang =Int16.Parse(Context.Items["msp"].ToString());

            try
            {
                string query = "Select * from SANPHAM where MASP="+ mahang;
                SqlDataAdapter adt = new SqlDataAdapter(query,connect);
                DataTable dt= new DataTable();
                adt.Fill(dt);
                this.DataList2.DataSource = dt;
                this.DataList2.DataBind();

            }
            catch(SqlException ex)
            {
                Response.Write(ex.Message);
            }
        }

       

        protected void btnMua_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["tendangnhap"] == null)
            {
                Server.Transfer("MatHang.aspx");
                return;
            }
            Button mua = (Button)sender;
            string mahang = mua.CommandArgument.ToString();
            DataListItem item = (DataListItem)mua.Parent;
            int soluong = Convert.ToInt16(((TextBox)item.FindControl("txtSoLuong")).Text);
            if (Request.Cookies["tendangnhap"] == null) return;

            string ten = Request.Cookies["tendangnhap"].Value;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(connect);
                con.Open();
                string query = "Select * from HOADON where USERNAME='" + ten + "' and MASP=" + Convert.ToInt16(mahang);
                string queryInsert = "";
                SqlCommand command = new SqlCommand(query, con);
                SqlDataReader read = command.ExecuteReader();
                if (!read.Read())
                {
                    read.Close();
                    queryInsert = "Insert into HOADON(USERNAME,MASP,SOLUONG) Values('" + ten + "','" + Convert.ToInt16(mahang) + "'," +soluong + ")";
                    command = new SqlCommand(queryInsert, con);
                }
                else
                {
                    read.Close();
                    queryInsert = "Update HOADON set SOLUONG +="+Convert.ToInt16(soluong)+" WHERE USERNAME='"+ten+"' AND MASP="+mahang;
                    command = new SqlCommand(queryInsert, con);

                }
                command.ExecuteNonQuery();

                Server.Transfer("XoaSuaNhieu.aspx");
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
            finally { con.Close(); }
            


        }

        protected void DataList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Server.Transfer("GioHang.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Server.Transfer("XoaSua1.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Server.Transfer("XoaSuaNhieu.aspx");
        }
    }
}