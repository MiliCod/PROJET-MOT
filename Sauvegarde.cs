using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJET_MOT
{
    public class Sauvegarde  // je ferai les commentaires avec Hilal au cours de la semaine .
    {
        public static void recup(string nomfichier)
        {
            string recuperation = "";
            using (StreamReader txt = new StreamReader(nomfichier))
            {
                recuperation = txt.ReadToEnd();
            }
            string[] lignes = recuperation.Split('\n');

            int difficultee = 0;
            int nblignes = 0;
            int nbcolonnes = 0;
            int nbmots = 0;
            if (lignes[0].Length == 12)
            {
                difficultee = Convert.ToInt32(Convert.ToString(lignes[0][0]));

                nblignes = Convert.ToInt32(Convert.ToString(lignes[0][2]));

                nbcolonnes = Convert.ToInt32(Convert.ToString(lignes[0][4]));

                nbmots = Convert.ToInt32(Convert.ToString(lignes[0][6]));
            }
            else
            {
                difficultee = Convert.ToInt32(Convert.ToString(lignes[0][0]));

                nblignes = Convert.ToInt32(Convert.ToString(lignes[0][2]) + Convert.ToString(lignes[0][3]));

                nbcolonnes = Convert.ToInt32(Convert.ToString(lignes[0][5]) + Convert.ToString(lignes[0][6]));

                nbmots = Convert.ToInt32(Convert.ToString(lignes[0][8]) + Convert.ToString(lignes[0][9]));
            }

            string[] mots = new string[nbmots];
            string motajouter = "";
            int compteur = 0;
            int dernierevirgule = 0;
            for (int i = 0; i < lignes[1].Length; i++)
            {
                if (lignes[1][i] != ';')
                {

                    motajouter += lignes[1][i];
                }
                else
                {
                    if (motajouter != "")
                    {

                        mots[compteur] = motajouter;

                        motajouter = "";
                        compteur++;
                        dernierevirgule = i;
                    }
                }
            }
            motajouter = "";
            for (int i = dernierevirgule + 1; i < lignes[1].Length - 1; i++)
            {
                motajouter += lignes[1][i];
            }
            mots[mots.Length - 1] = motajouter;

            string[,] plateau = new string[nblignes, nbcolonnes];
            for (int i = 0; i < nblignes; i++)
            {
                for (int j = 0; j < nbcolonnes; j++)
                {
                    plateau[i, j] = Convert.ToString(lignes[2 + i][2 * j]);

                }
            }





        }

        public static void creer(string nomfichier)
        {
            int difficultee = 0; //difficulte du plateau
            int nblignes = 0; //nb de lignes du  plateau
            int nbcolonnes = 0; //nb de colonnes du plateau
            int nbmots = 8; //nb de mots a trouver
            string[] mots = new string[nbmots]; //liste des mots a placer
            string[,] plateau = new string[nblignes, nbcolonnes]; //plateau de lettres
            string final = difficultee + ";" + nblignes + ";" + nbcolonnes + ";" + nbmots;
            if (nbmots == 8)
            {
                final += ";;;;\n";
            }
            else
            {
                final += ";;;;;;;;;;;;;;;;;;;;;;;;\n";
            }
            for (int i = 0; i < mots.Length; i++)
            {
                final += mots[i];
                if (i != mots.Length - 1)
                {
                    final += ";";
                }
            }

            final += "\n";

            for (int i = 0; i < plateau.GetLength(0); i++)
            {

                for (int j = 0; j < plateau.GetLength(1); j++)
                {
                    final += plateau[i, j] + ";";
                }
                if (nbmots == 8)
                {
                    final += ";\n";
                }
                else
                {
                    final += ";;;;;;;;;;;;;;\n";
                }
            }
            using (StreamWriter fichier = new StreamWriter("yoyo.csv"))
            {
                fichier.Write(final);
            }

        }

    }
}
