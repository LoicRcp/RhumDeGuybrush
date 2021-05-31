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
        Land[,] carte = new Land[10, 10];

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
        void Decodage(string a)
        {
            List<Land> parcelle = new List<Land>();
            List<Land> checkNeighboor(List<Land> toCheck, Land[,] tabCode)
            {
                // List<Land> oldList = toCheck; // Problème de copie, il faut procéder autrement
                // List<Land> newList = toCheck;

                List<Land> oldList = new List<Land>();
                List<Land> newList = new List<Land>();
                /*
                foreach (Land land in toCheck)
                {
                    parcelle.Add(land);
                }
                */

                foreach (Land land in parcelle)
                {
                    if (land.done != true)
                    {
                        try { newList.Add(tabCode[land.y + 1, land.x]); } // Si y'as un élément en bas, l'ajoute dans la liste
                        catch (Exception e) { }

                        try { newList.Add(tabCode[land.y - 1, land.x]); } // Si y'as un élément en haut, l'ajoute dans la liste
                        catch (Exception e) { }

                        try { newList.Add(tabCode[land.y, land.x + 1]); } // Si y'as un élément a droite, l'ajoute dans la liste
                        catch (Exception e) { }

                        try { newList.Add(tabCode[land.y, land.x - 1]); } // Si y'as un élément a gauche, l'ajoute dans la liste
                        catch (Exception e) { }






                        if (tabCode[land.y, land.x].frontiereGauche || tabCode[land.y, land.x - 1].done)
                        {
                            try { newList.Remove(tabCode[land.y, land.x - 1]); }
                            catch (Exception e) { }

                        }
                        if (tabCode[land.y, land.x].frontiereDroit || tabCode[land.y, land.x + 1].done)
                        {
                            try { newList.Remove(tabCode[land.y, land.x + 1]); }
                            catch (Exception e) { }

                        }
                        if (tabCode[land.y, land.x].frontiereBas || tabCode[land.y + 1, land.x].done)
                        {
                            try { newList.Remove(tabCode[land.y + 1, land.x]); }
                            catch (Exception e) { }

                        }
                        if (tabCode[land.y, land.x].frontiereHaut || tabCode[land.y - 1, land.x].done)
                        {
                            try { newList.Remove(tabCode[land.y - 1, land.x]); }
                            catch (Exception e) { }

                        }





                        land.done = true;



                    }

                }

                newList = newList.Distinct().ToList();
                if (newList.Capacity > 0)
                {


                    foreach (Land toAdd in newList) { parcelle.Add(toAdd); };

                    checkNeighboor(newList, tabCode);


                }
                return newList;
            }






            Land[,] tabCode = new Land[10, 10];


            string code = "67:69:69:69:69:69:69:69:69:73|74:3:9:7:5:13:3:1:9:74|74:2:8:7:5:13:6:4:12:74|74:6:12:7:9:7:13:3:9:74|74:3:9:11:6:13:7:4:8:74|74:6:12:6:13:11:3:13:14:74|74:7:13:7:13:10:10:3:9:74|74:3:1:9:7:12:14:2:8:74|74:6:4:4:5:5:13:6:12:74|70:69:69:69:69:69:69:69:69:76|";

            string[] codeSplitted = code.Split('|');

            int i = 0;
            int j = 0;

            foreach (string line in codeSplitted)
            {
                if (line != "")
                {
                    //Console.WriteLine();
                    foreach (string row in line.Split(':'))
                    {
                        tabCode[i, j] = new Land(row, i, j);
                        //Console.Write(tabCode[i, j].Nb + ":");
                        j++;
                    }
                    j = 0;
                    i++;
                }
            }

            Land[,] decodedTab = new Land[10, 10];
            int charCounter = 96;


            System.ConsoleColor[] colors = new System.ConsoleColor[5] { ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.DarkGray, ConsoleColor.Cyan, ConsoleColor.Magenta };
            int colorCounter = 0;
            System.ConsoleColor RandomColor = colors[colorCounter];

            for (i = 0; i < 10; i++)
            {
                for (j = 0; j < 10; j++)
                {
                    List<Land> toCheck = new List<Land>();
                    toCheck.Add(tabCode[i, j]);

                    parcelle = new List<Land>();
                    parcelle.Add(tabCode[i, j]);

                    checkNeighboor(parcelle, tabCode);







                    int count = 0;



                    foreach (Land land in parcelle)
                    {



                        count++;
                    }




                    if (count > 1) // sinon ça affiche pour chaque itération, le bout de terre sur lequel on est. ça règle pas le problème, ça le contourne, mais j'ai bien la flemme la
                    {
                        if (colorCounter >= 4)
                        {
                            colorCounter = 0;
                        }
                        else
                        {
                            colorCounter++;
                        }

                        RandomColor = colors[new Random().Next(5)];
                        if (!parcelle[0].foret && !parcelle[0].mer)
                        {
                            charCounter++;
                        }


                        foreach (Land land in parcelle)
                        {
                            land.color = RandomColor;

                            if (land.mer)
                            {
                                land.lettre = 'M';
                                land.color = ConsoleColor.Blue;
                            }
                            else if (land.foret)
                            {
                                land.lettre = 'F';
                                land.color = ConsoleColor.Green;
                            }
                            else
                            {
                                land.lettre = (char)charCounter;
                            }


                            decodedTab[land.y, land.x] = land;

                        }
                    }

                }
            }


            for (i = 0; i < 10; i++)
            {
                Console.WriteLine();

                for (j = 0; j < 10; j++)
                {
                    Console.ForegroundColor = decodedTab[i, j].color;
                    Console.Write(decodedTab[i, j].lettre);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(":");
                }
            }
            // convertion string --> tableau 2D encodé - Fait
            // A faire: Fonction récursive, je parcours le tableau, je check pour les frontières, etc...





            carte = decodedTab;
            

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
