using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FamilyExpenseTracker.FamilyExpense
{
    public partial class GetAllFamilyExpense : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FamilyExpenseRepository familyExpenseRepository = new FamilyExpenseRepository();
                try
                {
                    List<BO.FamilyExpense> familyExpenseResult = familyExpenseRepository.GetAllFamilyExpenses();
                    gv.DataSource = familyExpenseResult;
                    gv.DataBind();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void btnAddFamilyMember_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Response.Redirect("AddFamilyExpense.aspx");
            }
            else
            {
                Response.StatusCode = 405;
            }
        }

        protected void FamilyExpense_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Response.Redirect("~/FamilyMember/GetAllFamilyMembers.aspx");
            }
            else
            {
                Response.StatusCode = 405;
            }
        }

        protected void gv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            object id = e.Values[0];
            FamilyExpenseRepository familyExpenseRepository = new FamilyExpenseRepository();
            try
            {
                int deleteStatus = familyExpenseRepository.DeleteFamilyExpense(Convert.ToInt32(id));
                if (deleteStatus == (int)Utilities.OperationState.Deleted)
                {
                    Response.Redirect("GetAllFamilyExpense.aspx");
                }
                else
                {
                    Response.StatusCode = 405;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        int totalExpense = 0;
        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                totalExpense += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Amount"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[4].Text = "Total Expense";
                e.Row.Cells[4].Font.Bold = true;

                e.Row.Cells[5].Text = totalExpense.ToString();
                e.Row.Cells[5].Font.Bold = true;
            }

        }
    }
}