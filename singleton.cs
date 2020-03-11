using System;

namespace jeanpatterns.Singleton
{
    
    class Singleton
    {
        
        private Singleton() { }

       
        private static Singleton _instance;

      
        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }

     
        public static void LogicaDeNegocios()
        {
            // ...
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            Singleton s1 = Singleton.GetInstance();
            Singleton s2 = Singleton.GetInstance();

            if (s1 == s2)
            {
                Console.WriteLine("Singleton ha funcionado, ambas variables contienen la misma instancia.");
            }
            else
            {
                Console.WriteLine("Singleton ha fallado, las  variables contienen differentes instancias.");
            }
        }
    }
}