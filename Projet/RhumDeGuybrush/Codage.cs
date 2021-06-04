using System;
using System.Collections.Generic;
using System.Text;

namespace RhumDeGuybrush
{
    /// <summary>
    /// La classe Codage permet d'encoder une carte décrypté
    /// </summary>
    static class Codage
    {
        /// <summary>
        /// Fonction FrontiereGauche regarde le chiffre à gauche et retourne faux si il est égal. Si non égal ou tentative d'accès à case d'accès du tableau inexistante retourne vrai  
        /// <returns>Booleen vrai si frontière gauche</returns>
        /// </summary>
        /// <param name="carte">Tableau qui représente la carte</param>
        /// <param name="i">Curseur lignes</param>
        /// <param name="j">Curseur colonnes</param>
        
        public static Boolean FrontiereGauche(char[,] carte, int i, int j)
        {
            try  // On essaye d'accéder à l'élément à gauche
            {
                if (carte[i, j - 1] == carte[i, j]) // Si l'élément actuel est égale l'élément à celui à gauche
                {
                    return false; // Il n'y a pas de frontière car l'élément actuel et celui à gauche sont égal
                }
                else
                {
                    return true; // Il y a une frontière car les éléments sont différents
                }
            }

            catch (Exception e) // Si il y a une erreur en voulant accéder à l'élément et donc que l'élément n'existe pas 
            {
                return true; // Il y a une frontière car on a atteint la fin de la carte/ une bordure 
            }
        }

        /// <summary>
        /// Fonction FrontiereDroite regarde le chiffre à droite et retourne faux si il est égal. Si non égal ou tentative d'accès à case d'accès du tableau inexistante retourne vrai  
        /// <returns>Booleen vrai si frontière droite</returns>
        /// </summary>
        /// <param name="carte">Tableau qui représente la carte</param>
        /// <param name="i">Curseur lignes</param>
        /// <param name="j">Curseur colonnes</param>
        public static Boolean FrontiereDroite(char[,] carte, int i, int j)
        {
            try // On essaye d'accéder à l'élément à droite
            {
                if (carte[i, j + 1] == carte[i, j]) // Si l'élément actuel est égale l'élément à celui à droite
                {
                    return false; // Il n'y a pas de frontière car l'élément actuel et celui à droite sont égal
                }
                else
                {
                    return true;
                }
            }

            catch (Exception e)
            {
                return true;
            }
        }

        /// <summary>
        /// Fonction FrontiereHaut regarde le chiffre à droite et retourne faux si il est égal. Si non égal ou tentative d'accès à case d'accès du tableau inexistante retourne vrai  
        /// <returns>Booleen vrai si frontière en haut</returns>
        /// </summary>
        /// <param name="carte">Tableau qui représente la carte</param>
        /// <param name="i">Curseur lignes</param>
        ///  <param name="j">Curseur colonnes</param>
        public static Boolean FrontiereHaut(char[,] carte, int i, int j)
        {
            try // On essaye d'accéder à l'élément au dessus
            {
                if (carte[i - 1, j] == carte[i, j]) // Si l'élément actuel est égale l'élément à celui en haut
                {
                    return false; // Il n'y a pas de frontière car l'élément actuel et celui à haut sont égal
                }
                else
                {
                    return true;
                }
            }

            catch (Exception e)
            {
                return true;
            }
        }


        /// <summary>
        /// Fonction FrontiereBas regarde le chiffre à droite et retourne faux si il est égal. Si non égal ou tentative d'accès à case d'accès du tableau inexistante retourne vrai  
        /// <returns>Booleen vrai si frontière en bas</returns>
        /// </summary>
        /// <param name="carte">Tableau qui représente la carte</param>
        /// <param name="i">Curseur lignes</param>
        /// <param name="j">Curseur colonnes</param>

        public static Boolean FrontiereBas(char[,] carte, int i, int j)
        {
            try  // On essaye d'accéder à l'élément en bas
            {
                if (carte[i + 1, j] == carte[i, j]) // Si l'élément actuel est égale l'élément à celui en bas
                {
                    return false; // Il n'y a pas de frontière car l'élément actuel et celui en bas sont égal
                }
                else
                {
                    return true;
                }
            }

            catch (Exception e)
            {
                return true;
            }
        }
        /// <summary>
        /// Fonction Codage regarde les frontières et ajoute le numéro adapté en conséquences ainsi que le type de terre (Mer/Foret) pour chaque élément et construit a
        /// </summary>
        /// <returns> carte chiffré </returns>
        /// <param name="path">Chemin de la carte claire</param>
        

        public static string codage(string path) // Méthode qui à partir d'une carte claire , retourne une carte chiffré
        {
            char[,] carte = new char[10, 10];  // Declare une carte 2 Dimensions de taille 10 ligne 10 colonnes


            if (path.Contains(".clair")) // On vérifie que le chemin pointe vers une carte en clair
            {
                int i = 0;
                string[] lines = System.IO.File.ReadAllLines(path); // On récupère la carte en clair

                foreach (string line in lines) // On parcours chaque lignes
                {
                    for (int j = 0; j < 10; j++) // On parcours chaque caractère de la ligne
                    {
                        carte[i, j] = line[j]; // On l'ajoute à notre tableau de "travail"
                    }

                    i++;
                }



            }
            string encode = ""; // On déclare encode comme étant une chaine de caractère vide



            for (int i = 0; i < 10; i++) // Parcours les lignes tableau
            {
                for (int j = 0; j < 10; j++) // Parcours les colonnes tableau
                {
                    int number = 0; // Nombre que va recevoir chaque lettre qui constitue la carte 
                    if (FrontiereGauche(carte, i, j)) // SI il y a une frontière à gauche
                    {
                        number += 2;  // additionne 2 à number
                    }

                    if (FrontiereDroite(carte, i, j)) // Si il y a une frontière à droit
                    {
                        number += 8; // additionne 8 à number
                    }

                    if (FrontiereHaut(carte, i, j)) // Si il y a une frontière en haut
                    {
                        number += 1; // additionne 1 à number
                    }

                    if (FrontiereBas(carte, i, j)) // Si il y a une frontière en bas
                    {
                        number += 4; // additionne 4 à number
                    }

                    if (carte[i, j] == 'M') // Si il la lettre est égale à M est donc que c'est une case Mer
                    {
                        number += 64; // additionne 64 à number
                    }

                    if (carte[i, j] == 'F') // Si il la lettre est égale à F est donc que c'est une case Fôret 
                    {
                        number += 32; // additionne 32 à number
                    }



                    encode += Convert.ToString(number); // Converti number d'un entier vers une chaine de caractère 
                    if (j != 9) // Si on n'est pas àu dernier élément de la colonne
                    {
                        encode += ":"; // Rajoute : entre chaque number pour l'affichage
                    }

                }


                encode += "|"; // Rajoute | à chaque fois qu'on passe une ligne

            }

            return encode; // Retourne encode (Qui est la carte chiffré)

        }
    }
}
