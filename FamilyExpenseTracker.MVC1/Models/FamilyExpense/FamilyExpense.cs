using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyExpenseTracker.MVC1.Models.FamilyExpense
{
    public class FamilyExpense
    {
        public int? ExpenseId { get; set; }
        public int? FamilyMemberId { get; set; }
        public string Name { get; set; }
        public string Purpose { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
    }

}