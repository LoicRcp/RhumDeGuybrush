using System;
using System.Collections.Generic;
using System.Text;

namespace RhumDeGuybrush
{
    /// <summary>
    /// Classe qui stocke les informations importantes concernant une case. Sa position, sa couleur, son numéro, sa lettre, ses propriétés de voisinage, son type, etc...
    /// </summary>
     class Land
    {
        #region Attribut
         string nb; // Le nombre si land = encodé
         char lettre; // la lettre si land = décodé

         System.ConsoleColor color;

         int x; // Coordonnées x (dans le tableau) de l'élément
         int y; // ........... y ..............................


        // Booleans pour savoir l'état de la case
         Boolean frontiereHaut = false;
         Boolean frontiereBas = false;
         Boolean frontiereGauche = false;
         Boolean frontiereDroit = false;
         Boolean mer = false;
         Boolean foret = false; 

         Boolean done = false; // Pour savoir si cette case a déjà été traité
        #endregion

        #region Constructeur
        public Land(string _nb, int _y, int _x) // Constructeur pour un bout de terre encodé (on donne que le nombre)
        {

            x = _x;
            y = _y;
            nb = _nb;
            int intNb = Convert.ToInt32(_nb);

            // on prend les plus grand nombre possible, et on les soustraits, si c'est positif, c'est que cette éventualité est vrai.
            // ça nous permet de savoir les propriétés de la case en fonction du nombre associé.
            
            if (intNb - 64 >= 0)
            {
                mer = true;
                intNb -= 64;
            }
            else if (intNb - 32 >= 0)
            {
                foret = true;
                intNb -= 32;
            }

            if (intNb - 8 >= 0)
            {
                frontiereDroit = true;
                intNb -= 8;
            }
            if (intNb - 4 >= 0)
            {
                frontiereBas = true;
                intNb -= 4;
            }
            if (intNb - 2 >= 0)
            {
                frontiereGauche = true;
                intNb -= 2;
            }
            if (intNb - 1 >= 0)
            {
                frontiereHaut = true;
                intNb -= 1;
            }



            // Console.WriteLine("haut: {0}\nbas: {1}\ngauche: {2}\ndroite: {3}\nmer: {4}\nforet:{5}\n", frontiereHaut, frontiereBas, frontiereGauche, frontiereDroit, mer, foret);

        }
        


        // Ne sera pas utilisé finalement
        Land(char lettre, Boolean frontHaut, Boolean frontBas, Boolean frontGauche, Boolean frontDroite, Boolean mer, Boolean foret) // Constructeur pour un bout de terre décodé, on donne son nom de parcelle et ses propriétés
        {



        }
        #endregion

        #region Acesseur
        public string Nb
        {
            get { return nb; }
        }
        public char Lettre
        {
            get { return lettre; }
            set { lettre = value; }
        }
        public System.ConsoleColor Color
        {
            get { return color; }
            set { color = value; }
        }
        public int X
        {
            get { return x; }
        }
        public int Y
        {
            get { return y; }
        }
        public Boolean FrontiereHaut
        {
            get { return frontiereHaut; }
        }
        public Boolean FrontiereBas
        {
            get { return frontiereBas; }
        }
        public Boolean FrontiereGauche
        {
            get { return frontiereGauche; }
        }
        public Boolean FrontiereDroit
        {
            get { return frontiereDroit; }
        }
        public Boolean Mer
        {
            get { return mer; }
        }
        public Boolean Foret
        {
            get { return foret; }
        }
        public Boolean Done
        {
            get { return done; }
            set { done = value; }
        }





        #endregion
    }
}
