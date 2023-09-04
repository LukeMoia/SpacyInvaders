using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SpacyInvaders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ///////////////////////////// déclaration des variables ///////////////////////////
            jeux jeu = new jeux();

            ////////////////////////////// programme principale ///////////////////////////////
            jeu.AffichageMenuLangue();
        }
    }
}
