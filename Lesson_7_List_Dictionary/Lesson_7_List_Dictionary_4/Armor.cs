namespace Lesson_7_List_Dictionary_4;

public class Armor
{
    public ArmorType ArmorType { get; protected set; }
    public int ArmorDamage { get; protected set; }

    public Armor(ArmorType armorType, int armorDamage)
    {
        ArmorType = armorType;
        ArmorDamage = armorDamage;
    }
}