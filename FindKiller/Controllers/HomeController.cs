using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using FindKiller.Models;
using FindKiller.Models.DB;

namespace FindKiller.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            LoadData();
        }


        [HttpGet]
        public ActionResult Index()
        {
            Investigador inv = new Investigador();
            using (var db = new ContextDB())
            {
                inv.Local = db.Local.OrderBy(l => l.LocalId).FirstOrDefault();
                inv.Gun = db.Gun.OrderBy(g => g.GunId).FirstOrDefault();
                inv.Suspect = db.Suspect.OrderBy(s => s.SuspectId).FirstOrDefault();
            }
            

            return View(inv);
        }

        [HttpPost]
        public async Task<ActionResult> GetSuspect(Investigador investigador)
        {

            try
            {
                using (ContextDB db = new ContextDB())
                {
                    ViewBag.investigador = null;
                    switch (Convert.ToInt32(investigador.pLocal))
                    {
                        case 1:
                            var suspect = db.Suspect.Where(s => s.SuspectId == investigador.Suspect.SuspectId).FirstOrDefault();
                            if (suspect != null)
                            {
                                db.Suspect.Remove(suspect);
                                db.SaveChanges();
                            }
                            investigador.Suspect = db.Suspect.OrderBy(s => s.SuspectId).FirstOrDefault();
                            break;

                        case 2:
                            var local = db.Local.Where(l => l.LocalId == investigador.Local.LocalId).FirstOrDefault();
                            if (local != null)
                            {
                                db.Local.Remove(local);
                                db.SaveChanges();
                            }
                            investigador.Local = db.Local.OrderBy(l => l.LocalId).FirstOrDefault();
                            break;

                        case 3:
                            var gun = db.Gun.Where(g => g.GunId == investigador.Gun.GunId).FirstOrDefault();
                            if (gun != null)
                            {
                                db.Gun.Remove(gun);
                                db.SaveChanges();
                            }
                            investigador.Gun = db.Gun.OrderBy(g => g.GunId).FirstOrDefault();
                            break;

                        case 0:
                            string sql = "delete from gun; delete from local; delete from Suspect;";
                            db.Database.ExecuteSqlCommand(sql);
                            break;
                    }

                }


                
                return await Task.Run(() => { return Json(investigador, JsonRequestBehavior.AllowGet); });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void LoadData()
        {
            try
            {
                 List<Gun> listGun = new List<Gun>();
                 List<Suspect> listSuspect = new List<Suspect>();
                 List<Local> listLocal = new List<Local>();

                using (ContextDB db = new ContextDB())
                {
                    if (!db.Database.Exists())
                    {
                        db.Database.CreateIfNotExists();
                    }

                    if (db.Gun.Count() == 0 && db.Local.Count() == 0 && db.Suspect.Count() == 0)
                    {


                        listGun.Add(new Gun { GunId = 1, Name = "Cajado Devastador" });
                        listGun.Add(new Gun { GunId = 2, Name = "Phaser" });
                        listGun.Add(new Gun { GunId = 3, Name = "Peixeira" });
                        listGun.Add(new Gun { GunId = 4, Name = "Trezoitao" });
                        listGun.Add(new Gun { GunId = 5, Name = "Sabre de Luz" });
                        listGun.Add(new Gun { GunId = 6, Name = "Bomba" });

                        db.Gun.AddRange(listGun);
                        db.SaveChanges();


                        listLocal.Add(new Local { LocalId = 1, Name = "Eternia" });
                        listLocal.Add(new Local { LocalId = 2, Name = "Vulcano" });
                        listLocal.Add(new Local { LocalId = 3, Name = "Tattoine" });
                        listLocal.Add(new Local { LocalId = 4, Name = "Springfield" });
                        listLocal.Add(new Local { LocalId = 5, Name = "Gotham" });
                        listLocal.Add(new Local { LocalId = 6, Name = "Nova York" });
                        listLocal.Add(new Local { LocalId = 7, Name = "Siberia" });
                        listLocal.Add(new Local { LocalId = 8, Name = "Machu Picchu" });
                        listLocal.Add(new Local { LocalId = 9, Name = "Show Katinguele" });
                        listLocal.Add(new Local { LocalId = 10, Name = "Sao Paulo" });

                        db.Local.AddRange(listLocal);
                        db.SaveChanges();


                        listSuspect.Add(new Suspect { SuspectId = 1, Name = "Esqueleto" });
                        listSuspect.Add(new Suspect { SuspectId = 2, Name = "Khan" });
                        listSuspect.Add(new Suspect { SuspectId = 3, Name = "Dath Vader" });
                        listSuspect.Add(new Suspect { SuspectId = 4, Name = "SideShow Bob" });
                        listSuspect.Add(new Suspect { SuspectId = 5, Name = "Coringa" });
                        listSuspect.Add(new Suspect { SuspectId = 6, Name = "Duende Verde" });

                        db.Suspect.AddRange(listSuspect);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

    }
}
