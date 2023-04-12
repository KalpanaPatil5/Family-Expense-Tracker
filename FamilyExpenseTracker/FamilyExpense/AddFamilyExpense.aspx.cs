using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FamilyExpenseTracker.FamilyExpense
{
    public partial class AddFamilyExpense : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FamilyExpenseRepository familyExpenseRepository = new FamilyExpenseRepository();
                try
                {
                    List<string> nameResult = familyExpenseRepository.GetAllFamilyMemberNames();
                    ddlname.DataSource = nameResult;
                    ddlname.DataBind();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BO.FamilyExpense familyExpense = new BO.FamilyExpense()
                {
                    Name = ddlname.SelectedValue,
                    Purpose = purpose.Text,
                    Amount = Convert.ToInt32(amount.Text),
                    DateTime = Convert.ToDateTime(date.Text)
                };

                FamilyExpenseRepository familyExpenseRepository = new FamilyExpenseRepository();
                try
                {
                    int insertStatus = familyExpenseRepository.AddFamilyExpense(familyExpense);
                    if (insertStatus == (int)Utilities.OperationState.Inserted)
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
        }
    }
}