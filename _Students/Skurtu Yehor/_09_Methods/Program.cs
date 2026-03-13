using System;
namespace Dz_21
{
	class Program
	{
		static void Main(string[] args)
		{
			HelloPlayer();
			Console.WriteLine(HelloPlayer());
			HealthLoss();
			Console.WriteLine(HealthLoss());
			StrongerEnemy();
			Console.WriteLine(StrongerEnemy());
			DosvidPlayers();
			Console.WriteLine(DosvidPlayers());
			Manna();
			Console.WriteLine(Manna());
			Converter();
			Console.WriteLine(Converter());
			GetWinner();
			Console.WriteLine(GetWinner());
			Calculator();
			Console.WriteLine(Calculator());
		}
		static string HelloPlayer(string name = "Єгор")
		{
			return $"Ласкаво просимо в гру, {name}";
		}
		static string HealthLoss(int enemyhit = 40)
		{
			return $"Гравець втратив: {enemyhit} хп";
		}
		static string StrongerEnemy(int enemy1 = 40, int enemy2 = 40)
		{
			if (enemy1 > enemy2)
			{
				return $"Сильніший ворог номер 1: {enemy1}";
			}
			else if (enemy1 < enemy2)
			{
				return $"Сильніший ворог номер 2: {enemy2}";
			}
			else
			{
				return "Вони однакової сили";
			}
		}
		static string DosvidPlayers(int player1 = 10, int player2 = 3, int player3 = 6)
		{
			return $"Середнє значення досвіду: {(player1 + player2 + player3) / 3} XP";
		}
		static string Manna(int manna = 200, int zaklatya = 50)
		{
			int a = manna / zaklatya;
			return $"Манни вистачить на: {a} заклять";
		}
		static string Converter(int zoloto = 500)
		{
			int kursobminyzolotavkristali = 5;
			return $"Якщо обміняти 500кг золота в кристали вийде: {zoloto / kursobminyzolotavkristali} кристалів";
		}
		static string GetWinner(string player1 = "Камінь", string player2 = "Папір")
		{
			if (player1 == player2)
			{
				return "Нічия";
			}
			if(
				(player1 == "Камінь" && player2 == "Ножиці") ||
				(player1 == "Папір" && player2 == "Камінь") ||
				(player1 == "Ножиці" && player2 == "Папір") 
			) 
				return "Гравець 1 переміг";
			else
				return "Гравець 2 переміг";
		}
		static string Calculator(int ataka = 30 ,int zahist = 20, string weaponType = "магія")
		{
			int health = 100;
			int damage = ataka - zahist;
			switch (weaponType)
			{
				case "меч":
					break;

				case "лук":
					damage += 5;
					break;

				case "магія":
					damage += 10;
					break;
			}
			if (damage < 0)
				damage = 0;
			return $"Нанесено урона: {damage} хп, осталося: {health - damage} хп";
		}
	}
}