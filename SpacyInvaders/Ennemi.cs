using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacyInvaders
{
    internal class Ennemi
    {
        private int Hauteur { get; set; } = 1;
        private int Mouvement { get; set; }
        private int Largeur { get; set; }
        private string Skin { get; set; }
        private Missile MissileEnnemi { get; set; }
        public int pointEnnemi { get; set; }
        public Ennemi(int pointennemi, string skin)
        {
            pointEnnemi = pointennemi;
            Skin = skin;
            Mouvement = 1;
            MissileEnnemi = new Missile(Console.WindowHeight + 1, Largeur + Mouvement, "|", 1);
        }
        public void tirer()
        {
            MissileEnnemi = new Missile(Hauteur, Largeur + Mouvement, "|", 1);
        }
        public void DeplacementVaisseau()
        {
            if (MissileEnnemi.MissileAfficher())
            {
                
                tirer();
            }
            else if (MissileEnnemi != null)
            {
                MissileEnnemi.MisilleMouvement();
            }
            Console.SetCursorPosition(Largeur, Hauteur);
            Console.Write(" ");
            if (Largeur + Mouvement >= 0 && Largeur + Mouvement < Console.BufferWidth)
            {
                Largeur += Mouvement;
            }
            Console.SetCursorPosition(Largeur, Hauteur);
            Console.Write(Skin);
        }

        public void DirectionEnnemi()
        {
            if (Mouvement == 1 && Mouvement + Largeur >= Console.BufferWidth - 10)
            {
                Console.SetCursorPosition(Largeur, Hauteur);
                Console.Write(" ");
                Mouvement = -1;
                Hauteur++;
            }
            else if (Mouvement == -1 && Mouvement + Largeur <= 0)
            {
                Console.SetCursorPosition(Largeur, Hauteur);
                Console.Write(" ");
                Mouvement = 1;
                Hauteur++;
            }
        }
    }
}
