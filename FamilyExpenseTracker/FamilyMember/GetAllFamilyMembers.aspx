<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetAllFamilyMembers.aspx.cs" Inherits="FamilyExpenseTracker.FamilyMember.GetAllFamilyMembers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Family Members Details</title>
    <style type="text/css">
        #btnAddFamilyMember,#FamilyExpense{
            background-color:teal;
            color:black;
            font-size:medium;
            font-display:auto;
            border:groove;
        }
        div{
            text-align:center;
        }
        .auto-style1 {
            width: 320px;
        }
        .auto-style2 {
            width: 277px;
        }
    </style>
</head>
<body style="background-color:cadetblue">
    <form id="form1" runat="server">
        <div>
            <table style="margin:0 auto" runat="server">
                <tr>
                    <td style="background-color:lightgoldenrodyellow"><h2><b><label style="margin:auto;color:darkred">FAMILY MEMBER DETAILS</label></b></h2></td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GV" runat="server" AutoGenerateColumns="False" Height="400px" Width="600px" ShowFooter="True" OnRowDeleting="GV_RowDeleting" OnRowDataBound="GV_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField  ControlStyle-CssClass="text-light btn btn-danger" ShowDeleteButton="true">
                                <ControlStyle CssClass="text-light btn btn-danger"></ControlStyle>
                                </asp:CommandField>
                                <asp:BoundField HeaderText="ID" DataField="FamilyMemberId" />
                                <asp:BoundField HeaderText="Name" DataField="Name" />
                                <asp:BoundField HeaderText="Cell" DataField="Cell" />
                                <asp:BoundField HeaderText="Work" DataField="Work" />
                                <asp:BoundField HeaderText="Income" DataField="Income" />
                                <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="FamilyMemberId" DataNavigateUrlFormatString="EditFamilyMember.aspx?id={0}" />
                            </Columns>
                            <EditRowStyle BackColor="#7C6F57" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                            <SortedDescendingHeaderStyle BackColor="#15524A" />
                        </asp:GridView>
                    </td>
                </tr>

            </table>
        </div>
        <div>
            <table style="align-content:center;margin:auto">
                <tr>
                    <td style="align-content:center;margin:auto" class="auto-style2">
                        <asp:Button style="align-self:center" ID="btnAddFamilyMember" runat="server" Text="Add Family Member" Height="51px" Width="207px" OnClick="btnAddFamilyMember_Click" />
                    </td>
                    <td style="align-content:center;margin:auto" class="auto-style1">
                        <asp:Button ID="FamilyExpense" runat="server" Text="View Family Expenses" Height="51px" Width="207px" OnClick="FamilyExpense_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
