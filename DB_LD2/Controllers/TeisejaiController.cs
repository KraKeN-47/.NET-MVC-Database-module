using DB_LD2.Repos;
using DB_LD2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DB_LD2.Controllers
{
    public class TeisejaiController : Controller
    {
        TeisejaiRepository teisRepo = new TeisejaiRepository();
        // GET: Teisejai
        public ActionResult Index()
        {
            return View(teisRepo.getTeisejai());
        }
        // GET: Teisejas to Delete
        public ActionResult Delete(int id)
        {
            return View(teisRepo.getTeisejas(id));
        }
        // Post deletion of teisėjas
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            teisRepo.deleteTeisejas(id);
            return RedirectToAction("Index");
        }
        // GET: Teisejas to Edit
        public ActionResult Edit(int id)
        {
            return View(teisRepo.getTeisejas(id));
        }

        // POST: Edited Teisejas to DataBase
        [HttpPost]
        public ActionResult Edit(int id, TeisejaiEditViewModeL teisejas)
        {
            teisRepo.editTeisejas(teisejas);
            return RedirectToAction("Index");
        }

    }
}