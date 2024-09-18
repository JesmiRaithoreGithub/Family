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

        public ActionResult Index1()
        {
            GroceryRepository groceryRepository = new GroceryRepository();

            List<Grocery> groceries = groceryRepository.Groceries.ToList();

            var groceryList = groceryRepository.GroceryTypes.ToList();

            var query = from gt in groceryList
                        join g in groceries on gt.GroceryItemTypeId equals g.GroceryItemTypeId
                        where g.GroceryItemTypeId == gt.GroceryItemTypeId
                        select new
                        {
                            gt.GroceryItemTypeName
                        };

            //ViewBag.GroceryItemTypeName = query.ToList(); 

            //var result = query.ToList();
            string GroceryItemTypeName = null;
            foreach (var result in query)
            {
                GroceryItemTypeName = result.GroceryItemTypeName;

                ViewBag.GroceryItemTypeName = GroceryItemTypeName;

            }
            GroceryViewModel groceryViewModel = new GroceryViewModel();

            List<GroceryViewModel> groceryViewModelList = groceries.Select(x => new GroceryViewModel
            {
                GroceryItemName = x.GroceryItemName,
                NoOfGroceryItem = x.NoOfGroceryItem,
                GroceryItemId = x.GroceryItemId,
                GroceryItemTypeId = x.GroceryItemTypeId,
                //GroceryItemTypeName=x.GroceryType.GroceryItemTypeName
                //GroceryItemTypeName = GroceryItemTypeName
                //GroceryItemTypeName = groceryList.Where(y => y.GroceryItemTypeId == x.GroceryItemTypeId)
                //.Select(y => y.GroceryItemTypeName).ToString()

            }).ToList();

            return View(groceryViewModelList);
           
            }

        public ActionResult Index()
        {
            GroceryRepository groceryRepository = new GroceryRepository();

            var groceries = (from g in groceryRepository.Groceries
                             join gt in groceryRepository.GroceryTypes
                             on g.GroceryItemTypeId equals gt.GroceryItemTypeId
                             select new GroceryViewModel
                             {
                                 GroceryItemId = g.GroceryItemId,
                                 GroceryItemName = g.GroceryItemName,
                                 NoOfGroceryItem=g.NoOfGroceryItem,
                                 GroceryItemTypeName = gt.GroceryItemTypeName
                             }).ToList();

            return View(groceries);
        }

        /* public ActionResult Index()
         {
             GroceryRepository groceryRepository = new GroceryRepository();

             List<Grocery> groceries = groceryRepository.Groceries.ToList();

             var groceryList = groceryRepository.GroceryTypes.ToList();
             var query = from gt in groceryList
                         join g in groceries on gt.GroceryItemTypeId equals g.GroceryItemTypeId
                         where g.GroceryItemTypeId == gt.GroceryItemTypeId
                         select new
                         {
                             gt.GroceryItemTypeName
                         };
             // var result = query.FirstOrDefault();
            // string GroceryItemTypeName = null;


             ViewBag.GroceryItemTypeName = query.ToList();
             return View(groceries);
         }*/

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

        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Get_Edit(int id)
        {
            GroceryRepository groceryRepository = new GroceryRepository();
            Grocery grocery= groceryRepository.Groceries.Single(gr => gr.GroceryItemId == id);
            var groceryList = groceryRepository.GroceryTypes.ToList();

            //ViewBag.GroceryItemTypeId = new SelectList(groceryList, "GroceryItemTypeId", "GroceryItemTypeName");


           
                List<SelectListItem> selectListItems = new List<SelectListItem>();

                foreach (GroceryType gr in groceryRepository.GroceryTypes)
                {
                    SelectListItem selectListItem = new SelectListItem
                    {
                        Text = gr.GroceryItemTypeName,
                        Value = gr.GroceryItemTypeId.ToString()

                        //Selected = department.IsSelected.HasValue ? department.IsSelected.Value : false
                    };
                    selectListItems.Add(selectListItem);
                }

                ViewBag.GroceryItemTypeId = selectListItems;
              
         

            return View(grocery);
        }

        [HttpPost]
        public ActionResult Edit(Grocery grocery)
        {
            if (ModelState.IsValid)
            {
                GroceryRepository groceryRepository = new GroceryRepository();
                groceryRepository.EditGrocery(grocery);
                return RedirectToAction("Index");
            }

            return View(grocery);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            GroceryRepository groceryRepository = new GroceryRepository();
            Grocery grocery= groceryRepository.Groceries.Single(gr => gr.GroceryItemId == id);
           
            if (ModelState.IsValid)
            {
                groceryRepository.DeleteGrocery(grocery);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}