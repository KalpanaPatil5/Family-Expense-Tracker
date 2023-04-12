using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FamilyExpenseTracker.FamilyMember
{
    public partial class GetAllFamilyMembers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FamilyMemberRepository familyMemberRepository = new FamilyMemberRepository();
                try
                {
                    List<BO.FamilyMember> familyMembersResult = familyMemberRepository.GetAllFamilyMembers();
                    if (familyMembersResult.Count != (int)Utilities.OperationState.ZeroCount)
                    {
                        Session["FamilyMembers"] = familyMembersResult;
                        GV.DataSource = familyMemberRepository.GetAllFamilyMembers();
                        GV.DataBind();
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void GV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            object id = e.Values[0];
            FamilyMemberRepository familyMemberRepository = new FamilyMemberRepository();
            try
            {
                    int deleteStatus = familyMemberRepository.DeleteFamilyMember(Convert.ToInt32(id));
                    if (deleteStatus == (int)Utilities.OperationState.Deleted)
                    {
                        Response.Redirect("GetAllFamilyMembers.aspx");
                    }
                    else
                    {
                        Response.StatusCode = 405;
                    }
            }
            catch (Exception ex)
            {
                    throw ex;
            }
        }

        int totalIncome = 0;
        protected void GV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                totalIncome += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Income"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[4].Text = "Grand Total";
                e.Row.Cells[4].Font.Bold = true;

                e.Row.Cells[5].Text = totalIncome.ToString();
                e.Row.Cells[5].Font.Bold = true;
            }
        }

        protected void btnAddFamilyMember_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Response.Redirect("AddFamilyMember.aspx");
            }
        }

        protected void FamilyExpense_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Response.Redirect("~/FamilyExpense/GetAllFamilyExpense.aspx");
            }
        }
    }
}