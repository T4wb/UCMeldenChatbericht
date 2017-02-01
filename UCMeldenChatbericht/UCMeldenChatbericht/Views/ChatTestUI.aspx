<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChatTestUI.aspx.cs" Inherits="UCMeldenChatbericht.Views.ChatTestUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblTestSession" runat="server" Text="Label"></asp:Label>
    
    </div>
        <asp:Button ID="btnReportAbuse" runat="server" OnClick="btnReportAbuse_Click" Text="Report Abuse" />
    </form>
</body>
</html>
