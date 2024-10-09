<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InterviewSchedular.aspx.cs" Inherits="ResumeUploader.InterviewSchedular" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Hi
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            Select your interview time for tommorow
            <br />
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>9am to 10am</asp:ListItem>
                <asp:ListItem>10am to 11am</asp:ListItem>
                <asp:ListItem>11am to 12pm</asp:ListItem>
                <asp:ListItem>12pm to 1pm</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Schedule interview" />
        </div>
    </form>
</body>
</html>
