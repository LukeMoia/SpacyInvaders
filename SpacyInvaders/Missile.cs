using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacyInvaders
{
    internal class Missile
    {
        private int Hauteur { get; set; }
        private string Skin { get; set; }
        private int Largeur { get; set; }
        private int Mouvement = -1;

        public Missile(int hauteur, int longueur, string skin)
        {
            Hauteur = hauteur;
            Largeur = longueur;
            Skin = skin;
        }
        public void Misille()
        {

        }
    }
}
