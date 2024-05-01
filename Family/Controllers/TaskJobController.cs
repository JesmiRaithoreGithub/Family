using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Family.Models;

namespace Family.Controllers
{
    public class TaskJobController : Controller
    {
        private TaskContext db = new TaskContext();

        // GET: TaskJob
        public ActionResult Index()
        {
            var tasks = db.Tasks.Include(t => t.FamilyMember);
            return View(tasks.ToList());
        }

        // GET: TaskJob/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // GET: TaskJob/Create
        public ActionResult Create()
        {
            ViewBag.Task_FamilyMemberId = new SelectList(db.FamilyMembers, "FamilyMemberId", "Name");
            return View();
        }

        // POST: TaskJob/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Task_Id,Task_Name,Task_Preparation,Task_Duration,Task_Status,Task_FamilyMemberId")] Task task)
        {
            if (string.IsNullOrEmpty(task.Task_Name))
            {
                ModelState.AddModelError("Task_Name","Name Field is required");
            }
            if (ModelState.IsValid)
            {
                db.Tasks.Add(task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Task_FamilyMemberId = new SelectList(db.FamilyMembers, "FamilyMemberId", "Name", task.Task_FamilyMemberId);
            return View(task);
        }

        // GET: TaskJob/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            ViewBag.Task_FamilyMemberId = new SelectList(db.FamilyMembers, "FamilyMemberId", "Name", task.Task_FamilyMemberId);
            return View(task);
        }

        // POST: TaskJob/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       // public ActionResult Edit([Bind(Include = "Task_Id,Task_Name,Task_Preparation,Task_Duration,Task_Status,Task_FamilyMemberId")] Task task)
       public ActionResult Edit([Bind(Exclude  = "Task_Name")] Task task)
        {
            Task Taskdb = db.Tasks.Single(x => x.Task_Id == task.Task_Id);

            //Taskdb.Task_Id = task.Task_Id;
            Taskdb.Task_Preparation = task.Task_Preparation;
            Taskdb.Task_Duration = task.Task_Duration;
            Taskdb.Task_Status = task.Task_Status;
            Taskdb.Task_FamilyMemberId = task.Task_FamilyMemberId;
            task.Task_Name = Taskdb.Task_Name;


            if (ModelState.IsValid)
            {
                db.Entry(Taskdb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Task_FamilyMemberId = new SelectList(db.FamilyMembers, "FamilyMemberId", "Name", task.Task_FamilyMemberId);
            return View(task);
        }

        // GET: TaskJob/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: TaskJob/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Task task = db.Tasks.Find(id);
            db.Tasks.Remove(task);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
