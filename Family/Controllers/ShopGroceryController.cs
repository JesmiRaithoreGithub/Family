using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopGroceryBusinessLayer.Models;
using Family.Models;

namespace Family.Controllers
{
    public class ShopGroceryController : Controller
    {
        // GET: Grocery
        public ActionResult Index()
        {
            GroceryRepository groceryRepository = new GroceryRepository();

            List<Grocery> groceries = groceryRepository.Groceries.ToList();

            return View(groceries);
        }

        /* public List<Grocery> Index()
         {
             GroceryRepository groceryRepository = new GroceryRepository();
             var groceries = groceryRepository.Groceries
                        .Select(b => new Grocery()
                        {
                            GroceryItemId = b.GroceryItemId,
                            GroceryItemName = b.GroceryItemName,
                            NoOfGroceryItem = b.NoOfGroceryItem,
                            GroceryTypes = b.GroceryTypes
                        });
             return groceries.ToList<Grocery>();
         }*/


        public ActionResult ItemType()
        {
            GroceryRepository groceryRepository = new GroceryRepository();
            List<GroceryType> groceryTypes = groceryRepository.GroceryTypes.ToList();
            return View(groceryTypes);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            GroceryRepository groceryRepository = new GroceryRepository();
            var groceryList = groceryRepository.GroceryTypes.ToList();
            ViewBag.GroceryItemTypeId = new SelectList(groceryList, "GroceryItemTypeId", "GroceryItemTypeName");
            //ViewBag.GroceryItemTypeId = new SelectList(groceryRepository.GroceryTypes, "GroceryItemTypeId", "GroceryItemTypeName");
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post(Grocery grocery)
        {
            //Grocery grocery = new Grocery();

            if (ModelState.IsValid)
            {
                
                GroceryRepository groceryRepository = new GroceryRepository();
                var groceryList = groceryRepository.GroceryTypes.ToList();
               // ViewData["GroceryItemType"] = new SelectList(groceryList, "GroceryItemTypeId", "GroceryItemTypeName");

                // ViewBag.GroceryItemTypeId = new SelectList(groceryRepository.GroceryTypes, "GroceryItemTypeId", "GroceryItemTypeName");
                groceryRepository.Add(grocery);

                ViewBag.GroceryItemType = new SelectList(groceryList, "GroceryItemTypeId", "GroceryItemTypeName");


                return RedirectToAction("Index");

            }
            return View();
        }
    }
}