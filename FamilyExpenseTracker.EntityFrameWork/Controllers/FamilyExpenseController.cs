using FamilyExpenseTracker.EntityFrameWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyExpenseTracker.EntityFrameWork.Controllers
{
    public class FamilyExpenseController : Controller
    {
        // GET: FamilyExpense
        public ActionResult Index()
        {
            FamilyExpenseTrackerDBConnectionString familyExpenseTrackerDB = new FamilyExpenseTrackerDBConnectionString();
            List<FamilyExpense> familyExpenses = familyExpenseTrackerDB.FamilyExpenses.ToList();
            return View(familyExpenses);
        }

        public ActionResult AddFamilyExpense()
        {
            FamilyExpense familyExpense = new FamilyExpense();
            return View(familyExpense);
        }

        [HttpPost]
        public ActionResult AddFamilyExpense(FamilyExpense familyExpense)
        {
            FamilyExpenseTrackerDBConnectionString familyExpenseTrackerDB = new FamilyExpenseTrackerDBConnectionString();
            familyExpenseTrackerDB.FamilyExpenses.Add(familyExpense);
            int insertStatus = familyExpenseTrackerDB.SaveChanges();
            if (insertStatus > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult EditFamilyExpense(int id)
        {
            FamilyExpenseTrackerDBConnectionString familyExpenseTrackerDB = new FamilyExpenseTrackerDBConnectionString();
            var familyExpenses = familyExpenseTrackerDB.FamilyExpenses.ToList();
            var familyExpense = from expense in familyExpenses
                                where expense.ExpenseId == id
                                select new FamilyExpense {
                                    ExpenseId = expense.ExpenseId,
                                    FamilyMemberId = expense.FamilyMemberId,
                                    Purpose = expense.Purpose,
                                    Amount = expense.Amount,
                                    DateTime = expense.DateTime
                                };
            FamilyExpense familyExpenseResult = familyExpense.Single();
            return View(familyExpenseResult);
        }

        [HttpPost]
        public ActionResult EditFamilyExpense(FamilyExpense familyExpense)
        {
            FamilyExpenseTrackerDBConnectionString familyExpenseTrackerDB = new FamilyExpenseTrackerDBConnectionString();
            familyExpenseTrackerDB.FamilyExpenses.Add(familyExpense);
            familyExpenseTrackerDB.Entry<FamilyExpense>(familyExpense).State = System.Data.Entity.EntityState.Modified;
            int editStatus = familyExpenseTrackerDB.SaveChanges();
            if (editStatus > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult DeleteFamilyExpense(int id)
        {
            FamilyExpenseTrackerDBConnectionString familyExpenseTrackerDB = new FamilyExpenseTrackerDBConnectionString();
            var familyExpenses = familyExpenseTrackerDB.FamilyExpenses.ToList();
            var familyExpense = from expense in familyExpenses
                                where expense.ExpenseId == id
                                select new FamilyExpense
                                {
                                    ExpenseId = expense.ExpenseId,
                                    FamilyMemberId = expense.FamilyMemberId,
                                    Purpose = expense.Purpose,
                                    Amount = expense.Amount,
                                    DateTime = expense.DateTime
                                };
            FamilyExpense familyExpenseResult = familyExpense.Single();
            return View(familyExpenseResult);
        }

        [HttpPost]
        public ActionResult DeleteFamilyExpense(FamilyExpense familyExpense)
        {
            FamilyExpenseTrackerDBConnectionString familyExpenseTrackerDB = new FamilyExpenseTrackerDBConnectionString();
            FamilyExpense familyExpenseResult = familyExpenseTrackerDB.FamilyExpenses.Find(familyExpense.ExpenseId);
            familyExpenseTrackerDB.FamilyExpenses.Remove(familyExpenseResult);
            int deleteStatus = familyExpenseTrackerDB.SaveChanges();
            if (deleteStatus > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}