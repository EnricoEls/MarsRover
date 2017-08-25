using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.App
{
    public class Program
    {
        private static string choice = "";
        private static List<string> instructions = new List<string>();
        private static bool fileLoaded = false;

        static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            do
            {
                CallInstructions();


            } while (choice != "0");
            {
                Console.WriteLine("Curiosity signing off 8D");
                System.Threading.Thread.Sleep(2000);
            }
        }

        static void CallInstructions()
        {
            Console.WriteLine("1. Provide file directory");

            if (fileLoaded)
            {
                Console.WriteLine("2. Execute instructions");
            }

            Console.WriteLine("0. Close");

            choice = Console.ReadLine();

            switch (choice)

            {

                case "1":
                {
                    UploadFile();
                    break;
                }
                case "2":
                {
                    ExecuteInstructions();
                    break;
                }
            }
        }

        private static void UploadFile()
        {
            var location = "";
            Console.Clear();
            Console.WriteLine("File location:");

            location = Console.ReadLine();

            try
            {
                instructions = TextHelper.ReadTextFile(location);

                fileLoaded = true;
                Console.Clear();
                Console.WriteLine("File uploaded");
                Console.WriteLine("");
                CallInstructions();
            }
            catch (Exception)
            {
                Console.WriteLine("Error in uploaded File");
            }
            
        }

        private static void ExecuteInstructions()
        {
            Console.Clear();
            var roverLogic = new RoverLogic(instructions);
            var result = roverLogic.Execute();

            Console.WriteLine(result);
            Console.WriteLine("");

            if (roverLogic.UnknownInstructions.Any())
            {
                Console.WriteLine("The following instructions could not be computed:");
                foreach (var unknownInstruction in roverLogic.UnknownInstructions)
                {
                    Console.WriteLine(unknownInstruction);
                }
                Console.WriteLine("");
            }

            CallInstructions();
        }
    }
}
