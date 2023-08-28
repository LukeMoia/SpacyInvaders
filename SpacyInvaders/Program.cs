using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    class jeux
    {
        int intLangue { get; set; }
        public void AffichageMenuLangue()
        {
            Console.Write("Language (0=fr, 1=en) : ");
            try
            {
                intLangue = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                intLangue = -1;
            }
            if (intLangue == 0 || intLangue == 1)
            {
                Console.Clear();
                AffichageMenuPourJouer();
            }
        }

        public void AffichageMenuPourJouer()
        {
            string strPlay = "";
            string strOption = "";
            string strResult = "";
            string strQuit = "";
            string strPoints = "";
            string strFPS = "FPS: ";

            if (intLangue == 0)
            {
                strPlay = "1.Jouer";
                strOption = "2.Options";
                strResult = "3.Résultats";
                strQuit = "4.Quitter";
                strPoints = "Points: ";
            }
            else if (intLangue == 1)
            {
                strPlay = "1.Play";
                strOption = "2.Options";
                strResult = "3.Highscore";
                strQuit = "4.Quit";
                strPoints = "Points: ";
            }

            Console.WriteLine ($"SpicyInvader II\n---------------\n\n{strPlay}\n{strOption}\n{strResult}\n{strQuit}");
            Console.ReadLine();
        }
    }
}
