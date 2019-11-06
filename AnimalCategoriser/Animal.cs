using System;
namespace AnimalCategoriser
{
    public class Animal
    {
        // Property
        public string Name { get; set; }
        public string Category { get; set; }
        public Boolean HasTail { get; set; }

        // Instance Constructor
        public Animal(string name, string category, Boolean hasTail)
        {
            Name = name;
            Category = category;
            HasTail = hasTail;
        }
    }
}
