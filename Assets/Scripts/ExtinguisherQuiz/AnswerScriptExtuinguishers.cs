using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScriptExtuinguishers : MonoBehaviour
{

    public bool isCorrect = false;
    public QuizManagerExtuinguishers quizManager;
    public Color startColour;

    private void Start()
    {
        startColour = GetComponent<Image>().color= Color.yellow;
    }
    public void Answer()
    {
        if (isCorrect)
        {
            GetComponent<Image>().color = Color.green;
            Debug.Log(" Correct Answer ");
            quizManager.correct();
        }

        else
        {
            GetComponent<Image>().color = Color.red;
            Debug.Log(" Wrong Answer ");
            quizManager.wrong();
        }
    }
}
