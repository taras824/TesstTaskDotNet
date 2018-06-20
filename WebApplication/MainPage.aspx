<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="WebApplication.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://fonts.googleapis.com/css?family=Roboto:400,700&amp;subset=cyrillic,cyrillic-ext,greek,greek-ext,latin-ext,vietnamese" rel="stylesheet"/>
    <link href="/style.css" rel="stylesheet"/>
    <title></title>
</head>
<body>
    <div class="container">
        <form id="form1" runat="server">
        <asp:FileUpload ID="FileUpload1" style="background:#333;" runat="server" accept=".txt" multiple="false" BorderStyle="None" BorderWidth="0px" />
        <asp:TextBox ID="TextBox1" class="input" placeholder="Enter your value" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" class="button" OnClick="Button1_Click" Text="Search" />
        <asp:Button ID="Button2" runat="server" class="button" OnClick="Button2_Click" Text="ReloadDB" />
        <asp:EntityDataSource ID="EntityDataSource1" runat="server"></asp:EntityDataSource>
        </form>
        <div id="sentenceBD" runat="server"></div>
    </div>
</body>
</html>
