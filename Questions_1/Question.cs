using System.Text.Json.Serialization;

namespace Questions_1;

[Serializable]
public class Question
{
    [JsonPropertyName("id")]
    public int Id { get; private set; }
    
    [JsonPropertyName("difficulty")]
    public string Difficulty {get; private set; }
    
    [JsonPropertyName("question")]
    public string Quest {get; private set; }

    [JsonPropertyName("answers")] 
    public List<Answer> Answers { get; private set; } = new();
    
    [JsonConstructor]
    public Question(int id, string difficulty, string quest, List<Answer> answers)
    {
        Id = id;
        Difficulty = difficulty;
        Quest = quest;
        Answers = answers;
    }
}