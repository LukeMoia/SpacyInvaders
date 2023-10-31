using System;
using System.Timers;
using System.Threading;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Media;

namespace SpacyInvaders
{
    /// <summary>
    /// La classe jeux sert a faire marcher le jeux
    /// </summary>
    internal class jeux
    {
        // variable universelle pour la classe
        System.Timers.Timer timTimerJeux = new System.Timers.Timer();
        int intLangue { get; set; }
        string strPoints = "";
        string strFPS = "FPS: ";
        int intCompteur = 0;
        string strPlay = "";
        string strOption = "";
        string strResult = "";
        string strQuit = "";
        int AffichageWidth = Console.BufferWidth; // pour l'affichage des points et FPS
        Vaisseau vaisseau;
        Ennemi ennemi1;
        Ennemi ennemi2;
        Ennemi ennemi3;
        Ennemi ennemi4;
        Ennemi ennemi5;
        Ennemi ennemi6;
        Ennemi ennemi7;
        Ennemi ennemi8;
        Ennemi ennemi9;
        Ennemi ennemi10;
        Ennemi ennemi11;
        Ennemi ennemi12;
        Ennemi ennemi13;
        Ennemi ennemi14;
        Ennemi ennemi15;
        Ennemi ennemi16;
        Ennemi ennemi17;
        Ennemi ennemi18;
        Ennemi ennemi19;
        Ennemi ennemi20;
        List<Ennemi> listennListeEnnemiVivant = new List<Ennemi>();
        List<Ennemi> listennListeEnnemi = new List<Ennemi>();
        const string strNomJeux = "SpicyInvader II";
        const string strSousTitreJeu = "---------------";
        static Random Random = new Random();
        Stopwatch stopwatch = new Stopwatch();
        int nombreFPS = 0;
        SoundPlayer player = new SoundPlayer(); // ajoute le sons de la musique
        bool bolMusique = true;
        public void AffichageMenuLangue() // début du jeux
        {
            for (; true;)
            {
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
        }

        private void AffichageMenuPourJouer() // pour reinitialiser les variables de manière correcte
        {
            /////////////// initialisation des paramètres /////////////////////
            strPoints = "";
            strFPS = "FPS: ";
            intCompteur = 0;
            strPlay = "";
            strOption = "";
            strQuit = "";
            AffichageWidth = Console.BufferWidth; // pour l'affichage des points et FPS
            timTimerJeux = new System.Timers.Timer();
            vaisseau = new Vaisseau(10, 10 /*ou 0 (pour plus simple)*/, "A");
            listennListeEnnemiVivant.Clear();
            listennListeEnnemiVivant = new List<Ennemi>();
            ennemi1 = new Ennemi(3000, "T", 1, 0, 1);
            ennemi2 = new Ennemi(3000, "R", 1, 3, 1);
            ennemi3 = new Ennemi(3000, "P", 1, 6, 1);
            ennemi4 = new Ennemi(3000, "N", 1, 9, 1);
            ennemi5 = new Ennemi(3000, "M", 1, 12, 1);
            ennemi6 = new Ennemi(3000, "N", 1, 15, 1);
            ennemi7 = new Ennemi(3000, "U", 1, 18, 1);
            ennemi8 = new Ennemi(3000, "V", 1, 21, 1);
            ennemi9 = new Ennemi(3000, "X", 1, 24, 1);
            ennemi10 = new Ennemi(3000, "Z", 1, 27, 1);
            ennemi11 = new Ennemi(3000, "D", 2, 30, -1);
            ennemi12 = new Ennemi(3000, "S", 2, 3, -1);
            ennemi13 = new Ennemi(3000, "Y", 2, 6, -1);
            ennemi14 = new Ennemi(3000, "L", 2, 9, -1);
            ennemi15 = new Ennemi(3000, "G", 2, 12, -1);
            ennemi16 = new Ennemi(3000, "H", 2, 15, -1);
            ennemi17 = new Ennemi(3000, "D", 2, 18, -1);
            ennemi18 = new Ennemi(3000, "J", 2, 21, -1);
            ennemi19 = new Ennemi(3000, "Q", 2, 24, -1);
            ennemi20 = new Ennemi(3000, "B", 2, 27, -1);
            listennListeEnnemi = new List<Ennemi>() { ennemi1, ennemi2, ennemi3, ennemi4, ennemi5, ennemi6, ennemi7, ennemi8, ennemi9, ennemi10, ennemi11, ennemi12, ennemi13, ennemi14, ennemi15, ennemi16, ennemi17, ennemi18, ennemi19, ennemi20 };

            ///////////////////// program /////////////////////
            if (bolMusique == true)
            {
            player.Stop();
            player.SoundLocation = "music_game.wav";
            player.PlayLooping();
            }

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

        /// <summary>
        /// Pour pouvoir faire la couleur^du menu
        /// </summary>
        /// <param name="color"></param>
        /// <param name="Boucle"></param>
        /// <param name="minimum"></param>
        /// <param name="maximum"></param>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <param name="str3"></param>
        /// <param name="str4"></param>
        private void MenuCouleur(ConsoleColor color, int Boucle, int minimum, int maximum, string str1, string str2, string str3, string str4)
        {
            Console.SetCursorPosition(0, Boucle);
            Console.BackgroundColor = color;
            Console.WriteLine(strSousTitreJeu.Replace('-', ' '));
            Console.SetCursorPosition(0, Boucle);
            if (minimum + 0 == Boucle && str1 != null)
            {
                Console.WriteLine(str1);
            }
            else if (minimum + 1 == Boucle && str2 != null)
            {
                Console.WriteLine(str2);
            }
            else if (minimum + 2 == Boucle && str3 != null)
            {
                Console.WriteLine(str3);
            }
            else if (minimum + 3 == Boucle && str4 != null)
            {
                Console.WriteLine(str4);
            }
        }

        /// <summary>
        /// Il en existe deux version : une a 4 string et une a deux string et une a quatre string
        /// </summary>
        /// <param name="minimum"></param>
        /// <param name="maximu"></param>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <param name="str3"></param>
        /// <param name="str4"></param>
        /// <param name="strmenu"></param>
        /// <returns></returns>
        private int Boucle(int minimum, int maximu, string str1, string str2, string str3, string str4, string strmenu)
        {
            ConsoleKey cskConsole = ConsoleKey.A;
            int intMax = maximu;
            int intMin = minimum;
            int x = intMin;

            Console.CursorVisible = false;
            for (; cskConsole != ConsoleKey.Enter;)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"{strmenu}\n{strSousTitreJeu}\n\n{str1}\n{str2}\n{str3}\n{str4}");
                MenuCouleur(ConsoleColor.Red, x, intMin, maximu, str1, str2, str3, str4);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
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
            return x - intMin;
        }

        private int Boucle(int minimum, int maximu, string str1, string str2, string str3, string strmenu)
        {
            ConsoleKey cskConsole = ConsoleKey.A;
            int intMax = maximu;
            int intMin = minimum;
            int x = intMin;

            Console.CursorVisible = false;
            for (; cskConsole != ConsoleKey.Enter;)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"{strmenu}\n{strSousTitreJeu}\n\n{str1}\n{str2}\n{str3}");
                MenuCouleur(ConsoleColor.Red, x, intMin, maximu, str1, str2, str3, null);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
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
            return x - intMin;
        }

