namespace Hearthstone
{
    internal class Program
    {
        //
        static string CARD_PATH = Path.Combine("..", "..", "..", "cards.txt");
        //
        
        private static void Main(string[] args)
        {
            /*Card card = new Card("Dragon", 20, 100);
            
            card.Draw();*/

            List<Card> allCards = ReadCardsFromFile(CARD_PATH);

            foreach (Card card in allCards)
            {
                card.Draw();
            }
            
            Console.ReadKey();
        }

        private static List<Card> ReadCardsFromFile(string path)
        {
            List<Card> cards = new List<Card>();

            try
            {
                string[] lines = File.ReadAllLines(path);

                foreach (string line in lines)
                {
                    string[] values = line.Split(',');

                    if (values.Length == 3)
                    {
                        string name = values[0];
                        int attack =  int.Parse(values[1]);
                        int health = int.Parse(values[2]);
                        
                        Card newCard = new Card(name, attack, health);
                        
                        cards.Add(newCard);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error reading cards from file: {e.Message}");
            }
            
            return cards;
        }
    }
}

