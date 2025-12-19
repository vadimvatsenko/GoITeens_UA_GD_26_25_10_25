using System.Text.Json.Serialization;

namespace Questions_1;

[Serializable]
public class Student
{
    [JsonPropertyName("firstName")]
    public string FirstName {get; private set; }
    
    [JsonPropertyName("lastName")]
    public string SecondName {get; private set; }
    
    [JsonConstructor]
    public Student(string firstName, string secondName)
    {
        FirstName = firstName;
        SecondName = secondName;
    }
}