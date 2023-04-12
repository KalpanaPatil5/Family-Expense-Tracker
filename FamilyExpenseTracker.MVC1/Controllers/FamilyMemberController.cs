using FamilyExpenseTracker.MVC1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyExpenseTracker.MVC1.Controllers
{
    public class FamilyMemberController : Controller
    {
        // GET: FamilyMember
        public ActionResult Index()
        {
            FamilyMemberRepository familyMemberRepository = new FamilyMemberRepository();
            List<FamilyMember> familyMembers = familyMemberRepository.GetAllFamilyMembers();
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
            FamilyMemberRepository familyMemberRepository = new FamilyMemberRepository();
            int insertStatus = familyMemberRepository.AddFamilyMember(familyMember);
            if (insertStatus > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult EditFamilyMember(int id)
        {
            FamilyMemberRepository familyMemberRepository = new FamilyMemberRepository();
            FamilyMember familyMember = familyMemberRepository.GetFamilyMember(id);
            return View(familyMember);
        }

        [HttpPost]
        public ActionResult EditFamilyMember(FamilyMember familyMember)
        {
            FamilyMemberRepository familyMemberRepository = new FamilyMemberRepository();
            int editStatus = familyMemberRepository.EditFamilyMember(familyMember);
            if (editStatus > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult DeleteFamilyMember(int id)
        {
            FamilyMemberRepository familyMemberRepository = new FamilyMemberRepository();
            FamilyMember familyMember = familyMemberRepository.GetFamilyMember(id);
            return View(familyMember);
        }

        [HttpPost]
        public ActionResult DeleteFamilyMember(FamilyMember familyMember)
        {
            FamilyMemberRepository familyMemberRepository = new FamilyMemberRepository();
            int deleteStatus = familyMemberRepository.DeleteFamilyMember(Convert.ToInt32(familyMember.FamilyMemberId));
            if (deleteStatus > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}