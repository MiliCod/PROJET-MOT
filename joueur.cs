using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace PROJET_MOT
{
    public class joueur
    {
        string name;
        string pseudonym;                                    // Attributs de la classe joueur
        string word;
        List<string> findedword;        
        int score;

        public joueur (string Name, string Pseudonym  )      // Constructeur 
        {
            this.name = Name;
            this.pseudonym = Pseudonym;
            this.findedword = new List<string>();
            this.score = Score= 0;                           // Score initialisé
        }
        public string Name                                   // Proprieté Name qui definit des accés en consultation et modification
        {
            get { return name; }
            set
            {
                if (value == null || value.Trim().Length == 0) { Console.WriteLine("Invalid Name"); name = null; }
                else { name= value; }
            }
        }

        public string Pseudonym                              // Proprieté Pseudonym qui definit des accés en consultation et modification
        {
            get { return pseudonym; }
            set
            {
                if (value == null || value.Trim().Length == 0) { Console.WriteLine("Invalid Pseudonym"); pseudonym= null; }
                else { pseudonym = value; }
            }
        }

        public string Word                                   // Proprieté Word qui definit des accés en consultation .
        {
            get { return word; }
        }

        public int Score                                     // Proprieté Score qui definit des accés en consultation et modification
        {
            get { return score; }
            set { score = value; }
        }    

        public List<string> Findedword                       // Proprieté Findedword qui definit des accés en consultation
        {
            get { return findedword ; }
        }

        public void Add_Mot(string word)                    // Méthode pour ajouter les mots trouvés par l'utilisateur dans une liste qui regroupera tout les mots trouvés .
        {
            Findedword.Add(word);
        }
        public string toString()                            // Méthode qui retourne l'identité du joueur : Nom,Pseudo,score initiale. 
        {
            return "name :" + " " + this.name + "\n" + "pseudonym :" + " " + this.pseudonym + "\n" + "initial score:" + " " + this.score ;
        }
        public void Add_Score(int val)                      // Méthode qui fait augmenter le score en fonction du mot trouvé. 
        {
            Score = Score + val;
        }






    }
}
