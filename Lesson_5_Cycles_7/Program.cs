using System;
using System.IO;
using System.Linq;

// =====================
// WORDLE EVALUATION FUNCTION
// =====================



string[] EvaluateGuess(string guess, string answer)
{
    guess = guess.ToLower();
    answer = answer.ToLower();

    var result = new string[guess.Length];
    var used = new bool[answer.Length];

    // Step 1 — mark greens
    for (int i = 0; i < guess.Length; i++)
    {
        if (guess[i] == answer[i])
        {
            result[i] = "Green";
            used[i] = true;
        }
    }

    // Step 2 — mark yellows
    for (int i = 0; i < guess.Length; i++)
    {
        if (result[i] == "Green")
            continue;

        bool found = false;

        for (int j = 0; j < answer.Length; j++)
        {
            if (!used[j] && guess[i] == answer[j])
            {
                used[j] = true;
                result[i] = "Yellow";
                found = true;
                break;
            }
        }

        if (!found)
            result[i] = "Gray";
    }

    return result;
}

// =====================
// RESTART FUNCTION
// =====================
bool RestartGame()
{
    while (true)
    {
        Console.Write("Restart game? (yes/no): ");
        string input = Console.ReadLine()?.Trim().ToLower();

        if (input == "yes" || input == "y")
            return true;

        if (input == "no" || input == "n")
            return false;

        Console.WriteLine("Please type yes or no.");
    }
}

// =====================
// WORDLE GAME FUNCTION
// =====================
void PlayGame()
{
    // ⭐⭐ Load words from your dictionary file ⭐⭐
    string path = @"C:\Users\timofii\Downloads\words.txt";

    string[] words = File.ReadAllLines(path)
                         .Where(w => w.Length == 5)
                         .Select(w => w.Trim())
                         .ToArray();

    if (words.Length == 0)
    {
        Console.WriteLine("ERROR: No 5-letter words found in dictionary file!");
        return;
    }

    var rand = new Random();
    var randWord = words[rand.Next(words.Length)];
    int tries = 5;

    while (tries > 0)
    {
        Console.Write("Enter a 5 letter word: ");
        string guess = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(guess))
        {
            Console.WriteLine("Please enter a valid guess.");
            continue;
        }

        guess = guess.ToLower();
        randWord = randWord.ToLower();

        if (guess.Length != randWord.Length)
        {
            Console.WriteLine("The word must be 5 letters long!");
            continue;
        }

        if (!words.Contains(guess.ToLower()))
        {
            Console.WriteLine("Not a valid dictionary word!");
            continue;
        }

        if (guess.Equals(randWord, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Congratulations! You guessed it!");
            break;
        }

        var feedback = EvaluateGuess(guess, randWord);

        for (int i = 0; i < guess.Length; i++)
        {
            switch (feedback[i])
            {
                case "Green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "Yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "Gray":
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
            }
            Console.Write(char.ToUpper(guess[i]));
            Console.ResetColor();
            Console.Write(" ");
        }

        Console.WriteLine();
        tries--;
        Console.WriteLine(tries + " tries left!");
    }

    if (tries == 0)
    {
        Console.WriteLine("Game Over! The word was " + randWord.ToUpper() + "!");
    }
}

// =====================
// MAIN GAME LOOP
// =====================
while (true)
{
    PlayGame();

    if (!RestartGame())
        break;

    Console.Clear();
}
