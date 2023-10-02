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
            SuppresionMissile();
            if (Hauteur + Mouvement > 0 && Hauteur + Mouvement <= Console.WindowHeight - 1)
            {
                Hauteur += Mouvement;
                Console.SetCursorPosition(Largeur, Hauteur);
                Console.Write(Skin);
            }
            else if (Hauteur + Mouvement >= 0 && Hauteur + Mouvement <= Console.WindowHeight - 1)
            {
                Hauteur += Mouvement;
            }
        }

        public void SuppresionMissile()// pour faire disparaitre le missile
        {
            Console.SetCursorPosition(Largeur, Hauteur);
            Console.Write(" ");
        }

        public bool MissileAfficher() // pour pouvoir tirer à nouveau
        {
            return Hauteur == 0 || Hauteur >= Console.WindowHeight - 1;
        }
        public bool MissileObstacle(int hauteur, int longueur)
        {
            return hauteur == Hauteur && longueur == Largeur;
        }
    }
}