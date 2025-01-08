using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Family.Models;
using FamilyBusinessLayer;
using FamilyBusinessLayer.Models;
using ShopGroceryBusinessLayer.Models;

namespace Family.Controllers
{
    public class FamilyMemberController : Controller
    {
        // GET: FamilyMember

          public ActionResult ViewAll()
        {
            DatabaseContext DatabaseContext = new DatabaseContext();
            List<FamilyMember> familyMembers=DatabaseContext.FamilyMembers.ToList();  
            return View(familyMembers);
        }

        public ActionResult Index(int id)
        {
            DatabaseContext DatabaseContext = new DatabaseContext();
            List<FamilyMember> familymembers= DatabaseContext.FamilyMembers.Where(fm => fm.FamilyMemberTypeId == id).ToList();
            return View(familymembers);
        }

        public ActionResult Details(int id)
        {
            DatabaseContext DatabaseContext = new DatabaseContext();
            FamilyMember familyMember = DatabaseContext.FamilyMembers.Single(fm => fm.FamilyMemberId == id);

            return View(familyMember);
        }

        public ActionResult ViewFamilyMemberWithDetails()
        {
            BusinessLayer businessLayer = new BusinessLayer();
           List<FamilyMemberDetails> familyMemberDetails= businessLayer.FamilyMembersDetails.ToList();
            return View(familyMemberDetails);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post(FamilyMemberDetails familyMemberDetails)
        {
            //FamilyMemberDetails familyMemberDetails = new FamilyMemberDetails();
           // TryUpdateModel(familyMemberDetails);

            if (ModelState.IsValid)
            {
                BusinessLayer businessLayer = new BusinessLayer();

                businessLayer.AddFamilyMember(familyMemberDetails);
                return RedirectToAction("ViewFamilyMemberWithDetails");
            }
            return View();
        }

        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Get_Edit(int id)
        {
            BusinessLayer businesslayer = new BusinessLayer();
            FamilyMemberDetails familyMemberDetails= businesslayer.FamilyMembersDetails.Single(fm => fm.FamilyMemberId == id);

            return View(familyMemberDetails);
        }
        /*[HttpPost]
        public ActionResult Edit(FamilyMemberDetails familyMemberDetails)
        {
            if (ModelState.IsValid)
            { 
            BusinessLayer businessLayer = new BusinessLayer();  
            businessLayer.SaveFamilymember(familyMemberDetails);
            return RedirectToAction("ViewFamilyMemberWithDetails");
            }
            return View(familyMemberDetails);
        }*/

    /*----UpdateModel include & exclude properties helps to specify the field that we do not want
      to edit(unintended updates) even if it is specified in model repositories and view----*/

        /*[HttpPost]
        public ActionResult Edit(int id)
        {
            BusinessLayer businessLayer = new BusinessLayer();
            FamilyMemberDetails familyMemberDetails= businessLayer.FamilyMembersDetails.Single(fm => fm.FamilyMemberId == id);
            UpdateModel(familyMemberDetails, new string[] { "FamilyMemberId", "Gender", "City", "Job", "FamilyMemberTypeId" });
            //UpdateModel(familyMemberDetails, null, null, new string[] { "Name" }); 
        
        /*  if (ModelState.IsValid)
          {

              businessLayer.SaveFamilymember(familyMemberDetails);
              return RedirectToAction("ViewFamilyMemberWithDetails");
          }
          return View(familyMemberDetails);
      }*/

        /*---- Using Bind Attribute---*/

        /* [HttpPost]
        public ActionResult Edit([Bind(Include = "FamilyMemberId, Gender, City, Job, FamilyMemberTypeId")] FamilyMemberDetails familyMemberDetails)
        {
            BusinessLayer businessLayer = new BusinessLayer();
            familyMemberDetails.Name = businessLayer.FamilyMembersDetails.Single(fm => fm.FamilyMemberId == familyMemberDetails.FamilyMemberId).Name;
          
            if (ModelState.IsValid)
            {

                businessLayer.SaveFamilymember(familyMemberDetails);
                return RedirectToAction("ViewFamilyMemberWithDetails");
            }
            return View(familyMemberDetails);
        }*/

    /*----Using Interface----*/

        [HttpPost]
        public ActionResult Edit(int id)
        {
            BusinessLayer businessLayer = new BusinessLayer();
            FamilyMemberDetails familyMemberDetails = businessLayer.FamilyMembersDetails.Single(fm => fm.FamilyMemberId == id);
            UpdateModel<IFamilyMemberDetails>(familyMemberDetails);

            if (ModelState.IsValid)
            {

                businessLayer.SaveFamilymember(familyMemberDetails);
                return RedirectToAction("ViewFamilyMemberWithDetails");
            }
            return View(familyMemberDetails);  
        }
           /*Delete functionality for FamilyMember*/
        [HttpPost]
        public ActionResult Delete(int id)
        {
            BusinessLayer businessLayer = new BusinessLayer();
            FamilyMemberDetails familyMemberDetails= businessLayer.FamilyMembersDetails.Single(fm => fm.FamilyMemberId== id);

            if (ModelState.IsValid)
            {
                businessLayer.DeleteFamilyMember(familyMemberDetails);
                return RedirectToAction("ViewFamilyMemberWithDetails");
            }

            return View();
        }
    }
}









































/*[HttpPost]
public ActionResult Create(FormCollection formCollection)
{
    foreach (string key in formCollection)
    {
        //Response.Write("The key is "+key);
        Response.Write("The form collection key is "+key +"  "+formCollection[key]);
        Response.Write("</br>");

        FamilyMemberDetails familyMemberDetails = new FamilyMemberDetails();
        familyMemberDetails.Name = formCollection["Name"];
        familyMemberDetails.Gender = formCollection["Gender"];
        familyMemberDetails.City = formCollection["City"];
        familyMemberDetails.Job = formCollection["Job"];
        familyMemberDetails.FamilyMemberTypeId = Convert.ToInt32(formCollection["FamilyMemberTypeId"]);

      BusinessLayer businessLayer = new BusinessLayer();

        businessLayer.AddFamilyMember(familyMemberDetails);
        return RedirectToAction("ViewFamilyMemberWithDetails");
    }
    return View();
}*/


/*  [HttpPost]
  public ActionResult Create(string Name, string Gender, string City, string Job, int FamilyMemberTypeId)
{
  FamilyMemberDetails familyMemberDetails = new FamilyMemberDetails();
  familyMemberDetails.Name = Name;
  familyMemberDetails.Gender = Gender;
  familyMemberDetails.City = City;
  familyMemberDetails.Job = Job;
  familyMemberDetails.FamilyMemberTypeId = Convert.ToInt32(FamilyMemberTypeId);

  BusinessLayer businessLayer = new BusinessLayer();

  businessLayer.AddFamilyMember(familyMemberDetails);
  return RedirectToAction("ViewFamilyMemberWithDetails");

}*/


