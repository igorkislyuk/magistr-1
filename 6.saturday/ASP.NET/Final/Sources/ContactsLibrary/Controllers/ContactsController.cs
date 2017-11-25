using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactsLibrary.Models;

namespace ContactsLibrary.Controllers
{
    public class ContactsController : Controller
    {

        private ContactContext db = new ContactContext();
        
        // GET: Contacts
        public ActionResult Index()
        {
            var list = db.Contacts.ToList();
            return View(list);
        }

        // GET: Contacts/Details/5
        public ActionResult Details(ContactModel model)
        {
            return View(model);
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        [HttpPost]
        public ActionResult Create(ContactModel model)
        {
            db.Contacts.Add(model);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.Contacts.ToList().First(m => m.Id == id));
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        public ActionResult Edit(ContactModel model)
        {
            var modelToDelete = db.Contacts.ToArray().First(m => m.Id == model.Id);

            if (modelToDelete != null)
            {
                db.Contacts.Remove(modelToDelete);

                db.Contacts.Add(model);

                db.SaveChanges();

                return View(model);

            }

            return RedirectToAction("Index");
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int id)
        {
            var model = db.Contacts.ToList().First(m => m.Id == id);
            return View(model);
        }

        // POST: Contacts/Delete/5
        [HttpPost]
        public ActionResult Delete(ContactModel model)
        {
            var modelToDelete = db.Contacts.ToList().First(m => m.Id == model.Id);
            if (modelToDelete != null)
            {
                db.Contacts.Remove(modelToDelete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
