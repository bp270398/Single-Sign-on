<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sign-in.aspx.cs" Inherits="Single_Sign_on.Sign_in" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div >
            <h1 style="text-align: center">Please, sign-in to continue</h1>
            <table style="margin-left: auto; margin-right: auto">
                <tr>
                    <td><label>Username:</label></td>
                    <td><asp:TextBox runat="server" ID="Username"></asp:TextBox><br /></td>
                </tr>
                <tr>
                    <td><label>Password:</label></td>
                    <td><asp:TextBox runat="server" ID="Password" AutoCompleteType="None" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Button Text="Clear" runat="server" OnClick="BtnClear_OnClick" /></td>
                    <td><asp:Button Text="Sign-in" runat="server" OnClick="BtnSubmit_OnClick" /></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label runat="server" ID="ErrorMessage" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
            
        </div>
    </form>
</body>
</html>
