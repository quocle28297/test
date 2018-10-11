<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage.Master" AutoEventWireup="true" CodeBehind="XoaSua1.aspx.cs" Inherits="WebBanDTDD.XoaSua1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            margin-right: 3px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <asp:Label ID="lblThongBao" runat="server"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" GridLines="Vertical" Width="708px" AutoGenerateColumns="False" CssClass="auto-style2" ForeColor="Black" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("MASP") %>' OnClick="LinkButton2_Click">Xóa</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="TENSP" HeaderText="Tên Hàng" />
            <asp:BoundField DataField="MOTA" HeaderText="Mô Tả" />
            <asp:BoundField DataField="DONGIA" HeaderText="Đơn Giá" SortExpression="DONGIA" />
            <asp:TemplateField HeaderText="Số Lượng">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("SOLUONG")  %>'></asp:TextBox>
                    <br />
                    <asp:Button ID="Button1" CommandArgument='<%# Eval("MASP") %>' runat="server" Text="Sửa" OnClick="Button1_Click"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="THANHTIEN" HeaderText="Thành Tiền" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>
    <asp:Label ID="lblThanhTien" runat="server"></asp:Label>
</asp:Content>
