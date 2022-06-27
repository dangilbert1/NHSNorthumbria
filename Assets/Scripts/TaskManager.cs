using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SWS;

public class TaskManager : MonoBehaviour
{
    public  GameObject character;
    public DialogueManager dialogueManager;
   
    private Animator anim;
    //private splineMove charMove;
    private navMove charNavMove;
    [SerializeField] private bool canWalk;
    private bool dialogueBoxAnim;
    void Start()
    {

          
        anim = character.GetComponent<Animator>();
        //charMove = character.GetComponent<splineMove>();
        charNavMove = character.GetComponent<navMove>();
        canWalk = false;
      
    }

    // Update is called once per frame
    void Update()
    {
        if (canWalk)
        {
            CharacterWalk();
        }

        else if (!canWalk)
        {
            CharacterPause();
        }

        

        if (dialogueBoxAnim)
        {
            dialogueManager.animator.SetBool("IsOpen", true);
        }

        else if (!dialogueBoxAnim)
        {
            dialogueManager.animator.SetBool("IsOpen", false);
        }
    }

    public void CanWalk()
    {
        canWalk = !canWalk; 
    }
    
    public void DialogueAnim()
    {
        dialogueBoxAnim = !dialogueBoxAnim ;
    }


    private void CharacterPause()
    { 
        anim.SetBool("isWalking", false);
        //charMove.Pause();
        charNavMove.Pause();

       /* wait();*/ // temp
    }
    private void CharacterWalk()
    {
        anim.SetBool("isWalking", true);
        //charMove.Resume();
        charNavMove.Resume();
    }
    public void startDialogue()
    {
        //dialogueManager.DisplayNextSentence();
    }

 

    IEnumerator tempWait()     // in here temp to simulate time for ui to pop up 
    {
        yield return new WaitForSeconds(5);
       
    }


}
