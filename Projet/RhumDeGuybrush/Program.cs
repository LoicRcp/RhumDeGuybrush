using System;
using System.Collections.Generic;
using System.Linq;

namespace RhumDeGuybrush
{
    class Program
    {
        static void Main(string[] args)
        {

            // Faire une interface console:
            // 1) Consulter une carte (Nécessite la carte encodé)
            // 2) Encoder une carte


            // Consultation >> Rentrez la carte encodé ou le chemin vers le fichier texte (Si vous ne l'avez pas, encodez la avec l'option 2 puis revenez ici)

            // Consultation> 1) Afficher l'ile
            // Consultation> 2) Afficher Liste parcelle
            // Consultation> 3) Afficher PlusGrandeParcelle
            // Consultation> 4) Afficher Moyenne taille parcelle

            // Encodage >> Rentrez le chemin vers le fichier texte

            



            Ile ileTest = new Ile("I:\\DUT\\Informatique\\1E_Année\\Semestre2\\M1104 - Conception Orientée Objet\\Rhum De Guybrush\\RhumDeGuybrush\\Projet\\testInput\\Phatt.chiffre.txt");
            ileTest.affichageGlobal();

        }
    }
}
