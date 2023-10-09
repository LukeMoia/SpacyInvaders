using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacyInvaders
{
    internal class Ennemi
    {
        public int Hauteur { get; private set; }
        private int Mouvement { get; set; }
        public int Largeur { get; private set; }
        private string Skin { get; set; }
        public Missile MissileEnnemi { get; private set; }
        public int pointEnnemi { get; set; }
        public Ennemi(int pointennemi, string skin, int hauteur, int largeur,int mouv)
        {
            pointEnnemi = pointennemi;
            Skin = skin;
            Hauteur = hauteur;
            if (largeur < Console.BufferWidth - 10)
            {
                Largeur = largeur;
            }
            Mouvement = mouv;
            MissileEnnemi = new Missile(Console.WindowHeight - 1, Largeur + Mouvement, "|", 1);
        }

        public void tirer()
        {
            MissileEnnemi = new Missile(Hauteur + 1, Largeur/* + Mouvement*/, "|", 1);
        }

        /// <summary>
        /// fais en sorte que le vaisseau se déplace
        /// </summary>
        public void DeplacementVaisseau()
        {
            Console.SetCursorPosition(Largeur, Hauteur);
            Console.Write(" ");
            if (Largeur + Mouvement >= 0 && Largeur + Mouvement <= Console.BufferWidth)
            {
                Largeur += Mouvement;
            }
            Console.SetCursorPosition(Largeur, Hauteur);
            Console.Write(Skin);
        }

        /// <summary>
        /// regarde dans quelle directon doit aller l'ennemi
        /// </summary>
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

        public void MissileMouvement()
        {
            if (MissileEnnemi != null)
            {
                MissileEnnemi.MisilleMouvement();
            }
        }
    }
}