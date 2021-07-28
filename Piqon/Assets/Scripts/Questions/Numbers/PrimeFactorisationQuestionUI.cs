using TMPro;
using UnityEngine;

public class PrimeFactorisationQuestionUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private TextMeshProUGUI answerText;
    
    public PrimeFactorisationQuestion question = new PrimeFactorisationQuestion();
    
    private void Start()
    {
        questionText.text = question.GetQuestion();
        answerText.text = question.GetAnswer().GetAnswer();
    }

    public void RefreshQuestion()
    {
        question.CreateNewQuestion();
        questionText.text = question.GetQuestion();
        answerText.text = question.GetAnswer().GetAnswer();
    }
}
