namespace Questions_1;

internal static class Names
{
    private static readonly List<string> names = new List<string>()
    {
        "Бабан Владислав", // 0
        "Виклюк Тетяна", // 1
        "Дерев'янко Роман", // 2
        "Іщук Андрій", // 3
        "Килюшик Владислав", // 4
        "Максимович Гліб",
        "Добриця Микита",
        "Михайлов Артур",
        "Носков Михайло",
        "Пленгей Євген",
        "Скурту Єгор",
        "Сягровец Єгор",
        "Тар Антон",
        "Фісун Денис", 
        "Коваленко Тимофій",
        "Мітя" // 15
    };
    
    public static List<string> GetNames() => names;
}