        private void BoucleMenu()
        {
            int x = 0;

            x = Boucle(3, 6, strPlay, strOption, strResult, strQuit, strNomJeux);
            if (x == 0)
            {
                // méthode pour lancer le jeu
                LancerLeJeu();
                vaisseau.BoucleDeDéplacementJoueur(timTimerJeux);
                InsererDonnees();
                Console.ReadLine();
            }
            else if (x == 1)
            {
                // méthode pour les options
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                int temp = 0;
                if (intLangue == 0)
                {
                  temp = Boucle(3, 5, "Francais", "Englais", $"Musique : {bolMusique}", "Option");
                }
                else
                {
                  temp = Boucle(3, 5, "French", "English", $"Music : {bolMusique}", "Option");
                }
                if (temp == 0 || temp == 1)
                {
                intLangue = temp;
                }
                else if(bolMusique == true)
                {
                    bolMusique = false;
                    player.Stop();
                }
                else
                {
                    bolMusique = true;
                    player.PlayLooping();
                }
                //// ajouter du son

            }
            else if (x/* - intMin*/ == 2)
            {
                // méthode pour les résultats
                AfficherScore();
                Console.ReadLine();
            }
            else
            {
                Environment.Exit(0);
            }
            AffichageMenuPourJouer();
        }

