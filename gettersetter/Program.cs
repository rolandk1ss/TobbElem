using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gettersetter
{
    class settergetter
    {
        static void Main(string[] args)
        {
            person person = new person();
            person.Name = "Ádám";
            Console.WriteLine(person.Name);

            person.Id = 99;
            Console.WriteLine(person.Id);

            Console.ReadKey();
        }
    }
    class person
    {
        public person() { }

        public string Name { get; set; }

        private int id;
        public int Id { get => id; set => id = 101; }

        private int age;
        public void setAge(int age) { this.age = age; }

        public int getAge(int age) { return this.age; }

        private int gender;

        public void setGender(string gender)
        {
            switch (gender)
            {
                case "Férfi":
                    this.gender = 1;
                    break;
                case "Nő":
                    this.gender = 0;
                    break;
                default:
                    this.gender = 3;
                    break;
            }
        }
        public string getGender()
        {
            switch (this.gender)
            {
                case 1: return "Férfi";
                case 2: return "Nő";
                default: return "Ismeretlen";
            }
        }
    }
}