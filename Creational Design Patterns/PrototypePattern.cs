using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns.Creational_Design_Patterns
{
    public class PrototypePattern
    {
        public interface IPersonPrototype
        {
            IPersonPrototype Clone();
        }

        public class Person : IPersonPrototype
        {
            private string _name;
            private string _email;
            private string _phone;

            public Person (string name, string email, string phone)
            {
                _name = name;
                _email = email;
                _phone = phone;
            }

            public IPersonPrototype Clone()
            {
                return new Person (this._name, _email, _phone);
            }

            public void SetEmail(string email)
            {
                _email = email;
            }

            public void SetPhone(string phone)
            {
                _phone = phone;
            }

            public override string ToString()
            {
                return $"Name: {_name}, Email: {_email}, Phone: {_phone}";
            }
        }

        public class PersonRegistry
        {
            private Dictionary<string, Person> _persons;

            public PersonRegistry()
            {
                _persons = new Dictionary<string, Person>();
            }

            public void RegisterPerson(string name, Person person)
            {
                _persons.TryAdd(name, person);
            }

            public Person Get(string name)
            {
                if(_persons.TryGetValue(name, out var person))
                {
                    return (Person)person.Clone();
                }
                return null;
            }
        }

        public class Program
        {
            public static void Main(string[] args)
            {
                PersonRegistry registry = new PersonRegistry();
                Person person1 = new Person("ashik", "a@gmail.com", "1234");
                Person person2 = new Person("Izhan", "i@gmail.com", "43121");
                registry.RegisterPerson("ashik", person1);
                var person3 = registry.Get("ashik");
                person3.SetEmail("m@gmail.com");

                Console.WriteLine(person1);
                Console.WriteLine(person2);
                Console.WriteLine(person3);
        }
        }
    }
}
