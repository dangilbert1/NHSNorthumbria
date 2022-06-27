using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class QuizManagerExtuinguishers : MonoBehaviour
{

    public List<QuestionsAndAnswersExtuinguishers> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public int QuestionNumber;
    public Text QuestionTxt;
    public Text Scoretext;
    private int totalQuestions = 0;
    public int score;
    public bool correctAnswer;

    public GameObject Quizpanel;
    public GameObject GoPanel;
    public GameObject WinPanel;
    public DisableButtonsExtuinguishers disableButtons;

    private void Start()
    {
        totalQuestions = QnA.Count;
        GoPanel.SetActive(false);
        generateQuestion();
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        disableButtons.resetButtons();
    }

    public void GameOver()
    {
        Quizpanel.SetActive(false);
        GoPanel.SetActive(true);
        Scoretext.text = score + "/" + totalQuestions;
    }
    
    public void correct()
    {
        correctAnswer = true;
        score += 1;
        QnA.RemoveAt(currentQuestion);
        //generateQuestion();
        StartCoroutine(generateNewQuestionDelay());

    }

    public void wrong()
    {
        correctAnswer = false;
        QnA.RemoveAt(currentQuestion);
        //generateQuestion();
        StartCoroutine(generateNewQuestionDelay());
    }
    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScriptExtuinguishers>().startColour;
            options[i].GetComponent<AnswerScriptExtuinguishers>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
            

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScriptExtuinguishers>().isCorrect = true ;
            }
        }
    }

    IEnumerator generateNewQuestionDelay()
    {       
        yield return new WaitForSeconds(2);
        generateQuestion();

    }

    void generateQuestion()
    {
        disableButtons.resetButtons();

        if (score < 3)
        {
            if (QnA.Count > 0)
            {
                currentQuestion = Random.Range(0, QnA.Count);
                QuestionNumber = currentQuestion +1 ;         // question number being asked
                Debug.Log(QuestionNumber);
                QuestionTxt.text = QnA[currentQuestion].Question;
                SetAnswers();
            }

            else
            {
                Debug.Log("Out Of Questions");
                GameOver();
            }

        }

        else if (score >= 3)
        {
            WinPanel.SetActive(true);
            Quizpanel.SetActive(false);
            GoPanel.SetActive(false);
        }
        
        

        
    }

    
}
