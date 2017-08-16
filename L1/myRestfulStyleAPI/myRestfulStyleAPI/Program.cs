using System;

namespace myRestfulStyleAPI
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            new MyWebServer().runServer(); 

            Console.WriteLine("Successful!");
        
            Console.ReadLine();
        }
    }
}
