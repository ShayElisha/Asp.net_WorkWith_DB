<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="web09052024.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
   Email: <asp:TextBox ID="UserEmail" runat="server" /><br />
    סיסמה : <asp:TextBox ID="UserPass" TextMode="Password" runat="server" /><br />
    <asp:Button ID="LoginBtn" runat="server" Text="Login" OnClick="LoginBtn_Click"/><br />
    <asp:Literal ID="LtlMsg" runat="server" />
</div>
</asp:Content>
