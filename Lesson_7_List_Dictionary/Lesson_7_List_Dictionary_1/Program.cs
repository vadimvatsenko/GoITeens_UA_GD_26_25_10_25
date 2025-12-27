using System;

namespace Lesson_7_List_Dictionary_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>();

            List<string> people = new List<string>() 
                { "Tom", "Bill", "John" };

            // копія
            List<string> newList = new List<string>(people); // "Tom", "Bill", "John", "Bob"
            newList.Add("Bob");
            
            newList.Remove("Bill");

            // силка на newList
            List<string> newPeople = newList; // "Tom", "Bill", "John", "Mike"
            
            // void Add(T item): додавання нового елемента до списку
            newPeople.Add("Mike");
            
            // bool Remove(T item): видаляє елемент item зі списку, і якщо видалення успішне — повертає true. Якщо у списку кілька однакових елементів — видаляється лише перший з них
            newPeople.Remove("Tom");
            
            // довжина списку. newPeople.Count
            int langthnewPeople = newPeople.Count;
            
            // bool Contains(T item): повертає true, якщо елемент item є у списку
            bool isContainsRoman = newPeople.Contains("Roman");
            bool isContainsMile = newPeople.Contains("Mike");
            Console.WriteLine(isContainsRoman);
            Console.WriteLine(isContainsMile);

            if (isContainsRoman)
            {
                newPeople.Add("Roman");
            }
            
            // void Sort(): сортування списку
            newPeople.Sort();

            // void Reverse(): змінює порядок елементів на зворотний
            newList.Reverse();
            
            foreach (var n in newPeople)
            {
                Console.WriteLine(n);
            }
            
            // void Insert(int index, T item): вставляє елемент item у список за індексом index. Якщо такого індексу у списку немає — генерується виняток
            newPeople.Insert(1, "Roman");

            // newPeople[1] = "Poly";
            
            Console.WriteLine();
            
            foreach (var n in newPeople)
            {
                Console.WriteLine(n);
            }
            
            // void Clear(): видаляє зі списку всі елементи
            newPeople.Clear();
            
            Console.WriteLine("Empty list");
            foreach (var n in newPeople)
            {
                Console.WriteLine(n);
            }
            
            
            /*for (int i = 0; i < newList.Count; i++)
            {
                Console.WriteLine(newList[i]);
            }*/
            
            /*foreach (string person in newList)
            {
                Console.WriteLine(person);
            }
            
            Console.WriteLine();
            
            foreach (string person in newPeople)
            {
                Console.WriteLine(person);
            }*/
            
            
            Console.ReadKey();
            
        }
    }
}

// void Add(T item): додавання нового елемента до списку

// void AddRange(IEnumerable<T> collection): додавання до списку колекції або масиву

// int BinarySearch(T item): бінарний пошук елемента у списку. 
// Якщо елемент знайдено — метод повертає індекс цього елемента в колекції. 
// При цьому список має бути відсортований.
// Дуже швидкий пошук

// void CopyTo(T[] array): копіює список у масив array

// void CopyTo(int index, T[] array, int arrayIndex, int count):
// копіює зі списку, починаючи з індексу index, 
// елементи в кількості count і вставляє їх у масив array, починаючи з індексу arrayIndex

// bool Exists(Predicate<T> match): повертає true, якщо у списку є елемент, який відповідає делегату match

// T? Find(Predicate<T> match): повертає перший елемент, який відповідає делегату match. Якщо елемент не знайдено — повертається null
// Find: перший елемент, який підходить умові
// Знайдемо перше ім'я, яке починається на 'A'
// string? firstA = names.Find(name => name.StartsWith("A"));

// T? FindLast(Predicate<T> match): повертає останній елемент, який відповідає делегату match. Якщо елемент не знайдено — повертається null

// List<T> FindAll(Predicate<T> match): повертає список елементів, які відповідають делегату match

// int IndexOf(T item): повертає індекс першого входження елемента у списку

// int LastIndexOf(T item): повертає індекс останнього входження елемента у списку

// List<T> GetRange(int index, int count): повертає список елементів у кількості count, починаючи з індексу index



// void InsertRange(int index, collection): вставляє колекцію елементів collection у поточний список, починаючи з індексу index. Якщо такого індексу у списку немає — генерується виняток

// bool Remove(T item): видаляє елемент item зі списку, і якщо видалення успішне — повертає true. Якщо у списку кілька однакових елементів — видаляється лише перший з них

// void RemoveAt(int index): видаляє елемент за вказаним індексом index. Якщо такого індексу у списку немає — генерується виняток

// void RemoveRange(int index, int count): параметр index задає індекс, з якого потрібно видалити елементи, а параметр count задає кількість елементів, що видаляються

// int RemoveAll(Predicate<T> match): видаляє всі елементи, які відповідають делегату match. Повертає кількість видалених елементів

// void Reverse(int index, int count): змінює порядок на зворотний для елементів у кількості count, починаючи з індексу index




