using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SpacyInvaders
{
    internal class Program
    {
        /// <summary>
        /// La classe Main sert à initialiser et lancé la classe jeu
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ///////////////////////////// déclaration des variables ///////////////////////////
            jeux jeu = new jeux();

            ////////////////////////////// programme principale ///////////////////////////////
            jeu.AffichageMenuLangue(); // démarre le jeu
        }
    }
}