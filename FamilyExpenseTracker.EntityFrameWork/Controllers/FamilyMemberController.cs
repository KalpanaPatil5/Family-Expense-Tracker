using FamilyExpenseTracker.EntityFrameWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyExpenseTracker.EntityFrameWork.Controllers
{
    public class FamilyMemberController : Controller
    {
        // GET: FamilyMember
        public ActionResult Index()
        {
            FamilyExpenseTrackerDBConnectionString familyExpenseTrackerDB = new FamilyExpenseTrackerDBConnectionString();
            List<FamilyMember> familyMembers = familyExpenseTrackerDB.FamilyMembers.ToList();
            return View(familyMembers);
        }

        public ActionResult AddFamilyMember()
        {
            FamilyMember familyMember = new FamilyMember();
            return View(familyMember);
        }

        [HttpPost]
        public ActionResult AddFamilyMember(FamilyMember familyMember)
        {
            FamilyExpenseTrackerDBConnectionString familyExpenseTrackerDB = new FamilyExpenseTrackerDBConnectionString();
            familyExpenseTrackerDB.FamilyMembers.Add(familyMember);
            int insertStatus = familyExpenseTrackerDB.SaveChanges();
            if (insertStatus > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult EditFamilyMember(int id)
        {
            FamilyExpenseTrackerDBConnectionString familyExpenseTrackerDB = new FamilyExpenseTrackerDBConnectionString();
            //reading all family members
            var familyMembers = familyExpenseTrackerDB.FamilyMembers.ToList();
            //filtering one family member based on ID using LINQ
            var familyMember = from member in familyMembers
                               where member.FamilyMemberId == id
                               select new FamilyMember
                               {
                                   FamilyMemberId = member.FamilyMemberId,
                                   Name = member.Name,
                                   Cell = member.Cell,
                                   Work = member.Work,
                                   Income = member.Income
                               };
            //converting IEnum<FamilyMembers> to single family member
            FamilyMember familyMemberResult = familyMember.Single();
            return View(familyMemberResult);
        }

        [HttpPost]
        public ActionResult EditFamilyMember(FamilyMember familyMember)
        {
            FamilyExpenseTrackerDBConnectionString familyExpenseTrackerDB = new FamilyExpenseTrackerDBConnectionString();
            //adding new family member
            familyExpenseTrackerDB.FamilyMembers.Add(familyMember);
            //modifying the existing family member details & performing update db script
            familyExpenseTrackerDB.Entry<FamilyMember>(familyMember).State = System.Data.Entity.EntityState.Modified;
            int editStatus = familyExpenseTrackerDB.SaveChanges();
            if (editStatus > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult DeleteFamilyMember(int id)
        {
            FamilyExpenseTrackerDBConnectionString familyExpenseTrackerDB = new FamilyExpenseTrackerDBConnectionString();
            var familyMembers = familyExpenseTrackerDB.FamilyMembers.ToList();
            var familyMember = from member in familyMembers
                               where member.FamilyMemberId == id
                               select new FamilyMember
                               {
                                   FamilyMemberId = member.FamilyMemberId,
                                   Name = member.Name,
                                   Cell = member.Cell,
                                   Work = member.Work,
                                   Income = member.Income
                               };
            FamilyMember familyMemberResult = familyMember.Single();
            return View(familyMemberResult);
        }

        [HttpPost]
        public ActionResult DeleteFamilyMember(FamilyMember familyMember)
        {
            FamilyExpenseTrackerDBConnectionString familyExpenseTrackerDB = new FamilyExpenseTrackerDBConnectionString();
            FamilyMember familyMemberResult = familyExpenseTrackerDB.FamilyMembers.Find(familyMember.FamilyMemberId);
            familyExpenseTrackerDB.FamilyMembers.Remove(familyMemberResult);
            int deleteStatus = familyExpenseTrackerDB.SaveChanges();
            if (deleteStatus > 0)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

    }
}