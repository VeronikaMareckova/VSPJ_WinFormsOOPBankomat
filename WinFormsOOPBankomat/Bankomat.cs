using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsOOPBankomat
{
    public class Bankomat
    {
        //deklarace atributu
        private uint castka; //castka bude nam uchovavat kolik tam je penez

        //Konstruktor
        public Bankomat(uint vklad)
        {
            castka = vklad;
        }

       //Vlastnost
       public uint Castka
        {
            get { return castka; } //castku si muze precit kazdy

            private set //private aby castku nemohl kazdy nastavit
                        //muze do toho zapisovat jen ta trida
            {
                castka = value; //ulozime castku
                //ZmenaCastky MUZE nekdo sledovat 
                if (ZmenaCastky != null)  //a to muzeme udelat pouze v pripade ze nekdo posloucha
                    ZmenaCastky(this, EventArgs.Empty); //oznamime ze doslo ke zmene castky
            }
        }

        //METODY
        public bool Vyber(uint internicastka)
        {
            //podminka mám dost penez v bankomatu
            if(internicastka <= Castka)
            {
                //odectu Castku z bankomatu
                Castka -= internicastka;
                //a oznamum TRUE ze se to povedlo
                return true;
            }
            return false;  //v pripade ze podminka nani splnena vratim false
        }

        public void Vloz(uint vlozenaCastka)
        {
            Castka += vlozenaCastka;
        }

        //UDALOST       //13:30
        //evet + datovy typ udalosti (tj. TRIDA DELEGAT)
        //EventHandler pouze oznami udalost a nic neprenasi
        //Udalost zadny kod nema
        //navysuji se pouze metody ktere tam jsou
        public event EventHandler ZmenaCastky;

    }
}
