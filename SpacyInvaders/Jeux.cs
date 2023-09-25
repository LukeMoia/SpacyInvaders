using System;
using System.Timers;
using System.Threading;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace SpacyInvaders
{
    internal class jeux
    {
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
        Vaisseau vaisseau = new Vaisseau(10, "A");
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
        List<Ennemi> listennListeEnnemi = new List<Ennemi>();
        const string strNomJeux = "SpicyInvader II";
        const string strSousTitreJeu = "---------------";
        public void AffichageMenuLangue()
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
            vaisseau = new Vaisseau(10, "A");
            ennemi1 = new Ennemi(3000, "Z", 1, 0);
            ennemi2 = new Ennemi(3000, "Z", 1, 3);
            ennemi3 = new Ennemi(3000, "Z", 1, 6);
            ennemi4 = new Ennemi(3000, "Z", 1, 9);
            ennemi5 = new Ennemi(3000, "Z", 1, 12);
            ennemi6 = new Ennemi(3000, "Z", 1, 15);
            ennemi7 = new Ennemi(3000, "Z", 1, 18);
            ennemi8 = new Ennemi(3000, "Z", 1, 21);
            ennemi9 = new Ennemi(3000, "Z", 1, 24);
            ennemi10 = new Ennemi(3000, "Z", 1, 27);
            listennListeEnnemi = new List<Ennemi>();

            ///////////////////// program /////////////////////
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

        private void AffichageMenuPourJouer()
        {

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

        private void MenuCouleur(ConsoleColor color, int Boucle, int minimum)
        {
            Console.SetCursorPosition(0, Boucle);
            Console.BackgroundColor = color;
            Console.WriteLine(strSousTitreJeu.Replace('-',' '));
            Console.SetCursorPosition(0, Boucle);
            if (minimum + 0 == Boucle)
            {
                Console.WriteLine(strPlay);
            }
            else if (minimum + 1 == Boucle)
            {
                Console.WriteLine(strOption);
            }
            else if (minimum + 2 == Boucle)
            {
                Console.WriteLine(strResult);
            }
            else if (minimum + 3 == Boucle)
            {
                Console.WriteLine(strQuit);
            }
        }

        private void BoucleMenu()
        {
            ConsoleKey cskConsole = ConsoleKey.A;
            const int intMax = 6;
            const int intMin = 3;
            int x = intMin;

            Console.CursorVisible = false;
            for (; cskConsole != ConsoleKey.Enter;)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"{strNomJeux}\n{strSousTitreJeu}\n\n{strPlay}\n{strOption}\n{strResult}\n{strQuit}");
                MenuCouleur(ConsoleColor.Red,x,intMin);
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
            if (x - intMin == 0)
            {
                // méthode pour lancer le jeu
                LancerLeJeu();
                vaisseau.BoucleDeDéplacementJoueur(timTimerJeux);
            }
            else if (x - intMin == 1)
            {
                // méthode pour les options to do

            }
            else if (x - intMin == 2)
            {
                // méthode pour les résultats
                AfficherScore();
            }
            else
            {
                Environment.Exit(0);
            }
            AffichageMenuLangue();
        }

        private void LancerLeJeu()
        {
            string instruction = "Shoot: Space";
            listennListeEnnemi.Add(ennemi1);
            listennListeEnnemi.Add(ennemi2);
            listennListeEnnemi.Add(ennemi3);
            listennListeEnnemi.Add(ennemi4);
            listennListeEnnemi.Add(ennemi5);
            listennListeEnnemi.Add(ennemi6);
            listennListeEnnemi.Add(ennemi7);
            listennListeEnnemi.Add(ennemi8);
            listennListeEnnemi.Add(ennemi9);
            listennListeEnnemi.Add(ennemi10);
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
            AfficherPointFPS();
        }
        public void FinDeLaPartie(string message)
        {
            Console.Clear();
            timTimerJeux.Stop();
            timTimerJeux.Enabled = false;
            timTimerJeux.Elapsed -= Jeux;
            Console.WriteLine(message);
            InsererDonnees();
        }

        private void Jeux(object valeur, System.Timers.ElapsedEventArgs Temps)
        {
            if (AffichageWidth != Console.BufferWidth)
            {
                Console.Clear();
                AfficherPointFPS();
                AffichageWidth = Console.BufferWidth;
            }
            Console.CursorVisible = false;
            vaisseau.AfficherVaisseau();
            vaisseau.MissileMouvement();
            for (int x = 0; x < listennListeEnnemi.Count; x++)
            {
                if (vaisseau.MissileVaisseau.MissileObstacle(listennListeEnnemi[x].Hauteur, listennListeEnnemi[x].Largeur))
                {
                    listennListeEnnemi[x].MissileEnnemi.SuppresionMissile();
                    vaisseau.score += listennListeEnnemi[x].pointEnnemi;
                    listennListeEnnemi.Remove(listennListeEnnemi[x]);
                    if (x > 0)
                    {
                        x--;
                    }
                    if (listennListeEnnemi.Count == 0)
                    {
                        FinDeLaPartie("Vous avez gagnez");
                        break;
                    }
                }
                if (listennListeEnnemi[x].MissileEnnemi.MissileObstacle(vaisseau.Hauteur, vaisseau.Largeur))
                {
                    FinDeLaPartie("Vous avez perdu");
                    break;
                }
                if (intCompteur % 8 == 2)
                {
                    listennListeEnnemi[x].DeplacementVaisseau();
                }
                else if (intCompteur % 4 == 0)
                {
                    AfficherPointFPS();
                }
                listennListeEnnemi[x].DirectionEnnemi();
                listennListeEnnemi[x].MissileMouvement();
            }
            intCompteur++;
        }

        public void InsererDonnees()
        {
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
                command.CommandText = $"INSERT INTO t_joueur (idJoueur, jouPseudo, jouNombrePoints)VALUES('{reader.GetInt32(0) + 1}', '{/*nom joueur*/"test"}', '{vaisseau.score}'); ";
                reader.Close();
                command.ExecuteNonQuery();
                Console.CursorVisible = false;
                Console.WriteLine("Données de la partie envoyées dans la base de données");
                connection.Close();
            }
            catch (Exception ex)

            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Appuyer pour continuer...");
            //Console.ReadLine();
        }

        public void AfficherPointFPS()
        {
            Console.SetCursorPosition(Console.BufferWidth - strPoints.Length - vaisseau.score.ToString().Length, 0);
            Console.Write(strPoints + vaisseau.score);
            Console.SetCursorPosition(Console.BufferWidth - strPoints.Length - 1, 1);
            Console.Write(strFPS + intLangue); // ajouter les fps TO DO
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
                connection.Close();
            }
            catch (Exception ex)

            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Appuyer pour continuer...");
            Console.ReadLine();
        }
    }
}
