void Add(T item): додавання нового елемента до списку

void AddRange(IEnumerable<T> collection): додавання до списку колекції або масиву

int BinarySearch(T item): бінарний пошук елемента у списку. 
Якщо елемент знайдено — метод повертає індекс цього елемента в колекції. 
При цьому список має бути відсортований.

void CopyTo(T[] array): копіює список у масив array

void CopyTo(int index, T[] array, int arrayIndex, int count): копіює зі списку, починаючи з індексу index, 
елементи в кількості count і вставляє їх у масив array, починаючи з індексу arrayIndex

bool Contains(T item): повертає true, якщо елемент item є у списку

void Clear(): видаляє зі списку всі елементи

bool Exists(Predicate<T> match): повертає true, якщо у списку є елемент, який відповідає делегату match

T? Find(Predicate<T> match): повертає перший елемент, який відповідає делегату match. Якщо елемент не знайдено — повертається null
// Find: перший елемент, який підходить умові
// Знайдемо перше ім'я, яке починається на 'A'
string? firstA = names.Find(name => name.StartsWith("A"));

T? FindLast(Predicate<T> match): повертає останній елемент, який відповідає делегату match. Якщо елемент не знайдено — повертається null

List<T> FindAll(Predicate<T> match): повертає список елементів, які відповідають делегату match

int IndexOf(T item): повертає індекс першого входження елемента у списку

int LastIndexOf(T item): повертає індекс останнього входження елемента у списку

List<T> GetRange(int index, int count): повертає список елементів у кількості count, починаючи з індексу index

void Insert(int index, T item): вставляє елемент item у список за індексом index. Якщо такого індексу у списку немає — генерується виняток

void InsertRange(int index, collection): вставляє колекцію елементів collection у поточний список, починаючи з індексу index. Якщо такого індексу у списку немає — генерується виняток

bool Remove(T item): видаляє елемент item зі списку, і якщо видалення успішне — повертає true. Якщо у списку кілька однакових елементів — видаляється лише перший з них

void RemoveAt(int index): видаляє елемент за вказаним індексом index. Якщо такого індексу у списку немає — генерується виняток

void RemoveRange(int index, int count): параметр index задає індекс, з якого потрібно видалити елементи, а параметр count задає кількість елементів, що видаляються

int RemoveAll(Predicate<T> match): видаляє всі елементи, які відповідають делегату match. Повертає кількість видалених елементів

void Reverse(): змінює порядок елементів на зворотний

void Reverse(int index, int count): змінює порядок на зворотний для елементів у кількості count, починаючи з індексу index

void Sort(): сортування списку

