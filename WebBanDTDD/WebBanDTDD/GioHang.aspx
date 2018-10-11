<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage.Master" AutoEventWireup="true" CodeBehind="GioHang.aspx.cs" Inherits="WebBanDTDD.GioHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" Width="749px">
    </asp:GridView>
    <asp:Label ID="lblThanhTien" runat="server" Text=""></asp:Label>
</asp:Content>
