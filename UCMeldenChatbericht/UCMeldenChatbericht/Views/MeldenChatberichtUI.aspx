<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MeldenChatberichtUI.aspx.cs" Inherits="UCMeldenChatbericht.Views.MeldenChatberichtUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #tbReason {
            height: 91px;
            resize:none;
        }
        .auto-style1 {}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        
        <asp:Table ID="tblContent" runat="server" ViewStateMode="Enabled">
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblMessageStatic" runat="server" Text="Message: "></asp:Label></asp:TableCell>
                <asp:TableCell><asp:DropDownList ID="ddMessage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddMessage_SelectedIndexChanged" ViewStateMode="Enabled" AppendDataBoundItems="True"></asp:DropDownList></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblUserStatic" runat="server" Text="Username: "></asp:Label></asp:TableCell>
                <asp:TableCell><asp:Label ID="lblUserName" runat="server" Text="No user is selected" BorderStyle="None" ViewStateMode="Enabled"></asp:Label></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblReasonStatic" runat="server" Text="Reason: "></asp:Label></asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <asp:TextBox ID="tbReason" runat="server" ViewStateMode="Enabled" TextMode="MultiLine"></asp:TextBox>
        <p><asp:Button ID="btnSubmitReport" runat="server" OnClick="selectSubmitReport" Text="Submit Report" /></p>
    </form>
</body>
</html>
