using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPromptsManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Animator animator;


    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)   // Loop through Dialogue Class to find next sentence and loads them into Queue <sentences>
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0) // checking if there are any sentences left to run
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();   //  get next question in Queue
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())     // ToCharArray () converts string into character array
        {
            dialogueText.text += letter;  // appends  letter to end of string
            yield return null;    // waits one frame

        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        Debug.Log("End of Conversation");
    }
}
