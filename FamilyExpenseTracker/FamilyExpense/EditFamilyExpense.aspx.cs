using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FamilyExpenseTracker.FamilyExpense
{
    public partial class EditFamilyExpense : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];

            if (!IsPostBack)
            {
                FamilyExpenseRepository familyExpenseRepository = new FamilyExpenseRepository();
                if (id == null)
                {
                    Response.StatusCode = 405;
                }
                else
                {
                    try
                    {
                        List<string> names = familyExpenseRepository.GetAllFamilyMemberNames();
                        ddlname.DataSource = names;
                        ddlname.DataBind();

                        BO.FamilyExpense result = familyExpenseRepository.GetFamilyExpense(Convert.ToInt32(id));
                        ExpenseId.Value = result.ExpenseId.ToString();
                        FamilyMemberId.Value = result.FamilyMemberId.ToString();
                        ddlname.SelectedValue = result.Name;
                        purpose.Text = result.Purpose;
                        amount.Text = result.Amount.ToString();
                        date.Text = result.DateTime.ToString();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BO.FamilyExpense familyExpense = new BO.FamilyExpense()
                {
                    ExpenseId = Convert.ToInt32(Request.QueryString["id"]),
                    FamilyMemberId = Convert.ToInt32(FamilyMemberId.Value),
                    Name = ddlname.SelectedValue,
                    Purpose = purpose.Text,
                    Amount = Convert.ToInt32(amount.Text),
                    DateTime = Convert.ToDateTime(date.Text)
                };

                FamilyExpenseRepository familyExpenseRepository = new FamilyExpenseRepository();
                try
                {
                    int editStatus = familyExpenseRepository.EditFamilyExpense(familyExpense);
                    if (editStatus == (int)Utilities.OperationState.Edited)
                    {
                        Response.Redirect("GetAllFamilyExpense.aspx");
                    }
                    else
                    {

                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}