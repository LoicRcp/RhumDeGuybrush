using System;
using System.Collections.Generic;
using System.Text;

namespace RhumDeGuybrush
{
    /// <summary>
    /// La classe Ile permet de stocker une ile en claire et toute ses informations et ses fonctions 
    /// </summary>
    class Ile
    {
        #region Attribut
        /// <summary>
        /// Talbeau 2D dans laquel est stocké la carte
        /// </summary>
        char[,] carte = new char[3, 3]
            { {'a','a','b' },
              {'a','a','b' },
              {'c','c','c' } };

        /// <summary>
        /// Nom de l'ile sur laquelle on travaille
        /// </summary>
        string nomIle;
        #endregion

        #region Constructeur
        #endregion

        #region Fonction
        /// <summary>
        /// Fonction Decodage a qui on envoie une chaine de caractère crypté, et il renvoi la chaine en clair
        /// Idée : On a un tableau avec le chaine crypté, un tableau vide de même dimension
        /// En entrée on met un bout de l'ile, la fonction va regarder en haut, en bas, a droite, a gauche. Si y'as pas de frontière entre les 2, elle va mettre dans le tableau vide, a ces coordonnées, le nom de la parcelle, puis la fonction recursive va recommencer.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        string Decodage(string a)
        {


            string[,] tabCode = new string[10, 10];


            string code = "67:69:69:69:69:69:69:69:69:73|74:3:9:7:5:13:3:1:9:74|74:2:8:7:5:13:6:4:12:74|74:6:12:7:9:7:13:3:9:74|74:3:9:11:6:13:7:4:8:74|74:6:12:6:13:11:3:13:14:74|74:7:13:7:13:10:10:3:9:74|74:3:1:9:7:12:14:2:8:74|74:6:4:4:5:5:13:6:12:74|70:69:69:69:69:69:69:69:69:76|";

            string[] codeSplitted = code.Split('|');

            int i = 0;
            int j = 0;

            foreach (string line in codeSplitted)
            {
                if (line != "")
                {
                    Console.WriteLine();
                    foreach (string row in line.Split(':'))
                    {
                        tabCode[i, j] = row;
                        Console.Write(tabCode[i, j] + ":");
                        j++;
                    }
                    j = 0;
                    i++;
                }
            }



            // convertion string --> tableau 2D encodé - Fait
            // A faire: Fonction récursive, je parcours le tableau, je check pour les frontières, etc...






            return a;
        }

        /// <summary>
        /// Fonction affichageGlobal qui parcours le tableau et qui affiche
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        int affichageGlobal(int b)
        {
            int i = 0;
            int j = 0;
            for(i = 0; i <= 2; i++)
            {
                for(j = 0; j <=2; j++)
                {
                    Console.WriteLine(carte[i,j]);
                }
            }
            return b;
        }

        /// <summary>
        /// Fonction affichageListeParcelle ...
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        int affichageListeParcelle(int c)
        {
            return c;
        }

        /// <summary>
        /// Fonction affichageTailleParcelle qui parcours le tableau, et dés qu'il tombe sur un bout de parcelle demandé, on incrémente un compteur, ce qui nous donne la carte.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        int affichageTailleParcelle(int d)
        {
            return d;
        }

        /// <summary>
        /// Fonction affichagePlusGrandeParcelle qui fait une liste, affiche toute les parcelles et qui stocke le résultat dans cette liste, puis parcours la liste et prend que ceux supérieur a X
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        int affichagePlusGrandeParcelle(int e)
        {
            return e;
        }

        /// <summary>
        /// Fonction affichageTailleMoyenne qui fait un peu pareil qu'au dessus, mais qui fait la moyenne au lieu de faire un tri sur la taille
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        int affichageTailleMoyenne(int f)
        {
            return f;
        }
        #endregion 
    }
}
