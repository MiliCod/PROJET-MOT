using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace PROJET_MOT
{
    public class Dictionnaire
    {
        private string language;
        private List<string> findedword;                               // Attributs de la classe dictionnaire.
        private string myfile = "";
        

        public Dictionnaire(string Language)                           // Constructeur
        {
            this.language = Language;
            this.findedword =  new List<string>() ;
            if (language == "anglais")
            {
                myfile = "DictionnaireEN.txt";
            }
            else if (language == "francais") 
            {
                myfile = "DictionnaireFR.txt";
            }
            
        }
        public string Language                                         // Proprieté Language qui definit des accés en consultation 
        {
            get { return language; }
            
        }
        public List<string> Findedword                                 // Proprieté Findedword qui definit des accés en consultation
        {
            get { return findedword; }
        }
                                                                    
        public bool Reading(string word , string language ,string myfile)               // Méthode pour Lire le dictionnaire et retourner un booléen pour voir si un mot est dans le dictionnaire ou pas .
        {
            if (language == "anglais")
            {
                myfile = "DictionnaireEN.txt";
            }
            else if (language == "francais")
            {
                myfile = "DictionnaireFR.txt";
            }
            word = word.ToUpper();                                     // Les mots dans le dictionnaire sont en majuscules.
            bool words = false;
            List<string[]> Dico = new List<string[]>();                // Création d'une liste de tableau .
            string recup = "";                                         
            using (StreamReader txt = new StreamReader(myfile))        // Lecture du fichier dictionnaire 
            {
                recup = txt.ReadToEnd();                               // Recuperation du fichier dans le string recup .
            }    // Lecture du fichier dictionnaire .
            string[] a = recup.Split('\n');                            // Decoupage du tableau en "\n".  
            for (int i = 0; i < a.Length; i++)
            {
                if (i % 2 == 1)                                        // Eliminer les chiffres du tableau qui sont dans les lignes paires .
                {
                    Dico.Add(a[i].Split(' '));                         // Ajout à la liste Dico les tab[i] en fonction du nombre de lettres et sans espaces.
                }
            }
            for (int i = 0; i < Dico[word.Length - 2].Length; i++)    // Parcours de la liste jusqu'au tableau avec le nombre de lettre de notre mot recherché .
            { 
                if (word==Dico[word.Length - 2][i])                   // Si le mot est retrouvé 
                {
                    words = true;                                     // Retourner true pour montrer que le mot existe bien dans le fichier dictionnaire .
                }
            }

            return words;
        }
        public string toString()                                       // Méthode toString() qui retourne la derscription du fichier dictionnaire
        {
            string m = "le Dictionnaire est : "+language+"\n";        
            List<string[]> Dico = new List<string[]>();
            string recup = "";
            using (StreamReader txt = new StreamReader("DictionnaireFR.txt"))      // Lecture du fichier dictionnaire
            {
                recup = txt.ReadToEnd();                             // Recuperation du fichier dans le string recup.
            }
            string[] a = recup.Split('\n');                          //  Decoupage du tableau en "\n".
            for (int i = 0; i < a.Length; i++)
            {
                if (i % 2 == 1)                                      // Eliminer les chiffres du tableau qui sont dans les lignes paires .
                {
                    Dico.Add(a[i].Split(' '));                       // Ajout à la liste Dico les tab[i] en fonction du nombre de lettres et sans espaces.
                }
            }
            for (int i = 0; i < Dico.Count; i++)                    // Parcourir toute la liste de tableau Dico
            {
                m =m+"Les mots de tailles "+ (i + 2) + " sont présent " + Dico[i].Length +" fois dans le dictionnaire "+language+ ". \n";
            }
            return m;                                               // Retouner les phrases qui decrivent le dictionnaires . 
        }
        
            
       
    }
}