        private void LancerLeJeu()
        {
            string instruction = "Shoot: Space";
            foreach (Ennemi enn in listennListeEnnemi)
            {
                listennListeEnnemiVivant.Add(enn);
            }
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2 - instruction.Length, Console.WindowHeight / 2);
            Console.WriteLine(instruction);
            Thread.Sleep(1000);
            Console.Clear();
            timTimerJeux.Enabled = true;
            timTimerJeux.AutoReset = true;
            timTimerJeux.Interval = 50;
            timTimerJeux.Start();
            timTimerJeux.Elapsed += Jeux;
            AfficherPoint();
            AfficherFPS(0);
            stopwatch.Start();
            if (bolMusique == true)
            {
            player.Stop();
            player.SoundLocation = "MusiqueCombat.wav";
            player.Play();
            }
        }

        public void FinDeLaPartie(string message)
        {
            Console.Clear();
            timTimerJeux.Stop();
            stopwatch.Stop();
            timTimerJeux.Enabled = false;
            timTimerJeux.Elapsed -= Jeux;
            Console.SetCursorPosition(0,0);
            Console.WriteLine(message);
            if (bolMusique == true)
            {
                player.Stop();
            }
        }

        private void Jeux(object valeur, System.Timers.ElapsedEventArgs Temps)
        {
            // pour le tir des ennemis
            int Tir = Random.Next(0,4);
            List<int> TirList = new List<int>();
            for(int i = 0;i < Tir; i++)
            {
                TirList.Add(Random.Next(listennListeEnnemiVivant.Count));
            }
            for (int u = 0;u < TirList.Count;u++)
            {
                    if (listennListeEnnemiVivant[TirList[u]].MissileEnnemi.MissileAfficher())
                    {
                        listennListeEnnemiVivant[TirList[u]].MissileEnnemi.SuppresionMissile();
                        listennListeEnnemiVivant[TirList[u]].tirer();
                    }
            }

            // pour afficher les fps
            if (stopwatch.ElapsedMilliseconds >= 1000)
            {
                AfficherFPS(nombreFPS);
                nombreFPS = 0;
                stopwatch.Restart();
            }
            else
            {
                nombreFPS++;
            }

            // changement de la taille de la fenètre de jeux
            if (AffichageWidth != Console.BufferWidth)
            {
                Console.Clear();
                AfficherPoint();
                AffichageWidth = Console.BufferWidth;
            }

            // condition de victoire/défaite, point, mouvement missile et vaisseau
            Console.CursorVisible = false;
            vaisseau.AfficherVaisseau();
            vaisseau.MissileMouvement();
            for (int x = 0; x < listennListeEnnemiVivant.Count; x++)
            {
                if (vaisseau.MissileVaisseau.MissileObstacle(listennListeEnnemiVivant[x].Hauteur, listennListeEnnemiVivant[x].Largeur))
                {
                    listennListeEnnemiVivant[x].MissileEnnemi.SuppresionMissile();
                    vaisseau.score += listennListeEnnemiVivant[x].pointEnnemi;
                    listennListeEnnemiVivant.Remove(listennListeEnnemiVivant[x]);
                    if (x > 0)
                    {
                        x--;
                    }
                    if (listennListeEnnemiVivant.Count == 0)
                    {
                        if (intLangue == 0)
                        {
                        FinDeLaPartie("Vous avez gagné");
                        }
                        else
                        {
                            FinDeLaPartie("You win");
                        }
                        break;
                    }
                }

                if (listennListeEnnemiVivant[x].MissileEnnemi.MissileObstacle(vaisseau.Hauteur, vaisseau.Largeur))
                {
                    if (intLangue == 0)
                    {
                        FinDeLaPartie("Vous avez perdu");
                    }
                    else
                    {
                        FinDeLaPartie("You lose");
                    }
                    break;
                }
                if (intCompteur % 8 == 2)
                {
                    listennListeEnnemiVivant[x].DeplacementVaisseau();
                }
                else if (intCompteur % 4 == 0)
                {
                    AfficherPoint();
                }
                listennListeEnnemiVivant[x].DirectionEnnemi();
                listennListeEnnemiVivant[x].MissileMouvement();
            }
            intCompteur++;
        }

