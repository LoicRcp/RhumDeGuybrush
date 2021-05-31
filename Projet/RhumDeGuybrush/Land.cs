using System;
using System.Collections.Generic;
using System.Text;

namespace RhumDeGuybrush
{
     class Land
    {
        public string nb; // Le nombre si land = encodé
        public char lettre; // la lettre si land = décodé

        public System.ConsoleColor color;

        public int x; // Coordonnées x (dans le tableau) de l'élément
        public int y; // ........... y ..............................

        public Boolean frontiereHaut = false;
        public Boolean frontiereBas = false;
        public Boolean frontiereGauche = false;
        public Boolean frontiereDroit = false;
        public Boolean mer = false;
        public Boolean foret = false; // les paramètres

        public Boolean done = false; // pour savoir si on va faire un check avec la fonctio un récursive dessus - C'est de l'optimisation en gros

        public Land(string _nb, int _y, int _x) // Constructeur pour un bout de terre encodé (on donne que le nombre)
        {

            x = _x;
            y = _y;
            nb = _nb;
            int intNb = Convert.ToInt32(_nb);

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


    

        Land(char lettre, Boolean frontHaut, Boolean frontBas, Boolean frontGauche, Boolean frontDroite, Boolean mer, Boolean foret) // Constructeur pour un bout de terre décodé, on donne son nom de parcelle et ses propriétés
        {



        }



        public string Nb
        {
            get { return nb; }
        }
    }
}
