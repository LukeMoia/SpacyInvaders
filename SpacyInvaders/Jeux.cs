using System;
using System.Timers;
using System.Threading;
using System.Collections.Generic;

namespace SpacyInvaders
{
    internal class jeux
    {
        System.Timers.Timer timTimerJeux = new System.Timers.Timer();
        int intLangue { get; set; }
        string strPoints = "";
        string strFPS = "FPS: ";
        int intPoints = 0;
        int intCompteur = 0;
        string strPlay = "";
        string strOption = "";
        string strResult = "";
        string strQuit = "";
        int AffichageWidth = Console.BufferWidth; // pour l'affichage des points et FPS
        Vaisseau vaisseau = new Vaisseau(10, "A");
        Ennemi ennemi1 = new Ennemi(1, "E", 1, 0);
        Ennemi ennemi2 = new Ennemi(1, "Z", 1, 3);
        List<Ennemi> listennListeEnnemi = new List<Ennemi>();
        public void AffichageMenuLangue()
        {
            /////////////// initialisation des paramètres /////////////////////
            strPoints = "";
            strFPS = "FPS: ";
            intPoints = 0;
            intCompteur = 0;
            strPlay = "";
            strOption = "";
            strQuit = "";
            AffichageWidth = Console.BufferWidth; // pour l'affichage des points et FPS
            timTimerJeux = new System.Timers.Timer();
            vaisseau = new Vaisseau(10, "A");
            ennemi1 = new Ennemi(1, "E", 1, 0);
            ennemi2 = new Ennemi(1, "Z", 1, 3);
            listennListeEnnemi = new List<Ennemi>();

            ///////////////////// program /////////////////////
            Console.CursorVisible = true;
            Console.Clear();
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
                vaisseau.BoucleDeDéplacementJoueur(timTimerJeux);
            }
            else if (x - intMin == 1)
            {
                // méthode pour les options to do

            }
            else if (x - intMin == 2)
            {
                // méthode pour les résultats to do

            }
            AffichageMenuLangue();
        }

        private void LancerLeJeu()
        {
            listennListeEnnemi.Add(ennemi1);
            listennListeEnnemi.Add(ennemi2);
            Console.Clear();
            timTimerJeux.Enabled = true;
            timTimerJeux.AutoReset = true;
            timTimerJeux.Interval = 150;
            timTimerJeux.Start();
            timTimerJeux.Elapsed += Jeux;
            AfficherPointFPS();
        }
        public void FinDeLaPartie(string message)
        {
            Console.Clear();
            timTimerJeux.Stop();
            timTimerJeux.Enabled = false;
            timTimerJeux.Elapsed -= Jeux;
            Console.WriteLine(message);
            Thread.Sleep(1000);
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
            for (int x = 0; x < listennListeEnnemi.Count; x++)
            {
                if (vaisseau.MissileVaisseau.MissileObstacle(listennListeEnnemi[x].Hauteur, listennListeEnnemi[x].Largeur))
                {
                    listennListeEnnemi[x].MissileEnnemi.SuppresionMissile();
                    listennListeEnnemi.Remove(listennListeEnnemi[x]);
                    if (x > 0)
                    {
                        x--;
                    }
                    if (listennListeEnnemi.Count == 0)
                    {
                        FinDeLaPartie("Vous avez gagnez");
                        break;
                    }
                }
                listennListeEnnemi[x].MissileMouvement();
                if (listennListeEnnemi[x].MissileEnnemi.MissileObstacle(vaisseau.Hauteur, vaisseau.Largeur))
                {
                    FinDeLaPartie("Vous avez perdu");
                    break;
                }
                if (intCompteur % 3 == 2)
                {
                    listennListeEnnemi[x].DeplacementVaisseau();
                }
                listennListeEnnemi[x].DirectionEnnemi();
            }
            intCompteur++;
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
