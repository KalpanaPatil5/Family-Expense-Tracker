using FamilyExpenseTracker.MVC1.Models.FamilyExpense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyExpenseTracker.MVC1.Controllers
{
    public class FamilyExpenseController : Controller
    {
        // GET: FamilyExpense
        public ActionResult Index()
        {
            FamilyExpenseRepository familyExpenseRepository = new FamilyExpenseRepository();
            List<FamilyExpense> familyExpenses = familyExpenseRepository.GetFamilyExpenses();
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
            FamilyExpenseRepository familyExpenseRepository = new FamilyExpenseRepository();
            //List<string> familyMemberNames = familyExpenseRepository.GetNames();
            int insertStatus = familyExpenseRepository.AddFamilyExpense(familyExpense);
            if (insertStatus > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult EditFamilyExpense(int id)
        {
            FamilyExpenseRepository familyExpenseRepository = new FamilyExpenseRepository();
            FamilyExpense familyExpenseResult = familyExpenseRepository.GetFamilyExpense(id);
            return View(familyExpenseResult);
        }

        [HttpPost]
        public ActionResult EditFamilyExpense(FamilyExpense familyExpense)
        {
            FamilyExpenseRepository familyExpenseRepository = new FamilyExpenseRepository();
            int editStatus = familyExpenseRepository.EditFamilyExpense(familyExpense);
            if (editStatus > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult DeleteFamilyExpense(int id)
        {
            FamilyExpenseRepository familyExpenseRepository = new FamilyExpenseRepository();
            FamilyExpense familyExpenseResult = familyExpenseRepository.GetFamilyExpense(id);
            return View(familyExpenseResult);
        }

        [HttpPost]
        public ActionResult DeleteFamilyExpense(FamilyExpense familyExpense)
        {
            FamilyExpenseRepository familyExpenseRepository = new FamilyExpenseRepository();
            int deleteStatus = familyExpenseRepository.DeleteFamilyExpense(Convert.ToInt32(familyExpense.ExpenseId));
            if (deleteStatus > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}