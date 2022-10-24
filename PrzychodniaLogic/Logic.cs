using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Przychodnia;

namespace PrzychodniaLogic
{
    internal class Logic
    {
        private void addPatient(string name, string surrname, string phoneNumber, string pesel)
        {
            PrzychodniaEntities db = new PrzychodniaEntities();

            Pacjenci pacjent = new Pacjenci()
            {
                Imie = name,
                Nazwisko = surrname,
                Numer_telefonu = phoneNumber,
                PESEL = pesel
            };
            db.Pacjencis.Add(pacjent);
            db.SaveChanges();

        }

        public void addVisit(Pacjenci pacjent, int id_lekarza)
        {
            PrzychodniaEntities db = new PrzychodniaEntities();
            Wizyty wizyty = new Wizyty()
            {
                ID_lekarz = id_lekarza,
                ID_pacjent = db.Pacjencis.Select(x => x.ID_Pacjent).Last()
            };

        }
    }
}