        public void AfficherPoint()
        {
            Console.SetCursorPosition(Console.BufferWidth - strPoints.Length - vaisseau.score.ToString().Length, 0);
            Console.Write(strPoints + vaisseau.score);
        }

        public void AfficherFPS(int FPS)
        {
            Console.SetCursorPosition(Console.BufferWidth - strPoints.Length - 1, 1);
            Console.Write(strFPS + FPS);
        }

        public void InsererDonnees()
        {
            // insérer les données dans la base de donnée
            string connectionString = "Server=localhost;Port=6033;Database=db_space_invaders;User ID=root;Password=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader reader;

            command.CommandText = $"SELECT COUNT(*) FROM t_joueur";
            try
            {
                // Connexion à la base de données

                connection.Open();
                reader = command.ExecuteReader();
                reader.Read();
                command.CommandText = $"INSERT INTO t_joueur (idJoueur, jouPseudo, jouNombrePoints)VALUES('{reader.GetInt32(0) + 1}', '{vaisseau.NomJoueur}', '{vaisseau.score}'); ";
                reader.Close();
                command.ExecuteNonQuery();
                Console.CursorVisible = false;
                if (intLangue == 0)
                {
                Console.WriteLine("Données de la partie envoyées dans la base de données");
                }
                else
                {
                    Console.WriteLine("Game data sent to database");
                }
            }
            catch
            {
                if (intLangue == 0)
                {
                    Console.WriteLine("Une erreur ç'est produite avec la connexion");
                }
                else
                {
                    Console.WriteLine("An error occurred with the connection");
                }
            }
            finally
            {
                connection.Close();
            }

            if (intLangue == 0)
            {
                Console.WriteLine("\nAppuyer pour continuer...");
            }
            else
            {
                Console.WriteLine("\nTouch for continue...");
            }
        }

        public void AfficherScore()
        {
            Console.Clear();
            string connectionString = "Server=localhost;Port=6033;Database=db_space_invaders;User ID=root;Password=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader reader;

            command.CommandText = "SELECT * FROM t_joueur ORDER BY jouNombrepoints DESC LIMIT 5";
            try
            {
                // Connexion à la base de données

                connection.Open();
                reader = command.ExecuteReader();
                Console.CursorVisible = false;
                Console.WriteLine("        HIGHSCORE\n------------------------");
                Console.SetCursorPosition(0, 3);
                for (int x = 0; x < 5; x++)
                {
                    Console.Write(x + 1 + "   ");
                    reader.Read();
                    for (int y = 1; y < 3; y++)
                    {
                        Console.Write(reader.GetString(y));
                        if (y < 3 - 1)
                        {
                            Console.SetCursorPosition(20, x + 3);
                        }
                    }
                    Console.WriteLine();
                }
            }
            catch
            {
                Console.CursorVisible = false;
                Console.WriteLine("        HIGHSCORE\n------------------------");
                Console.SetCursorPosition(0, 3);
                for (int x = 0; x < 5; x++)
                {
                    Console.Write(x + 1 + "   ");
                    for (int y = 1; y < 3; y++)
                    {
                        if (y == 2)
                        {
                        Console.Write($"{7 - x}000");
                        }
                        if (y < 3 - 1)
                        {
                            Console.SetCursorPosition(20, x + 3);
                        }
                    }
                    Console.WriteLine();
                }
                if (intLangue == 0)
                {
                    Console.WriteLine("\nLe Score est par défault");
                }
                else
                {
                    Console.WriteLine("\nScore is by default");
                }
            }
            finally
            {
                connection.Close();
            }
            if (intLangue == 0)
            {
            Console.WriteLine("\n\nAppuyer pour continuer...");
            }
            else
            {
                Console.WriteLine("\n\nTouch for continue...");
            }
        }
    }
}