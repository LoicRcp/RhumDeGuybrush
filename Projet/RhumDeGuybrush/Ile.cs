using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

        /// <summary>
        /// Le constructeur de l'ILE, ne prend qu'un chemin vers une carte crypté. Pour afficher une carte décrypté, il faut la cryper avec l'encodeur puis la décrypter.
        /// </summary>
        /// <param name="path"> Le chemin vers la carte cryptée </param>
        public Ile(string path) 
        {
            string encoded = "";
            if (path.Contains(".clair")) // si on fournis une carte en clair, l'encrypte et la décrypte (Pas efficace mais c'est le mieux,
                                         // on est un peu bloqué a cause de la classe Land, il faudrait remplir un tableau 10x10 de "Land"
                                         // alors qu'on peut juste a faire ça
            {
                encoded = Codage.codage(path);
            } else {
                encoded = System.IO.File.ReadAllText(path); // on récupère le contenu, cad la carte cryptée
            }

            string[] tempNomIle = path.Split('.'); // Pour récupérer le nom de la carte (ça devrait servir si on fait un affichage interactif)
                tempNomIle = tempNomIle[0].Split('\\');
                nomIle = tempNomIle[tempNomIle.Length-1];
                carte = decodage(encoded); // On décode la carte avec la méga-fonction "décodage"
        }


        #endregion

        #region décodage
        /// <summary>
        /// Fonction qui a pour but de prendre une carte encodé, et qui renvoi un tableau 10x10 d'objet "Land" qui contient toute les informations utiles pour manipuler/consulter la carte.
        /// </summary>
        /// <param name="code"> Une chaine de caractères qui correspond a une carte encodé. </param>
        /// <returns> Retourne un tableau 2D 10x10 contenant des "Land".</returns>
        Land[,] decodage(string code)
        {

            List<Land> parcelle = new List<Land>(); // Déclaration de la variable "parcelle" qui stockera la parcelle sur laquelle le script "travaille"
            /// <summary>
            /// Fonction (récursive) qui va regarder si y'as des voisin de la case (même parcelle). Si oui, va regardez leur voisins aussi. (voir schéma dans "autre" sur github)
            /// </summary>
            /// <param name="toCheck"> La liste des cases a traiter --> vérifier leur voisins </param>
            /// <param name="tabCode"> Le tableau encodé, pour pouvoir accéder au éléments. </param>
            /// <returns></returns>
            List<Land> checkNeighboor(List<Land> toCheck, Land[,] tabCode) 
            {

                List<Land> newList = new List<Land>();
   

                foreach (Land land in parcelle) // Pour chaque élément "land" dans parcelle,
                {
                    if (land.Done != true) // si l'élement land n'as pas déjà été traité, on fait:
                    {
                        try { newList.Add(tabCode[land.Y + 1, land.X]); } // Si y'as un élément en bas, l'ajoute dans la liste "newList"
                        catch (Exception e) { }

                        try { newList.Add(tabCode[land.Y - 1, land.X]); } // Si y'as un élément en haut, l'ajoute dans la liste "newList"
                        catch (Exception e) { }

                        try { newList.Add(tabCode[land.Y, land.X + 1]); } // Si y'as un élément a droite, l'ajoute dans la liste "newList"
                        catch (Exception e) { }

                        try { newList.Add(tabCode[land.Y, land.X - 1]); } // Si y'as un élément a gauche, l'ajoute dans la liste "newList"
                        catch (Exception e) { }






                        if (tabCode[land.Y, land.X].FrontiereGauche || tabCode[land.Y, land.X - 1].Done) // Si l'élément a gauche n'est pas de la même parcelle (frontière entre les 2) OU si il a déjà été traité,
                        {
                            try { newList.Remove(tabCode[land.Y, land.X - 1]); } // On le supprime de la liste. Si il y a une erreur, c'est qu'il n'y a rien à gauche.
                            catch (Exception e) { }

                        }
                        if (tabCode[land.Y, land.X].FrontiereDroit || tabCode[land.Y, land.X + 1].Done) // Même système
                        {
                            try { newList.Remove(tabCode[land.Y, land.X + 1]); }
                            catch (Exception e) { }

                        }
                        if (tabCode[land.Y, land.X].FrontiereBas || tabCode[land.Y + 1, land.X].Done) //...
                        {
                            try { newList.Remove(tabCode[land.Y + 1, land.X]); }
                            catch (Exception e) { }

                        }
                        if (tabCode[land.Y, land.X].FrontiereHaut || tabCode[land.Y - 1, land.X].Done) //...
                        {
                            try { newList.Remove(tabCode[land.Y - 1, land.X]); }
                            catch (Exception e) { }

                        }





                        land.Done = true; // Une fois fini, on indique la case sur laquelle on est comme "traité". Elle ne sera donc plus traité, et on a pas de redondances ou de doublons.



                    }

                }

                newList = newList.Distinct().ToList(); // On peut avoir des doublons, dans le cas de figure ou 2 éléments on 1 élément en commun. On va alors simplement retiré les doublons.
                if (newList.Capacity > 0) // Si la liste des nouvelles cases n'est pas vide, alors on va chercher les voisines des cases qu'on a trouvé (d'ou la récursivité)
                {


                    foreach (Land toAdd in newList) { parcelle.Add(toAdd); }; // Pour chaque nouvelle case, on vérifie ses voisins.

                    checkNeighboor(newList, tabCode);


                }
                return newList; // Une fois qu'il n'y a plus rien a trouvé, on quitte la fonction récursive, et on a identifié tout les membres de la parcelle.
            }

            Land[,] tabCode = new Land[10, 10]; // on déclare un tableau 10x10 pour stocker la carte encodé


            string[] codeSplitted = code.Split('|'); // On sépare les lignes

            int i = 0;
            int j = 0;

            foreach (string line in codeSplitted) // Un peu la flemme d'expliquer en détail. En gros on découpe la carte "encodé", et on la met dans un tableau.
                                                  // "tabCode" qui contient la carte encodé. On utilise une boucle foreach imbriqué ainsi que le "split" des strings.
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

            Land[,] decodedTab = new Land[10, 10]; // On déclare un tableau 10x10 qui stockera la carte décodé.
            int charCounter = 96; // Le compteur de caractère, qui assignera a chaque parcelle la lettre a, b, c, d, etc...
                                  // 96 est le code ascii de "a"



            // Petit extra, chaque "case" à sa couleur attitré, pour que ça soit visuellement joli

            // Un tableau rempli de couleurs différentes pour le terminal
            System.ConsoleColor[] colors = new System.ConsoleColor[8] { ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.DarkGray, ConsoleColor.Cyan, ConsoleColor.Magenta, ConsoleColor.DarkYellow, ConsoleColor.DarkMagenta, ConsoleColor.DarkRed};
            int colorCounter = 0; // Un compteur qui permet de ne pas sortir du tableau et provoquer d'erreur
            System.ConsoleColor RandomColor = colors[colorCounter]; // La couleur "aléatoire" est pour le moment défini sur "rouge".




            // on va regarder CHAQUE case du tableau. Des que l'on tombe sur une case qui n'es pas "done", qui n'as pas été identifié,
            // bref qui n'as pas été traité, on va chercher ses voisins etc... Sinon on ne fait rien. --> Optimisation
            for (i = 0; i < 10; i++)
            {
                for (j = 0; j < 10; j++)
                {
            

                    parcelle = new List<Land>(); // pour chaque nouvelle "case" que l'on regarde, on remet la "parcelle" a 0.
                                                 // Parcelle est une simple liste qui contient les "cases" qui constituent une parcelle.
                    parcelle.Add(tabCode[i, j]); // On met l'élement que l'on regarde dans la parcelle. Ça sera le point de départ pour la fonction récursive.
                                                 

                    checkNeighboor(parcelle, tabCode); // fonction récursive qui va chercher tout les voisins et, en gros, identifier toute la parcelle de la case donné.
                                                       // Ne renvoi rien car actualise directement "parcelle". Ainsi, a chaque "couche/niveau" de la récursivité, le résultat de la fonction stocké







                    int count = 0; // Un compteur



                    foreach (Land land in parcelle) // Qui permet de savoir si la parcelle est vide. Car si la case a été marqué comme "done", checkNeighboor ne fera rien
                                                    // et donc "parcelle" restera vide. Si la parcelle est vide, on ignore et on passe a la case suivante.
                    {



                        count++; // Pour chaque Land dans parcelle, on ajoute 1 au compteur.
                        
                    }




                    if (count > 1) // Si la parcelle n'est pas vide
                    {


                        // permet d'avoir un roulement de couleurs, quand ça arrive a la fin, ça repart au début.
                        if (colorCounter >= colors.Length-1)
                        {
                            colorCounter = 0;
                        }
                        else
                        {
                            colorCounter++;
                        }




                        // couleurs aléatoire OU dans l'ordre.
                        // ça ne résoud pas le problème suivant:
                        // Certaines parcelles ont la même couleurs mais ne sont pas ensemble. 
                        // C'est du au petit nombre de couleurs disponibles + le fait que le tableau soit en 2 dimensions.
                        // Le problème est réglable mais ça serait contre productif.


                        //RandomColor = colors[new Random().Next(colors.Length)];
                        RandomColor = colors[colorCounter];
                        
                        if (!parcelle[0].Foret && !parcelle[0].Mer) // Si la parcelle n'est pas foret/mer, alors la lettre augmente de 1. a --> b.  b --> c. etc...
                        {
                            charCounter++;
                        }


                        foreach (Land land in parcelle) // Pour chaque case dans la parcelle
                        {
                            land.Color = RandomColor; // La couleur est celle choisi aléatoirement/dans l'ordre. La couleur change a chaque case, mais vu que les cases déjà traité ne sont pas retraité,
                                                      // elles ne sont pas changé, donc on peut définir la couleur de TOUTE la parcelle sans soucis.

                            if (land.Mer) // Si c'est la mer
                            {
                                land.Lettre = 'M'; // la lettre est 'M'
                                land.Color = ConsoleColor.Blue; // la couleur est remplacé par Bleu
                            }
                            else if (land.Foret) // similaire pour la foret
                            {
                                land.Lettre = 'F';
                                land.Color = ConsoleColor.Green;
                            }
                            else
                            {
                                land.Lettre = (char)charCounter; // Sinon, on met simplement la lettre défini plus haut.
                            }


                            decodedTab[land.Y, land.X] = land; // On ajoute les cases de la parcelle dans le tableau 2D de la carte décodé.
                                                               // (Chaque case stocke ses coordonnées)

                        }
                    }

                }
            }
            return decodedTab; // on retourne le tableau décodé quand on a fini.
            

        }
        #endregion

        #region AffichageAscii
  

        /// <summary>
        ///  Fonction qui permet d'afficher la carte comme demandé (avec des couleurs) avec des caractères ASCII
        /// </summary>
        public void affichageAscii()
        {
            for (int i = 0; i < 10; i++) // Parcours les lignes tableau
            {
                Console.WriteLine();




                for (int j = 0; j < 10; j++) // Parcours les colonnes tableau
                {
                    Console.ForegroundColor = carte[i, j].Color;
                    Console.Write(carte[i, j].Lettre); // Affiche chaque lettre de la carte 
                    Console.ForegroundColor = ConsoleColor.White; // Mets en blanc tous les caractères dans la console qui ne font pas parti de la carte


                    // 2 affichages différent, les 2 sont bien.
                    Console.Write(""); // Pas de séparations
                                       //Console.Write(":"); // Permet de séparer chaque caractère par :
                }
            }
            Console.WriteLine("\n");
        }

        #endregion
        #region AffichageCarte

        /// <summary>
        /// Mon petit bijou, affiche la carte "visuellement" avec des couleurs, etc... c'est super beau 
        /// </summary>
        /// <param name="mapSize"> La taille d'affichage de la carte </param>
        public void affichageCarte(int mapSize) {
            Console.WriteLine("\n");
            for (int i = 0; i < 10; i++) // Parcours les lignes tableau
            {
                Console.WriteLine();
                for (int s = 0; s < mapSize; s++)
                {
                    for (int j = 0; j < 10; j++) // Parcours les colonnes tableau
                    {
                        Console.BackgroundColor = carte[i, j].Color; // Change la couleur pour être la même que celle de la case sur laquelle on est.
                        for (int k = 0; k < mapSize * 2; k++) { Console.Write(" "); } // Affiche rien, mais permet de "colorier" le fond.
                        Console.BackgroundColor = ConsoleColor.Black; // Remet en noir le fond.


                    }
                    if (s < mapSize-1) { Console.Write("\n"); }


                }
            }
            Console.WriteLine();
        }

            
        
        #endregion

        #region parcours Parcelle

        /// <summary>
        /// Récupère la liste de toute les parcelles. Utilisé dans quasi toute les autres fonction lié au parcelles.
        /// </summary>
        /// <returns>Retourne une liste qui contient des listes de cases "Land".</returns>
        List<List<Land>> ParcoursParcelle()
        {
            List<List<Land>> Liste_parcelle = new List<List<Land>>(); // Une liste qui contient des listes de cases
            for (int t = 0; t < 30; t++)
            {
                Liste_parcelle.Add(new List<Land>()); // on créer 30 listes pour être sur d'en avoir assez pour toute les parcelles
            }


            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++) // on va sur chaque case du tableau
                {
                    if (carte[i, j].Lettre != 'M' && carte[i, j].Lettre != 'F') // si ce n'est pas un type mer/foret
                    {
                        Liste_parcelle[carte[i, j].Lettre - 'a'].Add(carte[i, j]); // on l'ajoute à sa liste attitré. Pour savoir, on utilise le code ASCII de la lettre de la case.
                                                                                   // Par exemple, toute les cases marqué "a" vont aller dans la liste n°0 car a-a = 0 | 96 - 96 = 0
                                                                                   // B-A = 1 car 97-96 = 1.

                    }
                }
            }

            for (int i = 0; i < Liste_parcelle.Count; i++) // on parcours les listes de parcelles et on supprimes celles qui sont vide.
            {
                if (Liste_parcelle[i].Count <= 0)
                {
                    Liste_parcelle.RemoveAt(i);
                    i--; // Vu que dès qu'on supprime un élément, la liste se "tasse", on doit reculer le compteur de 1 aussi.
                }
            }

            return Liste_parcelle;
        }
        #endregion

        #region AffichageListeParcelle
        /// <summary>
        /// Fonction qui affiche la liste des parcelles
        /// </summary>
        public void affichageListeParcelle()
            {

            List<List<Land>> listeParcelles = ParcoursParcelle(); // on récupère la liste des parcelles

            Console.WriteLine("----------------------------------------------------------------------" +
                "\n{0} parcelles:", listeParcelles.Count()); // on affiche le nombre de parcelles

            foreach(List<Land> parcelle in listeParcelles) // On parcours la liste des parcelles
            {

                // On affiche le nom de la parcelle dans sa couleur ainsi que le nombre de cases dans la parcelle
                Console.Write("Parcelle"); 
                Console.ForegroundColor = parcelle[0].Color;
                Console.Write(" {0} ", parcelle[0].Lettre);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("- {0} unités:\n",parcelle.Count());
                
                foreach(Land terre in parcelle) // On prend chaque case et on affiche ses coordonnées dans sa couleur.
                {
                    Console.ForegroundColor = terre.Color;
                    Console.Write(" ({0},{1}) ", terre.X, terre.Y);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine("\n");
            }



        }
        #endregion

        #region AffichageTailleParcelle
     /// <summary>
     /// Fonction qui affiche la taille d'une parcelle en particulier
     /// </summary>
     /// <param name="toFind"> La parcelle dont on veut connaitre la taille </param>
     /// <param name="mute"> Permet de désactiver le retour écrit, utile pour les fonction qui se servent de celle ci mais ne veulent pas afficher le texte. </param>
     /// <returns> Retourne la taille de la parcelle.</returns>
        public int affichageTailleParcelle(char toFind, Boolean mute) // mute permet de ne pas afficher de texte au besoin
        {
            List<List<Land>> listeParcelles = ParcoursParcelle(); // on récupère la liste des parcelles
            Boolean found = false;
            foreach (List<Land> parcelle in listeParcelles) // On parcours la liste des parcelles
            {
                if (parcelle[0].Lettre == toFind) // Si on trouve la lettre recherché dans une parcelle
                {
                    found = true;
                    if (!mute) { Console.WriteLine("----------------------------------------------------------------------" +
                        "\nTaille de la parcelle {0}: {1} unités.\n", toFind, parcelle.Count); } // On affiche le texte approprié
                    return parcelle.Count;
                }
            }
            if (!found)
            {
                if (!mute) { Console.WriteLine("\nLa parcelle {0} n'existe pas.\n", toFind); } // Si on a rien trouvé, on dis que la parcelle n'existe pas.

            }
            return 0;
        }
        #endregion

        #region affichagePlusGrandeParcelle
        /// <summary>
        /// Affiche les parcelles plus grande qu'un certain montant
        /// </summary>
        /// <param name="minSize"> La taille dont les parcelles doivent être supérieur </param>
        public void affichageParcelleSuperieurA(int minSize)
        {
            Boolean found = false;
            Console.WriteLine("----------------------------------------------------------------------" +
                "\nParcelle de taille supérieur à {0}", minSize);
            List<List<Land>> listeParcelles = ParcoursParcelle(); // on récupère la liste des parcelles

            foreach (List<Land> parcelle in listeParcelles)
            {
                int taille = affichageTailleParcelle(parcelle[0].Lettre, true);
                if (taille > minSize)
                {
                    found = true;
                    Console.WriteLine("Parcelle {0}: {1} unités.", parcelle[0].Lettre, taille);
                }
            }

            if (!found)
            {
                Console.WriteLine("Aucune parcelle n'as été trouvé.");
            }


        }
        #endregion

        #region affichageTailleMoyenne
        /// <summary>
        /// Affiche la taille moyenne de toute les parcelles
        /// </summary>
        public void affichageTailleMoyenne()
        {


            List<List<Land>> listeParcelles = ParcoursParcelle(); // on récupère la liste des parcelles

            float moyenne = 0;

            foreach (List<Land> parcelle in listeParcelles)
            {
                moyenne += affichageTailleParcelle(parcelle[0].Lettre, true);




            }

            moyenne = moyenne / listeParcelles.Count();

            Console.WriteLine("----------------------------------------------------------------------" +
                "\nLa taille moyenne est: {0}", Math.Round(moyenne, 2));
        }
        #endregion

    }
}
