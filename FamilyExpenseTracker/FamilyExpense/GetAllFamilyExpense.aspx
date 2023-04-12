<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetAllFamilyExpense.aspx.cs" Inherits="FamilyExpenseTracker.FamilyExpense.GetAllFamilyExpense" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Get All Family Expense</title>
    <style type="text/css">
      div{
            text-align:center;
      }
      #btnAddFamilyExpense,#FamilyMembers{
            background-color:teal;
            color:black;
            font-size:medium;
            font-display:auto;
            border:groove;
      }

      .auto-style1 {
            width: 351px;
            height: 87px;
      }
        .auto-style2 {
            height: 87px;
            width: 276px;
        }
    </style>
</head>
<body style="background-color:cadetblue">
    <form id="form1" runat="server">
        <div>
            <table style="margin:0 auto" runat="server">
                <tr>
                    <td style="background-color:lightgoldenrodyellow"><h2><b><label style="margin:auto;color:darkred">FAMILY EXPENSE DETAILS</label></b></h2></td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" Height="202px" Width="630px" OnRowDeleting="gv_RowDeleting" ShowFooter="True" OnRowDataBound="gv_RowDataBound" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                            <AlternatingRowStyle BackColor="White" />
                           <Columns>
                               <asp:CommandField ControlStyle-CssClass="text-light btn btn-danger" ShowDeleteButton="true" >
                                <ControlStyle CssClass="text-light btn btn-danger"></ControlStyle>
                               </asp:CommandField>
                               <asp:BoundField HeaderText="ExpenseId" DataField="ExpenseId"/>
                                <asp:BoundField HeaderText="FamilyMemberId" DataField="FamilyMemberId" Visible="false" />
                                <asp:BoundField HeaderText="Name" DataField="Name" />
                                <asp:BoundField HeaderText ="Purpose" DataField="Purpose" />
                                <asp:BoundField HeaderText="Amount" DataField="Amount" />
                                <asp:BoundField HeaderText="Date" DataField="DateTime" />
                                <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="ExpenseId" DataNavigateUrlFormatString="EditFamilyExpense.aspx?id={0}" />
                         </Columns>
                            <FooterStyle BackColor="#CCCC99" />
                            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                            <RowStyle BackColor="#F7F7DE" />
                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#FBFBF2" />
                            <SortedAscendingHeaderStyle BackColor="#848384" />
                            <SortedDescendingCellStyle BackColor="#EAEAD3" />
                            <SortedDescendingHeaderStyle BackColor="#575357" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table style="align-content:center;margin:auto">
                <tr>
                    <td style="align-content:center;margin:auto" class="auto-style2">
                        <asp:Button style="align-self:center" ID="btnAddFamilyExpense" runat="server" Text="Add Family Expense" Height="51px" Width="207px" OnClick="btnAddFamilyMember_Click" />
                    </td>
                    <td style="align-content:center;margin:auto" class="auto-style1">
                        <asp:Button ID="FamilyMembers" runat="server" Text="View Family Members" Height="51px" Width="207px" OnClick="FamilyExpense_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
