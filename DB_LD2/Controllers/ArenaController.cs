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
    public class ArenaController : Controller
    {
        ArenaRepository ArenaRepo = new ArenaRepository();
        
        // GET: Arena
        public ActionResult Index()
        {
            return View(ArenaRepo.getArenos());
        }

        //GET: Show arena id to delete
        public ActionResult Delete(int id)
        {
            return View(ArenaRepo.getArena(id));
        }

        //Post: Delete arena
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            ArenaRepo.deleteArena(id);
            return RedirectToAction("Index");
        }

        //Post: Display edit
        public ActionResult Edit(int id)
        {
            return View(ArenaRepo.getArena(id));
        }

        //Post: Edit arena
        [HttpPost]
        public ActionResult Edit(int id, ArenaEditViewModel arenaEdited)
        {
            ArenaRepo.editArena(arenaEdited);
            return RedirectToAction("Index");
        }
        //GET: Get new Arena
        public ActionResult Create()
        {
            ArenaEditViewModel newArena = new ArenaEditViewModel();
            return View(newArena);
        }
        //POST: Post new arena
        [HttpPost]
        public ActionResult Create(ArenaEditViewModel newArena)
        {
            try
            {
                ArenaRepo.addArena(newArena);
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                return Content("ID Turi būti unikalus");
            }
            return RedirectToAction("Index");
        }
        //GET: Two new arenas
        public ActionResult CreateMultipleArenas()
        {
            return View();
        }


        public JsonResult SaveData(string getepassdata)//WebMethod to Save the data  
        {
            try
            {
                var serializeData = JsonConvert.DeserializeObject<List<ArenaEditViewModel>>(getepassdata);

                foreach (var data in serializeData)
                {
                    ArenaRepo.addArena(data);
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