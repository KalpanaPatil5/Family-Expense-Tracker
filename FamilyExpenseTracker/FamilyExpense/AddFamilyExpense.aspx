<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFamilyExpense.aspx.cs" Inherits="FamilyExpenseTracker.FamilyExpense.AddFamilyExpense" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Family Expense</title>
    <link href="FamilyExpenseStyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="margin:0 auto" runat="server" class="auto-style2">
                <tr>
                    <td class="auto-style1"><h3><b>ADD FAMILY EXPENSE</b></h3></td>
                </tr>
                <tr>
                    <td class="auto-style1"><label>Name : </label></td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="ddlname" runat="server" Height="25px" Width="200px">
                        </asp:DropDownList><br />
                        <asp:RequiredFieldValidator ID="rfvname" runat="server" ControlToValidate="ddlname" ErrorMessage="Select Name !!" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1"><label>Purpose : </label></td>
                    <td class="auto-style3">
                        <asp:TextBox ID="purpose" runat="server" Height="25px" Width="200px"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="rfvpurpose" runat="server" ControlToValidate="purpose" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regex2" runat="server" ControlToValidate="purpose" ErrorMessage="Purpose required!!" ForeColor="Red" ValidationExpression="[A-Z][a-z]*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1"><label>Amount : </label></td>
                    <td class="auto-style3">
                        <asp:TextBox ID="amount" runat="server" Height="25px" Width="200px"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="rfvamount" runat="server" ControlToValidate="amount" ErrorMessage="Amount required!!" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regex3" runat="server" ControlToValidate="amount" ErrorMessage="Amount required !!" ForeColor="Red" ValidationExpression="[0-9]*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1"><label>Date : </label></td>
                    <td class="auto-style3">
                        <asp:TextBox ID="date" runat="server" type="date" Height="25px" Width="200px"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="regex4" runat="server" ControlToValidate="date" ErrorMessage="Date required!!" ForeColor="Red"></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td class="auto-style3">
                        <asp:Button ID="submit" runat="server" Text="Submit" Height="30px" Width="90px" OnClick="submit_Click"></asp:Button>
                    </td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>
