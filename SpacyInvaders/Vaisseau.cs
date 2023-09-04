using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacyInvaders
{
    internal class Vaisseau
    {
        private int Hauteur { get; set; }
        private int Mouvement { get; set; }
        private int Largeur { get; set; }
        private string Skin { get; set; }
        private Missile MissileVaisseau { get; set; }
        public Vaisseau(int hauteur, string skin)
        {
            Hauteur = hauteur;
            Skin = skin;
        }
        public void tirer()
        {
            MissileVaisseau = new Missile();
        }
        public void ChangementMouvement(int val)
        {
            if (val == 1 || val == -1)
            {
                Mouvement = val;
            }
        }
        public void Deplacement()
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
    }
}
