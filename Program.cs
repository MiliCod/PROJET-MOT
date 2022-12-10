namespace PROJET_MOT
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Bonjour cher joueur ");
            Console.WriteLine(" Veuillez choisir la langue dans laquelle vous voulez jouer");  
            Console.WriteLine(" Veuillez ecrire francais pour la langue francaise");    
            Console.WriteLine(" Veuillez ecrire anglais pour la langue anglaise");
            string language= Console.ReadLine().ToLower();
            Dictionnaire a = new Dictionnaire(language);
            Console.WriteLine(a.Reading("manger",language,""));
            Console.WriteLine(a.toString());    
        }
    }
}