using System;

namespace SpacyInvaders
{
    internal class Vaisseau
    {
        public int score { get; set; }
        public int Hauteur { get; private set; }
        private int Mouvement { get; set; }
        public int Largeur { get; private set; } = 10;
        private string Skin { get; set; }
        public Missile MissileVaisseau { get; private set; }
        public string NomJoueur { get; private set; }
        public Vaisseau(int hauteur,int largeur, string skin)
        {
            Hauteur = hauteur;
            Skin = skin;
            Largeur = largeur;
            MissileVaisseau = new Missile(0, Largeur, "|", -1);
        }

        public void tirer()
        {
            // créer le missile qui vas être tirer
            MissileVaisseau = new Missile(Hauteur, Largeur, "|", -1);
        }

        public void ChangementMouvement(int val)
        {
            // condition pour que le mouvement soit accepté
            if (val == 1 || val == -1)
            {
                Mouvement = val;
            }
        }

        /// <summary>
        /// pour que le vaisseau ce déplace de droite à gauche si il ne déplace pas la fenètre
        /// </summary>
        public void DeplacementVaisseau()
        {
            Console.SetCursorPosition(Largeur, Hauteur);
            Console.Write(" ");
            if (Largeur + Mouvement >= 0 && Largeur + Mouvement < Console.BufferWidth)
            {
                Largeur += Mouvement;
            }
            Console.SetCursorPosition(Largeur, Hauteur);
            Console.Write(Skin);
        }

        public void AfficherVaisseau()
        {
            Console.SetCursorPosition(Largeur, Hauteur);
            Console.Write(Skin);
        }

        public void MissileMouvement()
        {
            MissileVaisseau.MisilleMouvement();
        }

        public void BoucleDeDéplacementJoueur(System.Timers.Timer time)
        {
            ConsoleKey cskConsoleKey;
            for (int y = 0; ; y++)
            {
                cskConsoleKey = Console.ReadKey(true).Key;
                if (time.Enabled == true)
                {
                    if (cskConsoleKey == ConsoleKey.Spacebar && MissileVaisseau.MissileAfficher())
                    {
                        tirer();
                    }
                    if (cskConsoleKey == ConsoleKey.RightArrow)
                    {
                        ChangementMouvement(1);
                        DeplacementVaisseau();
                    }
                    if (cskConsoleKey == ConsoleKey.LeftArrow)
                    {
                        ChangementMouvement(-1);
                        DeplacementVaisseau();
                    }
                }
                else
                {
                    // Thread.Sleep(200);
                    Console.SetCursorPosition(0,1);
                    Console.CursorVisible = true;
                    Console.Write("Saisissez votre nom : ");
                    NomJoueur = Console.ReadLine();
                    if (NomJoueur == "")
                    {
                        NomJoueur = "Default";
                    }
                    Console.CursorVisible = false;
                    break;
                }
            }
        }
    }
}