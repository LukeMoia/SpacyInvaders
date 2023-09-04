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
        private int Mouvement;

        public Missile(int hauteur, int longueur, string skin, int mouvement) // pour initialiser le missile
        {
            Hauteur = hauteur;
            Largeur = longueur;
            Skin = skin;
            Mouvement = mouvement;
        }
        public void MisilleMouvement() //pour faire avancer le missile dans jeux
        {
            Console.SetCursorPosition(Largeur, Hauteur);
            Console.Write(" ");
            if (Hauteur + Mouvement >= 0 && Hauteur + Mouvement <= Console.WindowHeight)
            {
                Hauteur += Mouvement;
                Console.SetCursorPosition(Largeur, Hauteur);
                Console.Write(Skin);
            }
        }

        public bool MissileAfficher() // pour pouvoir tirer à nouveau
        {
            return Hauteur == 0 || Hauteur >= Console.WindowHeight - 1;
        }
    }
}
