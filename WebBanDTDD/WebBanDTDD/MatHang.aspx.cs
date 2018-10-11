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
    public partial class MatHang : System.Web.UI.Page
    {
        string connect = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\GitHub\test\WebBanDTDD\WebBanDTDD\App_Data\QLDTDD.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            string query = "";
            if (Page.IsPostBack) return;
            
                if (Context.Items["maLoai"] == null)
                {
                    query = "select * from SANPHAM";
                }
                else
                {
                    string maloai = Context.Items["maLoai"].ToString();
                    query = "select * from SANPHAM where MALOAI=" + Convert.ToUInt16(maloai);
                }
                try
                {
                    SqlDataAdapter adt = new SqlDataAdapter(query, connect);
                    DataTable dt = new DataTable();
                    adt.Fill(dt);
                    this.DataList2.DataSource = dt;
                    this.DataList2.DataBind();
                }
                catch (SqlException ex) { Response.Write(ex.Message); }
            
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string maSP = ((ImageButton)sender).CommandArgument;
            Context.Items["msp"] = maSP;
            Server.Transfer("ChiTietMatHang.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            string maSP = ((LinkButton)sender).CommandArgument;
            Context.Items["msp"] = maSP;
            Server.Transfer("ChiTietMatHang.aspx");
        }
    }
}