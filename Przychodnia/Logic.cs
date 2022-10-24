using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia
{
    public class Logic
    {
        public void addPatient(string name, string surrname, string phoneNumber, string pesel, int id_lekarza)
        {
            PrzychodniaEntities db = new PrzychodniaEntities();
            int idPacjent = db.Pacjencis.Where(p => p.PESEL == pesel).Select(x => x.ID_Pacjent).Distinct().FirstOrDefault();
            

            Pacjenci pacjent = new Pacjenci()
            {
                Imie = name,
                Nazwisko = surrname,
                Numer_telefonu = phoneNumber,
                PESEL = pesel
            };
            db.Pacjencis.Add(pacjent);
            db.SaveChanges();
           
                      

            Wizyty wizyty = new Wizyty()
            {
                ID_lekarz = id_lekarza,
                ID_pacjent = idPacjent
            };

            db.Wizyties.Add(wizyty);
            db.SaveChanges();
        }


    }
}
