<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage.Master" AutoEventWireup="true" CodeBehind="ChiTietMatHang.aspx.cs" Inherits="WebBanDTDD.ChiTietMatHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 151px;
        }
        .auto-style3 {
            width: 173px;
        }
        .auto-style4 {
            margin-right: 90px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    <asp:Label ID="Label1" runat="server"></asp:Label>
    &nbsp;<asp:DataList ID="DataList2" runat="server" OnSelectedIndexChanged="DataList2_SelectedIndexChanged">
        <ItemTemplate>
        <table class="auto-style1">
        <tr>
            <td colspan="3">

                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" >Giỏ Hàng</asp:LinkButton>

                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click" >Giỏ Hàng Xóa Sửa 1</asp:LinkButton>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click" >Giỏ Hàng Xóa Sửa Nhiều"</asp:LinkButton>

            </td>
        </tr>
        <tr>
            <td class="auto-style2" rowspan="4">
                <asp:Image ID="Image3" runat="server"  Height="150px" Width="100%"  ImageUrl='<%# "~/image/"+Eval("HINH") %>' CssClass="auto-style4"/>
            </td>
            <td class="auto-style3">Tên Sản Phẩm</td>
            <td>
                <asp:Label ID="lblTenSP" runat="server" Text='<%# Eval("TENSP") %>'></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Mô Tả</td>
            <td>
                <asp:Label ID="lblMoTa" runat="server" Enabled="False"   Text='<%# Eval("MOTA") %>'></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Đơn Giá</td>
            <td>
                <asp:Label ID="lblDonGia" runat="server"  Text='<%# Eval("DONGIA") %>'></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Số Lượng</td>
            <td>
                <asp:TextBox ID="txtSoLuong" runat="server" Width="182px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="btnMua" runat="server" Text="Mua" OnClick="btnMua_Click" CommandArgument='<%# Eval("MASP") %>' /></td>
        </tr>
    </table>
        </ItemTemplate>
    </asp:DataList>
    
    
    
</asp:Content>
