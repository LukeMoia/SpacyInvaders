using System;
using System.Threading;

namespace SpacyInvaders
{
    internal class Vaisseau
    {
        public int Hauteur { get; private set; }
        private int Mouvement { get; set; }
        public int Largeur { get; private set; }
        private string Skin { get; set; }
        public Missile MissileVaisseau { get; private set; }
        public Vaisseau(int hauteur, string skin)
        {
            Hauteur = hauteur;
            Skin = skin;
            MissileVaisseau = new Missile(0, Largeur, "|", -1);
        }
        public void tirer()
        {
            MissileVaisseau = new Missile(Hauteur, Largeur, "|", -1);
        }
        public void ChangementMouvement(int val)
        {
            if (val == 1 || val == -1)
            {
                Mouvement = val;
            }
        }
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
                    break;
                }
            }
        }
    }
}
