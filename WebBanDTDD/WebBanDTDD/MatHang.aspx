<%@ Page Title="" Language="C#" MasterPageFile="~/Homepage.Master" AutoEventWireup="true" CodeBehind="MatHang.aspx.cs" Inherits="WebBanDTDD.MatHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            margin-top: 0px;
        }
        #DataList2{
            text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <asp:DataList  ID="DataList2" runat="server" RepeatColumns="3" Width="100%" Style="align-content:center" CssClass="auto-style2">
        <ItemTemplate >
            
            <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%# Eval("MASP") %>' ImageUrl='<%# "~/image/"+Eval("HINH") %>' Width="150px" Height="200px" OnClick="ImageButton1_Click" />
            <br />
            <asp:LinkButton ID="LinkButton2"  runat="server" CommandArgument='<%# Eval("MASP") %>' Text='<%# Eval("TENSP") %>' OnClick="LinkButton2_Click"></asp:LinkButton>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
