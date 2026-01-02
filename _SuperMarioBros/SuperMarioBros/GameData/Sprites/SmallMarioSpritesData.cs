namespace SuperMarioBros.GameData.Sprites;

public static class SmallMarioSpritesData
{
    public static readonly string[] SmallMarioIdle =
    {
        ".....RRRRR......",
        "....RRRRRRRRR...",
        "....GGGOOGO.....",
        "...GOGOOOGOOO...",
        "...GOGGOOOGOOO..",
        "...GGOOOOGGGG...",
        ".....OOOOOOO....",
        "....GGRGGG......",
        "...GGGRGGRGGG...",
        "..GGGGRRRRGGGG..",
        "..OOGRORRORGOO..",
        "..OOORRRRRROOO..",
        "..OORRRRRRRROO..",
        "....RRR..RRR....",
        "...GGG....GGG...",
        "..GGGG....GGGG..",
    };
    
    public static readonly char[,] SmallMarioIdle1 =
    {
        {'.','.','.','.','.','R','R','R','R','R','.','.','.','.','.','.'},
        {'.','.','.','.','R','R','R','R','R','R','R','R','R','.','.','.'},
        {'.','.','.','.','G','G','G','O','O','G','O','.','.','.','.','.'},
        {'.','.','.','G','O','G','O','O','O','G','O','O','O','.','.','.'},
        {'.','.','.','G','O','G','G','O','O','O','G','O','O','O','.','.'},
        {'.','.','.','G','G','O','O','O','O','G','G','G','G','.','.','.'},
        {'.','.','.','.','.','O','O','O','O','O','O','O','.','.','.','.'},
        {'.','.','.','.','G','G','R','G','G','G','.','.','.','.','.','.'},
        {'.','.','.','G','G','G','R','G','G','R','G','G','G','.','.','.'},
        {'.','.','G','G','G','G','R','R','R','R','G','G','G','G','.','.'},
        {'.','.','O','O','G','R','O','R','R','O','R','G','O','O','.','.'},
        {'.','.','O','O','O','R','R','R','R','R','R','O','O','O','.','.'},
        {'.','.','O','O','R','R','R','R','R','R','R','R','O','O','.','.'},
        {'.','.','.','.','R','R','R','.','.','R','R','R','.','.','.','.'},
        {'.','.','.','G','G','G','.','.','.','.','G','G','G','.','.','.'},
        {'.','.','G','G','G','G','.','.','.','.','G','G','G','G','.','.'},
    };
    
    public static readonly string[] SmallMarioWalk0Right =
    {
        ".....RRRRR......",
        "....RRRRRRRRR...",
        "....GGGOOGO.....",
        "...GOGOOOGOOO...",
        "...GOGGOOOGOOO..",
        "...GGOOOOGGGG...",
        ".....OOOOOOO....",
        "..GGGGRRGG......",
        "OOGGGGRRRGGGOOO.",
        "OOO.GGRORRRGGOO.",
        "OO..RRRRRRR..G..",
        "...RRRRRRRRRGG..",
        "..RRRRRRRRRRGG..",
        ".GGRRR...RRRGG..",
        ".GGG............",
        "..GGG...........",
    };

    public static readonly string[] SmallMarioWalk1Right =
    {
        ".....RRRRR......",
        "....RRRRRRRRR...",
        "....GGGOOGO.....",
        "...GOGOOOGOOO...",
        "...GOGGOOOGOOO..",
        "...GGOOOOGGGG...",
        ".....OOOOOOO....",
        "....GGRGGG......",
        "...GGGGRRGG.....",
        "...GGGRRORRO....",
        "...GGGGRRRRR....",
        "...RGGOOORRR....",
        "....RGOORRR.....",
        ".....RRRGGG.....",
        ".....GGGGGGG....",
        ".....GGGG.......",
    };

    public static readonly string[] SmallMarioWalk2Right =
    {
        "................",
        "....RRRRR.......",
        "...RRRRRRRRR....",
        "...GGGOOGO......",
        "..GOGOOOGOOO....",
        "..GOGGOOOGOOO...",
        "..GGOOOOGGGG....",
        "....OOOOOOO.....",
        "...GGGGRG.O.....",
        "..OGGGGGGOOO....",
        ".OORGGGGGOO.....",
        ".GGRRRRRRR......",
        ".GRRRRRRRR......",
        "GGRRR.RRR.......",
        "G....GGG........",
        ".....GGGG.......",
    };

    public static readonly string[] SmallMarioWalk0Left = MirrorHorizontally(SmallMarioWalk0Right);
    public static readonly string[] SmallMarioWalk1Left = MirrorHorizontally(SmallMarioWalk1Right);
    public static readonly string[] SmallMarioWalk2Left = MirrorHorizontally(SmallMarioWalk2Right);
    
    public static string[] MirrorHorizontally(string[] sprite)
    {
        var result = new string[sprite.Length];
        for (int i = 0; i < sprite.Length; i++)
        {
            char[] arr = sprite[i].ToCharArray();
            Array.Reverse(arr);
            result[i] = new string(arr);
        }
        return result;
    }
    
    
}