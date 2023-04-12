<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFamilyMember.aspx.cs" Inherits="FamilyExpenseTracker.FamilyMember.AddFamilyMember" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Family Member</title>
    <link href="FamilyMemberStyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="margin:0 auto" runat="server" class="auto-style2">
                <tr>
                    <td class="auto-style1"><h3><b><asp:Label runat="server" ID="label">ADD FAMILY MEMBER</asp:Label> </b></h3></td>
                </tr>
                <tr>
                    <td></td>
                    <td class="auto-style4"><asp:HiddenField ID="memberId" runat="server" /></td>
                </tr>
                <tr>
                    <td class="auto-style1"><label>Name : </label></td>
                    <td class="auto-style4">
                        <asp:TextBox ID="name" runat="server" Height="25px" Width="200px"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="rfvname" runat="server" ControlToValidate="name" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regex1" runat="server" ControlToValidate="name" ErrorMessage="Enter full name!!" ForeColor="Red" ValidationExpression="[A-Z][a-z]+[ ][A-Z][a-z]+"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1"><label>Cell : </label></td>
                    <td class="auto-style4">
                        <asp:TextBox ID="cell" runat="server" Height="25px" Width="200px"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="rfvcell" runat="server" ControlToValidate="cell" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regex2" runat="server" ControlToValidate="cell" ErrorMessage="Cell No. required!!" ForeColor="Red" ValidationExpression="[6-9][0-9]{9}"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1"><label>Work : </label></td>
                    <td class="auto-style4">
                        <asp:TextBox ID="work" runat="server" Height="25px" Width="200px"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="rfvwork" runat="server" ControlToValidate="work" ErrorMessage="Work required!! Specify NIL if not working" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1"><label>Income : </label></td>
                    <td class="auto-style4">
                        <asp:TextBox ID="income" runat="server" Height="25px" Width="200px"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="income" ErrorMessage="Income required!! Specify NIL if not having income." ForeColor="Red"></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td class="auto-style4">
                        <asp:Button ID="submit" runat="server" Text="Submit" Height="37px" Width="105px" OnClick="submit_Click"></asp:Button>
                    </td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>
