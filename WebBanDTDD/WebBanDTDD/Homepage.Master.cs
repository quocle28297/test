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
    public partial class Homepage : System.Web.UI.MasterPage
    {
        string connect = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\STUDY\ASP_webform\WebBanDTDD\WebBanDTDD\App_Data\QLDTDD.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            try
            {
                string query = "select * from LOAIHANG";
                SqlDataAdapter adt = new SqlDataAdapter(query,connect);
                DataTable dt = new DataTable();
                adt.Fill(dt);
                this.DataList1.DataSource = dt;
                this.DataList1.DataBind();
            }
            catch(SqlException ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string maloai = ((LinkButton)sender).CommandArgument;
            Context.Items["maLoai"] = maloai;
            Server.Transfer("MatHang.aspx");
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string username = this.Login1.UserName;
            string password = this.Login1.Password;

            string query1 = "select * from KHACHHANG where USERNAME like '"+username+"'and PASSWORD like '"+password+"'";

            DataTable dt = new DataTable();

            try
            {
                SqlDataAdapter adt = new SqlDataAdapter(query1,connect);
                adt.Fill(dt);
            }
            catch(SqlException ex)
            {
                Response.Write(ex.Message);
            }

            if (dt.Rows.Count != 0)
            {
                Response.Cookies["tendangnhap"].Value = username;
                Server.Transfer("MatHang.aspx");
            }
            else this.Login1.FailureText = "Tên Đăng Nhập Hoặc Mật Khẩu Không Đúng";
        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }
    }
}