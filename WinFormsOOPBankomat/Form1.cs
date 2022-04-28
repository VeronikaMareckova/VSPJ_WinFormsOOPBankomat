using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsOOPBankomat
{
    public partial class Form1 : Form
    {

        //abychom meli bankomat stale vytvoreni tak to sem dame jako datovou polozku
        //deklarace promenne
        private Bankomat bankomat; //TRIDA promenna

        //konstruktor
        public Form1()
        {
            InitializeComponent();
            //nastaveni promenne
            bankomat = new Bankomat(0); //prazdny bankomat

            //zachytavani castky
            bankomat.ZmenaCastky += Bankomat_ZmenaCastky;

            //vlozeni penez
            bankomat.Vloz(500000);
        }

        private void Bankomat_ZmenaCastky(object sender, EventArgs e)
        {
            textBox1.Text = bankomat.Castka.ToString("N0") + ",-"; //oddelelovac desetin
        }
        
        //VLOZ
        private void button1_Click(object sender, EventArgs e)
        {
            //zkonvertuje ten text co je tam zadany a vlozi to do bankomatu
            //Funguje vkladani
            bankomat.Vloz(Convert.ToUInt32(textBox2.Text)); 
        }

        //VYBER
        private void button2_Click(object sender, EventArgs e)
        {
            //overeni zda je v bankomatu dost penez
            bool povedloSe = bankomat.Vyber(Convert.ToUInt32(textBox2.Text));

            if(!povedloSe)
            {
                MessageBox.Show("V bankomatu neni dostatek hotovosti");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
