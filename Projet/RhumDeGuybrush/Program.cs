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



            // Les chemins vers les différentes cartes clair/chiffré

            string pathScabbChiffre = @"I:\DUT\Informatique\1E_Année\Semestre2\M1104 - Conception Orientée Objet\Rhum De Guybrush\RhumDeGuybrush\Projet\testInput\Phatt.chiffre.txt";
            string pathScabbClair = @"I:\DUT\Informatique\1E_Année\Semestre2\M1104 - Conception Orientée Objet\Rhum De Guybrush\RhumDeGuybrush\Projet\testInput\Phatt.clair.txt";
            string pathPhattChiffre = @"I:\DUT\Informatique\1E_Année\Semestre2\M1104 - Conception Orientée Objet\Rhum De Guybrush\RhumDeGuybrush\Projet\testInput\Scabb.chiffre.txt";
            string pathPhattClair = @"I:\DUT\Informatique\1E_Année\Semestre2\M1104 - Conception Orientée Objet\Rhum De Guybrush\RhumDeGuybrush\Projet\testInput\Scabb.clair.txt";



            // On peut créer une ile avec une carte clair/chiffré sans soucis

            Ile Scabb1 = new Ile(pathScabbChiffre);
            Ile Phatt1 = new Ile(pathPhattClair);




            // Scabb



            Scabb1.affichageAscii(); // On affiche la carte sous forme de caractères de couleur. Uniquement les forêts/lacs sont en vers/bleu.

            int size = 2; // la taille de la carte "non-Ascii" (Essayez Mr c'est incroyable, jusque 4 y'as pas de problème, après ça devient tendu)
            if (size > 4) { Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight); } // Si la carte est trop grande,
                                                                                                              // on augmente la taille du terminal.
            Scabb1.affichageCarte(size); // On affiche la carte sans les caractères
            


            Scabb1.affichageListeParcelle(); // on affiche la liste des parcelles qui composent l'ile
            Scabb1.affichageTailleParcelle('a', false); // On affiche la taille d'une parcelle en particulier (voir doc pour paramètres)
            Scabb1.affichageParcelleSuperieurA(5); // On affiche toute les parcelles ayant une taille supérieur a X
            Scabb1.affichageTailleMoyenne(); // On affiche la taille moyenne des parcelles.


            // Phatt

            Phatt1.affichageAscii();

            size = 2; // la taille de la carte "non-Ascii" 
            if (size > 4) { Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight); }

            Phatt1.affichageCarte(size);

            Scabb1.affichageListeParcelle(); // on affiche la liste des parcelles qui composent l'ile
            Scabb1.affichageTailleParcelle('a', false); // On affiche la taille d'une parcelle en particulier (voir doc pour paramètres)
            Scabb1.affichageParcelleSuperieurA(5); // On affiche toute les parcelles ayant une taille supérieur a X
            Scabb1.affichageTailleMoyenne(); // On affiche la taille moyenne des parcelles.

        }
    }
}
