using System;
using System.Collections.Generic;
using System.Text;

namespace RhumDeGuybrush
{
    
     class Land
    {
        #region Attribut
        public string nb; // Le nombre si land = encodé
        public char lettre; // la lettre si land = décodé

        public System.ConsoleColor color;

        public int x; // Coordonnées x (dans le tableau) de l'élément
        public int y; // ........... y ..............................


        // Booleans pour savoir l'état de la case
        public Boolean frontiereHaut = false;
        public Boolean frontiereBas = false;
        public Boolean frontiereGauche = false;
        public Boolean frontiereDroit = false;
        public Boolean mer = false;
        public Boolean foret = false; 

        public Boolean done = false; // Pour savoir si cette case a déjà été traité
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
        // un acesseur, mais au final c'était trop long et embêtant donc j'ai mis les propriétés qui ont besoin d'être accédé en public, même si c'est pas très bien
        public string Nb
        {
            get { return nb; }
        }
        #endregion
    }
}
