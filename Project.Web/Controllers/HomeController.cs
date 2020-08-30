using MongoDB.Bson;
using Newtonsoft.Json.Bson;
using Project.Service;
using Project.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }
        private INoteRepository _noteRepository;
        public HomeController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }
        public ActionResult Index()
        {
            ViewBag.Notes = _noteRepository.GetAll();
            return View();
        }

        public ActionResult Add()
        {
            ViewBag.Title = "Add Note";
            ViewBag.Message = "Please type in the note that you want to store.";

            return View();
        }

        [HttpPost]
        public ActionResult Add(Note notemodel)
        {
            _noteRepository.Add(notemodel);
            return RedirectToAction("Index");
        }

        public ActionResult Update(string id)
        {
            ViewBag.Note = _noteRepository.GetById(id);
            ViewBag.Success = TempData["Success"];
            return View();
        }

        [HttpPost]
        public ActionResult Update(string id, Note update)
        {
            Note updated = _noteRepository.Update(update);
            TempData["Success"] = "Note Updated Successfully!";
            return RedirectToAction("Update");
        }

        public ActionResult Delete(string id)
        {
            ViewBag.Note = _noteRepository.GetById(id);
            ViewBag.Warning = "Are you sure you want to delete this note?";
            return View();

        }

        [HttpPost]
        public ActionResult Delete(string id, bool confirm = true)
        {
            _noteRepository.Delete(id);
            return RedirectToAction("Index");

        }

        public ActionResult About()
        {
            return View();

        }
    }
}