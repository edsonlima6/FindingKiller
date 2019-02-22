using System;
namespace FindKiller.Models
{
    public class Investigador
    {
        public Investigador()
        {
            Local = new Local();
            Suspect = new Suspect();
            Gun = new Gun();
        }

        public string pLocal { get; set; }
        public string pSuspect { get; set; }
        public string pGun { get; set; }

        public Local Local { get; set; }
        public Suspect Suspect { get; set; }
        public Gun Gun { get; set; }
               
    }
}
