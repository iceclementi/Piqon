public abstract class Question
{
    public string sectionId;
    public int id;

    public Question(string sectionId, int id)
    {
        this.sectionId = sectionId;
        this.id = id;
    }

    private string question;
    private Answer answer;

    public string GetQuestion()
    {
        return question;
    }

    public Answer GetAnswer()
    {
        return answer;
    }

    protected void SetQuestion(string questionToSet)
    {
        question = questionToSet;
    }
    
    protected void SetAnswer(Answer questionToSet)
    {
        answer = questionToSet;
    }

    public abstract void CreateNewQuestion();
}
