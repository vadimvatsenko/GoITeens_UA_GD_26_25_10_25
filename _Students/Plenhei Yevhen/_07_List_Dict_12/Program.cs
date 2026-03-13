using System;
using System.Collections.Generic;

namespace PhoneDirectoryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            PhoneDirectory phoneDirectory = new PhoneDirectory();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- Телефонний довідник гри ---");
                Console.WriteLine("1. Додати контакт");
                Console.WriteLine("2. Показати контакти");
                Console.WriteLine("3. Зателефонувати контакту");
                Console.WriteLine("4. Вийти");
                Console.Write("Виберіть дію: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введіть ім'я NPC: ");
                        string name = Console.ReadLine();
                        Console.Write("Введіть номер телефону NPC: ");
                        string phoneNumber = Console.ReadLine();
                        phoneDirectory.AddContact(new Contact(name, phoneNumber));
                        break;

                    case "2":
                        phoneDirectory.ShowContacts();
                        break;

                    case "3":
                        phoneDirectory.ShowContacts();
                        Console.Write("Виберіть номер контакту для дзвінка: ");
                        if (int.TryParse(Console.ReadLine(), out int index))
                        {
                            phoneDirectory.CallContact(index - 1);
                        }
                        else
                        {
                            Console.WriteLine("Невірний ввід!");
                        }
                        break;

                    case "4":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Невірна дія!");
                        break;
                }
            }

            Console.WriteLine("Дякуємо за гру!");
        }
    }
}
    
    // Клас контакту NPC
    class Contact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public Contact(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }

        public void Call()
        {
            Console.WriteLine($"Ви дзвоните {Name} за номером {PhoneNumber}...");
            Console.WriteLine($"{Name}: Привіт! Як справи?");
        }
    }

    // Клас телефонного довідника
    class PhoneDirectory
    {
        private List<Contact> contacts = new List<Contact>();

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
            Console.WriteLine($"Контакт {contact.Name} додано!");
        }

        public void ShowContacts()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("У телефонній книзі немає контактів.");
                return;
            }

            Console.WriteLine("Ваші контакти:");
            for (int i = 0; i < contacts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {contacts[i].Name} - {contacts[i].PhoneNumber}");
            }
        }

        public void CallContact(int index)
        {
            if (index < 0 || index >= contacts.Count)
            {
                Console.WriteLine("Невірний вибір контакту!");
                return;
            }

            contacts[index].Call();
        }
    }