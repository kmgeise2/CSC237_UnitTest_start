using CSC237_UnitTest_start.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CSC237_UnitTest_start.Controllers
{
    public class ContactController : Controller
    {
        private IUnitOfWork data { get; set; }
        public ContactController(IUnitOfWork rep) => data = rep;

        public ViewResult Details(int id)
        {
            var options = new QueryOptions<Contact>
            {
                Includes = "Category",
                Where = c => c.ContactId == id
            };
            var contact = data.Contacts.Get(options);

            return View(contact);
        }

        [HttpGet]
        public ViewResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Categories = data.Categories.List(new QueryOptions<Category> { OrderBy = c => c.Name });
            return View("Edit", new Contact());
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Categories = data.Categories.List(new QueryOptions<Category> { OrderBy = c => c.Name });

            var options = new QueryOptions<Contact>
            {
                Includes = "Category",
                Where = c => c.ContactId == id
            };
            var contact = data.Contacts.Get(options);

            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            string action = (contact.ContactId == 0) ? "Add" : "Edit";

            if (ModelState.IsValid)
            {
                if (action == "Add")
                {
                    contact.DateAdded = DateTime.Now;
                    data.Contacts.Insert(contact);
                }
                else
                {
                    data.Contacts.Update(contact);
                }
                data.Save();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = action;
                ViewBag.Categories = data.Categories.List(new QueryOptions<Category> { OrderBy = c => c.Name });
                return View(contact);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var options = new QueryOptions<Contact>
            {
                Includes = "Category",
                Where = c => c.ContactId == id
            };
            var contact = data.Contacts.Get(options);

            return View(contact);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Contact contact)
        {
            data.Contacts.Delete(contact);
            data.Save();
            return RedirectToAction("Index", "Home");
        }
    }
}
