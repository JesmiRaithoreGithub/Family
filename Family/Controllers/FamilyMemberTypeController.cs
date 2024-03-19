using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Family.Models;

namespace Family.Controllers
{
    public class FamilyMemberTypeController : Controller
    {
        // GET: FamilyMemberType
        public ActionResult Index()
        {
            DatabaseContext DatabaseContext = new DatabaseContext();
            List<FamilyMemberType> familyMemberTypes = DatabaseContext.FamilyMemberTypes.ToList();
            return View(familyMemberTypes);
        }
    }
}