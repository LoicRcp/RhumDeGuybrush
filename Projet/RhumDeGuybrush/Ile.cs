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
            return a;
        }

        /// <summary>
        /// Fonction affichageGlobal qui parcours le tableau et qui l'affiche. Avec une boucle 
        /// </summary>
        /// <param =></param>
        /// <returns></returns>
        void affichageGlobal()
        {
            int i = 0;
            int j = 0;
            for (i = 0; i < 3; i++)
            {
                Console.WriteLine();
                for (j = 0; j < 3; j++)
                {

                    if (carte[i, j] == 'M')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    if (carte[i, j] == 'F')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.Write(carte[i, j]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        /// <summary>
        /// Fonction affichageListeParcelle ...
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        void affichageListeParcelle()
        {
        }

        /// <summary>
        /// Fonction affichageTailleParcelle qui parcours le tableau, et dés qu'il tombe sur un bout de parcelle demandé, on incrémente un compteur, ce qui nous donne la carte.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        void affichageTailleParcelle()
        {
        }

        /// <summary>
        /// Fonction affichagePlusGrandeParcelle qui fait une liste, affiche toute les parcelles et qui stocke le résultat dans cette liste, puis parcours la liste et prend que ceux supérieur a X
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        void affichagePlusGrandeParcelle()
        {
        }

        /// <summary>
        /// Fonction affichageTailleMoyenne qui fait un peu pareil qu'au dessus, mais qui fait la moyenne au lieu de faire un tri sur la taille
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        void affichageTailleMoyenne()
        {
        }

        #endregion 
    }
}
