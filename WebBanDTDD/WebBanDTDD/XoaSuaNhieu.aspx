<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage.Master" AutoEventWireup="true" CodeBehind="XoaSuaNhieu.aspx.cs" Inherits="WebBanDTDD.XoaSuaNhieu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("MASP") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="TENSP" HeaderText="Tên Hàng" />
            <asp:BoundField DataField="MOTA" HeaderText="Mô Tả" />
            <asp:BoundField DataField="DONGIA" HeaderText="Đơn Giá" />
            <asp:TemplateField HeaderText="Số Lượng">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("SOLUONG") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="THANHTIEN" HeaderText="Thành Tiền" />
        </Columns>
    </asp:GridView>
    <asp:Label ID="lblTongTien" runat="server"></asp:Label>
    <br />
    <asp:Button ID="btnXoa" runat="server" Text="Xóa" Width="80px" OnClick="btnXoa_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnSua" runat="server" OnClick="btnSua_Click" Text="Sửa" Width="94px" />
    <br />
    
</asp:Content>
