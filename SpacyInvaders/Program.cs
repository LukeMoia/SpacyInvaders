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

    class jeux
    {
        Timer timTimerJeux = new Timer();
        int intLangue { get; set; }
        string strPoints = "";
        string strFPS = "FPS: ";
        int intPoints = 0;
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

        private void AffichageMenuPourJouer()
        {
            string strPlay = "";
            string strOption = "";
            string strResult = "";
            string strQuit = "";

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
            // méthode pour pouvoir faire la boucle
            BoucleMenu();
        }

        private void BoucleMenu()
        {
            ConsoleKey cskConsole = ConsoleKey.A;
            const int intMax = 6;
            const int intMin = 3;
            int x = intMin;

            /*Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Red();*/
            for (; cskConsole != ConsoleKey.Enter;)
            {
                Console.SetCursorPosition(0,x);
                cskConsole = Console.ReadKey().Key;
                if (cskConsole == ConsoleKey.DownArrow || cskConsole == ConsoleKey.S)
                {
                    if (x != intMax)
                    {
                        x++;
                    }
                    else
                    {
                        x = intMin;
                    }
                }
                else if (cskConsole == ConsoleKey.UpArrow || cskConsole == ConsoleKey.W)
                {
                    if (x != intMin)
                    {
                        x--;
                    }
                    else
                    {
                        x = intMax; 
                    }
                }
            }
            if(x - intMin == 0)
            {
                // méthode pour lancer le jeu
                LancerLeJeu();
                for (;;)
                {

                }
            }
            else if (x - intMin == 1)
            {
                // méthode pour les options
                
            }
            else if (x - intMin == 2)
            {
                // méthode pour les résultats
                
            }
        }

        private void LancerLeJeu()
        {
            timTimerJeux.Enabled = true;
            timTimerJeux.AutoReset = true;
            timTimerJeux.Interval = 600;
            timTimerJeux.Start();
            timTimerJeux.Elapsed += Jeux;
        }
        private void Jeux(object valeur, System.Timers.ElapsedEventArgs Temps)
        {
            Console.Clear();
            Console.SetCursorPosition(Console.BufferWidth - strPoints.Length - 1, 0);
            Console.Write(strPoints + intPoints);
            Console.SetCursorPosition(Console.BufferWidth - strPoints.Length - 1, 1);
            Console.Write(strFPS + intLangue);
        }
    }
}
