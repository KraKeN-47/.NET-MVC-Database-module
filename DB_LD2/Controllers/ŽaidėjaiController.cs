using DB_LD2.Repos;
using DB_LD2.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DB_LD2.Controllers
{
    public class ŽaidėjaiController : Controller
    {
        ŽaidėjaiRepository zaidRepo = new ŽaidėjaiRepository();
        KomandosRepository komaRepo = new KomandosRepository();
        // GET: Žaidėjai
        public ActionResult Index()
        {
            return View(zaidRepo.getZaidejai());
        }
        // GET: Žaidėjai on Edit
        public ActionResult Edit(int id)
        {
            return View(zaidRepo.getZaidejas(id));
        }
        // POST: Žaidėjai on Edit
        [HttpPost]
        public ActionResult Edit(int id, ŽaidėjaiEditViewModel zaidejas)
        {
            zaidRepo.editZaidejas(zaidejas);
            return RedirectToAction("Index");
        }
        // GET: Žaidėjai on Delete
        public ActionResult Delete(int id)
        {
            return View(zaidRepo.getZaidejas(id));
        }
        // POST: Žaidėjai on Delete
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            zaidRepo.deleteZaidejas(id);
            return RedirectToAction("Index");
        }

        // Papildyti Foreign key
        public void FillTeams(ŽaidėjaiEditViewModel zaidejas)
        {
            var komandos = komaRepo.getKomandos();
            List<SelectListItem> selectListKomandos = new List<SelectListItem>();

            foreach (var item in komandos)
            {
                selectListKomandos.Add(new SelectListItem { Value= Convert.ToString(item.Komandos_ID), Text=$"{item.Divizionas} - {item.Komandos_Pav} - {item.Miestas} - {item.Valstija}" });
            }

            zaidejas.Komandu_ID = selectListKomandos;
        }

        // Create žaidėjas
        public ActionResult Create()
        {
            ŽaidėjaiEditViewModel newPlayer = new ŽaidėjaiEditViewModel();
            FillTeams(newPlayer);
            return View(newPlayer);
        }
        // POST: post new žaidėjas to DB
        [HttpPost]
        public ActionResult Create(ŽaidėjaiEditViewModel newZaidejas)
        {
            try
            {
                zaidRepo.createZaidejas(newZaidejas);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return Content(ex.Message);
            }
            return RedirectToAction("Index");
        }

        public ActionResult CreateMultipleŽaidėjai()
        {
            ŽaidėjaiEditViewModel newPlayer = new ŽaidėjaiEditViewModel();
            FillTeams(newPlayer);
            return View(newPlayer);
        }


        public JsonResult SaveData(string getepassdata)//WebMethod to Save the data  
        {
            try
            {
                var serializeData = JsonConvert.DeserializeObject<List<ŽaidėjaiEditViewModel>>(getepassdata);

                foreach (var data in serializeData)
                {
                   zaidRepo.createZaidejas(data);
                }
            }
            catch (Exception)
            {
                return Json("fail");
            }
            return Json("success");
        }
    }
}