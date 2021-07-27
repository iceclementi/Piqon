using UnityEngine;

public class Answer
{
    private readonly string answer;

    public Answer(string answer)
    {
        this.answer = answer;
    }

    public string GetAnswer()
    {
        return answer;
    }
}
