using System.Text.Json.Serialization;

namespace Questions_1;

public class Answer
{
    [JsonPropertyName("text")]
    public string Answ {get; private set;}
    
    [JsonPropertyName("correct")]
    public bool IsCorrect {get; private set;}
    
    [JsonConstructor]
    public Answer (string answ, bool isCorrect)
    {
        Answ = answ;
        IsCorrect = isCorrect;
    }
}