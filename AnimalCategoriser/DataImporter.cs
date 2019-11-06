using System;
using System.Collections.Generic;
using System.IO;

namespace AnimalCategoriser
{
    public class DataImporter
    {
        // Property
        public List<Animal> Animals { get; set; } 

        // Method
        public void ImportAnimals()
        {
            int counter = 0;
            string line;

            try
            {
                // Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("../../animals.csv");

                // Initialise the collection of Animals
                List<Animal> animals = new List<Animal>();

                // Read the first line of text
                line = sr.ReadLine();

                Console.WriteLine("Contents of text file:");
                // Continue to read until you reach end of file
                while (line != null)
                {
                    if (counter != 0)
                    {
                        // Split the string into [ name, category, hasTail ]
                        string[] animalProperties = line.Split(new Char[] { ',' });
                        string name = animalProperties[0];
                        string category = animalProperties[1];
                        Boolean hasTail = true;
                        if (animalProperties[2].Equals("No"))
                        {
                            hasTail = false;
                        }
                        // Initialise Animal object with the derived properties
                        Animal animal = new Animal(name, category, hasTail);
                        // Add the new Animal object to the List
                        animals.Add(animal);
                        // Write the line to console window
                        Console.WriteLine($"New Animal object properties: {animal.Name}, {animal.Category}, {animal.HasTail.ToString()}");
                    }
                    // Read the next line
                    line = sr.ReadLine();
                    counter++;
                }

                // Close the file
                sr.Close();

                Animals = animals;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message); ;
            }
            finally
            {
                Console.WriteLine("\nImported animal data from csv.\n\n");                
            }
        }

        public DataImporter()
        {
        }
    }
}
