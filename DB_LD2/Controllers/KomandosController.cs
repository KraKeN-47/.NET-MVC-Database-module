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
    public class KomandosController : Controller
    {
        KomandosRepository komandosRepo = new KomandosRepository();
        DivizionaiRepository diviRepo = new DivizionaiRepository();
        // GET: Komandos
        public ActionResult Index()
        {
            return View(komandosRepo.getKomandos());
        }

        // Delete komanda
        public ActionResult Delete(int id)
        {
            komandosRepo.deleteKomanda(id);
            return RedirectToAction("Index");
        }

        // Edit komanda
        public ActionResult Edit(int id)
        {
            return View(komandosRepo.getKomanda(id));
        }

        // Post edited komanda
        [HttpPost]
        public ActionResult Edit(int id, KomandosEditViewModel editedKomanda)
        {
            komandosRepo.editKomanda(editedKomanda);
            return RedirectToAction("Index");
        }

        // Papildyti Foreign key
        public void FillDivision(KomandosEditViewModel divizionas)
        {
            var divizionai = diviRepo.getDivizionai();
            List<SelectListItem> selectListDivizionai = new List<SelectListItem>();

            foreach (var item in divizionai)
            {
                selectListDivizionai.Add(new SelectListItem { Value = Convert.ToString(item.ID), Text = $"{item.Name}" });
            }

            divizionas.Divizionai = selectListDivizionai;
        }

        public ActionResult CreateMultipleKomandos()
        {
            KomandosEditViewModel komanda = new KomandosEditViewModel();
            FillDivision(komanda);
            return View(komanda);
        }


        public JsonResult SaveData(string getepassdata)//WebMethod to Save the data  
        {
            try
            {
                var serializeData = JsonConvert.DeserializeObject<List<KomandosEditViewModel>>(getepassdata);

                foreach (var data in serializeData)
                {
                    komandosRepo.createKomanda(data);
                }
            }
            catch (Exception ex)
            {
                return Json("fail");
    }
            return Json("success");
        }
    }
}