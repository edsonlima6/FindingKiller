using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using FindKiller.Models;

namespace FindKiller.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
            LoadData();
        }

        private List<Gun> listGun                   { get; set; }
        private List<Suspect> listSuspect           { get; set; }
        private List<Local> listLocal               { get; set; }

        [HttpGet]
        public ActionResult Index()
        {
            var mvcName = typeof(Controller).Assembly.GetName();
            var isMono = Type.GetType("Mono.Runtime") != null;

            ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
            ViewData["Runtime"] = isMono ? "Mono" : ".NET";
            Suspect suspect = new Suspect();




            return View();
        }

        [HttpPost]
        public async Task<ActionResult> GetSuspect(Investigador investigador)
        {
            var mvcName = typeof(Controller).Assembly.GetName();
            var isMono = Type.GetType("Mono.Runtime") != null;

            ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
            ViewData["Runtime"] = isMono ? "Mono" : ".NET";



            return await Task.Run(() => { return Json( investigador, JsonRequestBehavior.AllowGet); });

            //return  Json(new { suspect, JsonRequestBehavior.AllowGet});


        }

        [HttpGet]
        public async Task<ActionResult> GetSuspect()
        {
            return await Task.Run(() => { return Json(new { tome = "tome"}, JsonRequestBehavior.AllowGet); });

        }


        private void LoadData()
        {
            listGun = new List<Gun>();
            listLocal = new List<Local>();
            listSuspect = new List<Suspect>();

            listGun.Add(new Gun { GunId = 1, Name = "Cajado Devastador" });
            listGun.Add(new Gun { GunId = 2, Name = "Phaser" });
            listGun.Add(new Gun { GunId = 3, Name = "Peixeira" });
            listGun.Add(new Gun { GunId = 4, Name = "Trezoitao" });
            listGun.Add(new Gun { GunId = 5, Name = "Sabre de Luz" });
            listGun.Add(new Gun { GunId = 6, Name = "Bomba" });

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

            listSuspect.Add(new Suspect { SuspectId = 1, Name = "Esqueleto" });
            listSuspect.Add(new Suspect { SuspectId = 2, Name = "Khan" });
            listSuspect.Add(new Suspect { SuspectId = 3, Name = "Dath Vader" });
            listSuspect.Add(new Suspect { SuspectId = 4, Name = "SideShow Bob" });
            listSuspect.Add(new Suspect { SuspectId = 5, Name = "Coringa" });
            listSuspect.Add(new Suspect { SuspectId = 6, Name = "Duende Verde" });

        }
    }
}
