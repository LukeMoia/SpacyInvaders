using System;
using System.Timers;
using System.Threading;

namespace SpacyInvaders
{
    internal class jeux
    {
        System.Timers.Timer timTimerJeux = new System.Timers.Timer();
        int intLangue { get; set; }
        string strPoints = "";
        string strFPS = "FPS: ";
        int intPoints = 0;
        string strPlay = "";
        string strOption = "";
        string strResult = "";
        string strQuit = "";
        int AffichageWidth = Console.BufferWidth; // pour l'affichage des points et FPS
        Vaisseau vaisseau = new Vaisseau(10, "A");
        Ennemi ennemi1 = new Ennemi(1,"E");
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

            Console.WriteLine($"SpicyInvader II\n---------------\n\n{strPlay}\n{strOption}\n{strResult}\n{strQuit}");
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
                Console.Clear();
                Console.WriteLine($"SpicyInvader II\n---------------\n\n{strPlay}\n{strOption}\n{strResult}\n{strQuit}");
                Console.SetCursorPosition(0, x);
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
            if (x - intMin == 0)
            {
                // méthode pour lancer le jeu
                LancerLeJeu();
                for (; ; )
                {
                    cskConsole = Console.ReadKey().Key;
                    if (cskConsole == ConsoleKey.Spacebar && vaisseau.MissileAfficher())
                    {
                        vaisseau.tirer();
                    }
                    if (cskConsole == ConsoleKey.RightArrow)
                    {
                        vaisseau.ChangementMouvement(1);
                        vaisseau.DeplacementVaisseau();
                    }
                    if (cskConsole == ConsoleKey.LeftArrow)
                    {
                        vaisseau.ChangementMouvement(-1);
                        vaisseau.DeplacementVaisseau();
                    }
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
            Console.Clear();
            timTimerJeux.Enabled = true;
            timTimerJeux.AutoReset = true;
            timTimerJeux.Interval = 150;
            timTimerJeux.Start();
            timTimerJeux.Elapsed += Jeux;
            AfficherPointFPS();
        }
        private void Jeux(object valeur, System.Timers.ElapsedEventArgs Temps)
        {
            if (AffichageWidth != Console.BufferWidth)
            {
                Console.Clear();
                AfficherPointFPS();
                AffichageWidth = Console.BufferWidth;
            }
            Console.CursorVisible = false;
            vaisseau.AfficherVaisseau();
            vaisseau.MissileMouvement();
            ennemi1.DeplacementVaisseau();
            ennemi1.DirectionEnnemi();
        }

        public void AfficherPointFPS()
        {
            Console.SetCursorPosition(Console.BufferWidth - strPoints.Length - 1, 0);
            Console.Write(strPoints + intPoints);
            Console.SetCursorPosition(Console.BufferWidth - strPoints.Length - 1, 1);
            Console.Write(strFPS + intLangue);
        }
    }
}
