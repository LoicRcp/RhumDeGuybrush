using System;
using System.Collections.Generic;
using System.Text;

namespace RhumDeGuybrush
{
    static class Codage
    {
        /// <summary>
        /// On prend une carte en clair ( ile.afficheCarte() )et on suit les instruction du PDF pour le cryptage (pas compliqué du coup)
        /// </summary>
        /// <returns></returns>
        static void codage()
        {
            string encode = "";
            Boolean FrontiereGauche(char[,] carte, int i, int j)
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

            Boolean FrontiereDroite(char[,] carte, int i, int j)
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

            Boolean FrontiereHaut(char[,] carte, int i, int j)
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

            Boolean FrontiereBas(char[,] carte, int i, int j)
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
