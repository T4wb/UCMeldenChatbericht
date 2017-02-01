<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MeldenChatberichtUI.aspx.cs" Inherits="UCMeldenChatbericht.Views.MeldenChatberichtUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <asp:Label ID="lblMessageStatic" runat="server" Text="Message: "></asp:Label>
            <asp:DropDownList ID="ddMessage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddMessage_SelectedIndexChanged" ViewStateMode="Enabled" AppendDataBoundItems="True">
            </asp:DropDownList>
    </div>
        <div>
            <asp:Label ID="lblUserStatic" runat="server" Text="UserName: "></asp:Label>
            <asp:Label ID="lblUserName" runat="server" Text="No user is selected" BorderStyle="None" ViewStateMode="Enabled"></asp:Label>
        </div>

        <div>
            <asp:Label ID="lblReasonStatic" runat="server" Text="Reason: "></asp:Label>
            <asp:TextBox ID="tbReason" runat="server" ViewStateMode="Enabled"></asp:TextBox>
        </div>
        <asp:Button ID="btnSubmitReport" runat="server" OnClick="selectSubmitReport" Text="Submit Report" />
    </form>
</body>
</html>
