using System;
using System.Collections.Generic;
using System.Text;

namespace RhumDeGuybrush
{

  
    static class Codage
    {
        /// <summary>
        /// Fonction FrontiereGauche regarde le chiffre à gauche et retourne faux si il est égal. Si non égal ou tentative d'accès à case d'accès du tableau inexistante retourne vrai  
        /// <returns>Booleen vrai si frontière gauche</returns>
        /// </summary>
        /// <param name="carte">Tableau qui représente la carte></param>
        /// <param name="i">Curseur lignes></param>
        ///  <param name="j">Curseur colonnes></param>
        public static Boolean FrontiereGauche(char[,] carte, int i, int j)
        {
            try
            {
                if (carte[i, j - 1] == carte[i, j])
                {
                    return false;
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
        /// Fonction FrontiereDroite regarde le chiffre à droite et retourne faux si il est égal. Si non égal ou tentative d'accès à case d'accès du tableau inexistante retourne vrai  
        /// <returns>Booleen vrai si frontière droite</returns>
        /// </summary>
        /// <param name="carte">Tableau qui représente la carte></param>
        /// <param name="i">Curseur lignes></param>
        ///  <param name="j">Curseur colonnes></param>
        public static Boolean FrontiereDroite(char[,] carte, int i, int j)
        {
            try
            {
                if (carte[i, j + 1] == carte[i, j])
                {
                    return false;
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
        /// <param name="carte">Tableau qui représente la carte></param>
        /// <param name="i">Curseur lignes></param>
        ///  <param name="j">Curseur colonnes></param>
        public static Boolean FrontiereHaut(char[,] carte, int i, int j)
        {
            try
            {
                if (carte[i - 1, j] == carte[i, j])
                {
                    return false;
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
        /// <param name="carte">Tableau qui représente la carte></param>
        /// <param name="i">Curseur lignes></param>
        ///  <param name="j">Curseur colonnes></param>

        public static Boolean FrontiereBas(char[,] carte, int i, int j)
        {
            try
            {
                if (carte[i + 1, j] == carte[i, j])
                {
                    return false;
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
       
        static void codage()
        {
            string encode = "";
           


            char[,] carte = new char[3, 3]
           { {'a','a','b' },
              {'a','a','b' },
              {'c','c','c' } };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int number = 0;
                    if (FrontiereGauche(carte, i, j))
                    {
                        number += 2;
                    }

                    if (FrontiereDroite(carte, i, j))
                    {
                        number += 8;
                    }

                    if (FrontiereHaut(carte, i, j))
                    {
                        number += 1;
                    }

                    if (FrontiereBas(carte, i, j))
                    {
                        number += 4;
                    }

                    if (carte[i, j] == 'M')
                    {
                        number += 64;
                    }

                    if (carte[i, j] == 'F')
                    {
                        number += 32;
                    }



                    encode += Convert.ToString(number);
                    if (j != 2)
                    {
                        encode += ":";
                    }

                }


                encode += "|";

            }

            Console.WriteLine(encode);

        }
    }
}
