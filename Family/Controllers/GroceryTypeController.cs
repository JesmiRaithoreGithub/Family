using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopGroceryBusinessLayer.Models;

namespace Family.Controllers
{
    public class GroceryTypeController : Controller
    {
        // GET: GroceryType
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ItemType()
        {
            GroceryTypeRepository groceryRepository = new GroceryTypeRepository();
            List<GroceryType> groceryTypes = groceryRepository.GroceryTypes.ToList();
            return View(groceryTypes);
        }

        [HttpGet]
        [ActionName("AddItemType")]
        public ActionResult AddItemTypeGet()
        {

            return View();
        }

        [HttpPost]
        [ActionName("AddItemType")]
        public ActionResult AddItemTypePost(GroceryType groceryType)
        {
            if (ModelState.IsValid)
            {
                GroceryTypeRepository groceryTypeRepository = new GroceryTypeRepository();
                groceryTypeRepository.Add(groceryType);
                return RedirectToAction("ItemType");
            }
            return View();
        }

        [HttpGet]
        [ActionName("EditItemType")]
        public ActionResult EditItemTypeGet(int id)
        {
            GroceryTypeRepository groceryTypeRepository = new GroceryTypeRepository();
            GroceryType groceryType= groceryTypeRepository.GroceryTypes.Single(gt => gt.GroceryItemTypeId == id);
            return View(groceryType);
        }

        [HttpPost]
        [ActionName("EditItemType")]
        public ActionResult EditItemTypePost(GroceryType groceryType)
        {
            if (ModelState.IsValid)
            {
                GroceryTypeRepository groceryTypeRepository = new GroceryTypeRepository();
                groceryTypeRepository.Edit(groceryType);
                return RedirectToAction("ItemType");
            }
            return View(groceryType);
        }
    }
}