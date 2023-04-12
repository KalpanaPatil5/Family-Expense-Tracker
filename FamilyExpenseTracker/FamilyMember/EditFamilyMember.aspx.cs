using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FamilyExpenseTracker.FamilyMember
{
    public partial class EditFamilyMember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            if (!IsPostBack)
            {
                if (id == null)
                {
                    Response.StatusCode = 405;
                }
                else
                {
                    FamilyMemberRepository familyMemberRepository = new FamilyMemberRepository();
                    BO.FamilyMember familyMemberResult = familyMemberRepository.GetFamilyMember(Convert.ToInt32(id));
                    memberId.Value = familyMemberResult.FamilyMemberId.ToString();
                    name.Text = familyMemberResult.Name;
                    cell.Text = familyMemberResult.Cell.ToString();
                    work.Text = familyMemberResult.Work;
                    income.Text = familyMemberResult.Income.ToString();
                }
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BO.FamilyMember familyMember = new BO.FamilyMember()
                {
                    FamilyMemberId = Convert.ToInt32(Request.QueryString["id"]),
                    Name = name.Text,
                    Cell = Convert.ToInt64(cell.Text),
                    Work = work.Text,
                    Income = Convert.ToInt32(income.Text)
                };

                FamilyMemberRepository familyMemberRepository = new FamilyMemberRepository();
                try
                {
                   int editStatus = familyMemberRepository.EditFamilyMember(familyMember);
                   if (editStatus == (int)Utilities.OperationState.Edited)
                   {
                        Response.Redirect("GetAllFamilyMembers.aspx");
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