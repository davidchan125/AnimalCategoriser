using System;
using System.Collections.Generic;
using System.IO;

namespace AnimalCategoriser
{
    class MainClass
    {
        public static List<Animal> animals;
        public static List<string> Categorise(string category)
        {
            List<string> matchedAnimals = new List<string>();
            foreach (Animal a in animals) {
                if (a.Category.Equals(category))
                {
                    matchedAnimals.Add(a.Name);
                }
            }

            return matchedAnimals;
        }

        public static List<string> Categorise(string category, bool hasTail)
        {
            List<string> matchedAnimals = new List<string>();

            foreach (Animal a in animals)
            {
                if (a.Category.Equals(category) && a.HasTail.Equals(hasTail))
                {
                    matchedAnimals.Add(a.Name);
                }
            }

            return matchedAnimals;
        }

        public static void Main(string[] args)
        {
            DataImporter dataImporter = new DataImporter();
            dataImporter.ImportAnimals();
            animals = dataImporter.Animals;

            TextReader tIn = Console.In;
            string choice = "";
            bool choiceNotEntered = false;

            while (!choice.Equals("x"))
            {
                Console.Clear();
                if (choiceNotEntered)
                {
                    Console.WriteLine("Please enter one of the listed choices.");
                    choiceNotEntered = false;
                }
                Console.WriteLine("Animal Categoriser");
                Console.WriteLine("[1] Filter animals by category");
                Console.WriteLine("[2] Filter animals by category and tail/no tail");
                Console.Write("Enter [1], [2] or [x] (excluding the square brackets): ");
                choice = tIn.ReadLine();

                if (choice.Equals("1") || choice.Equals("2"))
                {
                    List<string> matchedAnimals = new List<string>();
                    if (choice.Equals("1"))
                    {
                        Console.WriteLine("\nFilter animals by category");
                    } else if (choice.Equals("2"))
                    {
                        Console.WriteLine("\nFilter animals by category and tail/no tail");
                    }
                    
                    Console.Write("Enter a category: ");
                    string category = tIn.ReadLine();
                    if (choice.Equals("1"))
                    {
                        matchedAnimals = Categorise(category);
                    }
                    else if (choice.Equals("2"))
                    {
                        Console.Write("Has a tail? Enter [Y] or [N] (excluding square brackets): ");
                        string hasTail = tIn.ReadLine();
                        if (hasTail.Equals("Y"))
                        {
                            matchedAnimals = Categorise(category, true);
                        }
                        else
                        {
                            matchedAnimals = Categorise(category, false);
                        }
                    }

                    Console.WriteLine("Found animals: ");
                    foreach (string a in matchedAnimals)
                    {
                        Console.WriteLine(a);
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                }

                if (!choice.Equals("x") && !(choice.Equals("1") || choice.Equals("2")))
                {
                    choiceNotEntered = true;
                }
            }
        }
    }
}
