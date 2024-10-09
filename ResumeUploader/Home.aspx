<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ResumeUploader.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Resume Uploader</title>

</head>
<body>
    <form id="form1" runat="server">
        <h2>Resume Uploader</h2><br />
        <br />
        Full Name :
        <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>
        <br />
        <br />
        Contact No :
        <asp:TextBox ID="TxtContct" runat="server"></asp:TextBox>
        <br />
        <br />
        Email :
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br />
        <br />
        Experience :
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem>Fresher</asp:ListItem>
            <asp:ListItem>Experienced</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        Stream :&nbsp; <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
            <asp:ListItem>Bsc - IT</asp:ListItem>
            <asp:ListItem>B.E</asp:ListItem>
            <asp:ListItem>BCS</asp:ListItem>
            <asp:ListItem>B.Tech</asp:ListItem>
            <asp:ListItem>BCA</asp:ListItem>
            <asp:ListItem>MCA</asp:ListItem>
            <asp:ListItem>Msc - IT</asp:ListItem>
            <asp:ListItem>M.Tech</asp:ListItem>
            <asp:ListItem>others</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        Upload Your Resume :
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <br />
        <div id="additionalFields" runat="server">
        Year of Experience :
        <asp:TextBox ID="txtExp" runat="server"></asp:TextBox>
        <br />
        <br />
        Notice period :
        <asp:TextBox ID="txtNP" runat="server"></asp:TextBox>
        <br />
        <br />
        Current CTC :
        <asp:TextBox ID="txtCTC" runat="server"></asp:TextBox>
        <br />
        <br />
        Expected CTC :
        <asp:TextBox ID="txtECTC" runat="server"></asp:TextBox>
        </div>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Apply" />
    </form>
</body>
</html>
