namespace RPG_Monochrome.Data.Sprites.Coin;

public static class CoinIdle
{
    public static readonly char[,] CoinIdle_1 =
    {
        { ' ', '█', '█', '█', '█', ' ' },
        { '█', '█', '█', '█', '█', '█' },
        { '█', '█', ' ', ' ', '█', '█' },
        { '█', '█', ' ', ' ', '█', '█' },
        { '█', '█', '█', '█', '█', '█' },
        { ' ', '█', '█', '█', '█', ' ' },
    };

    public static readonly char[,] CoinIdle_2 =
    {
        { ' ', '█', '█', '█', '█', ' ' },
        { ' ', '█', '█', '█', '█', ' ' },
        { ' ', '█', '█', ' ', '█', ' ' },
        { ' ', '█', '█', ' ', '█', ' ' },
        { ' ', '█', '█', '█', '█', ' ' },
        { ' ', '█', '█', '█', '█', ' ' },
    };

    public static readonly char[,] CoinIdle_3 =
    {
        { ' ', ' ', '█', '█', ' ', ' ' },
        { ' ', ' ', '█', '█', ' ', ' ' },
        { ' ', ' ', '█', '█', ' ', ' ' },
        { ' ', ' ', '█', '█', ' ', ' ' },
        { ' ', ' ', '█', '█', ' ', ' ' },
        { ' ', ' ', '█', '█', ' ', ' ' },
    };

    public static readonly char[,] CoinIdle_4 =
    {
        { ' ', '█', '█', '█', '█', ' ' },
        { ' ', '█', '█', '█', '█', ' ' },
        { ' ', '█', ' ', '█', '█', ' ' },
        { ' ', '█', ' ', '█', '█', ' ' },
        { ' ', '█', '█', '█', '█', ' ' },
        { ' ', '█', '█', '█', '█', ' ' },
    };

    public static readonly List<char[,]> CoinIdleAnimation = new List<char[,]>()
    {
        CoinIdle_1,
        CoinIdle_2,
        CoinIdle_3,
        CoinIdle_4,
    };
}