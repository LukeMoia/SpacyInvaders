using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SpacyInvaders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             to do list : le random des tires ennemis (fait)
                          les commentaires (en cours)
                          Icescrum
                          Francais/Englais (choisir une langue)
                          github/git
                          (ajouter la musique)
                          faire les FPS
             */
            ///////////////////////////// déclaration des variables ///////////////////////////
            jeux jeu = new jeux();

            ////////////////////////////// programme principale ///////////////////////////////
            /*SoundPlayer player = new SoundPlayer(); // ajoute le sons de la musique
            player.SoundLocation = "music_game.wav";
            player.PlayLooping();*/
            jeu.AffichageMenuLangue(); // démarre le jeu
        }
    }
}