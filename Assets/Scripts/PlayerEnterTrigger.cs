using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///  Tasks that happen when player enters trigger on FireWardens Waypoints
///  DG
/// </summary>

public class PlayerEnterTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public TaskManager taskManager;
    public Timer timer;
    public GameObject PlayerFollowPrompt;


    public List<GameObject> waypointColliders = new List<GameObject>();
   


    // player
    public EnableCameraMovement enableCameraMovement;
    public GameObject DialogueBoxPlayer;
    private Animator playerPromptUIanim;   // player prompt text
    public bool playerHasEnteredTrigger;
    void Start()
    {
        playerPromptUIanim = DialogueBoxPlayer.GetComponent<Animator>();
        foreach (GameObject col in GameObject.FindGameObjectsWithTag("WaypointCollider"))
        {
            waypointColliders.Add(col);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            PlayerFollowPrompt.SetActive(false);
            dialogueManager.DisplayNextSentence();             
            taskManager.DialogueAnim();
            enableCameraMovement.disableCamMove();   // disables player control
            //enableCameraMovement.cursorCanLock = true ;  // lock cursor to center screen
            playerPromptUIanim.SetBool("IsOpen", false);  //  closes Player prompt UI
            timer.StopTimer();
            
            int colliderCount = waypointColliders.Count;
            Debug.Log(colliderCount);

            playerHasEnteredTrigger = true;   // bool to check for FM animation transition  
            
        }
    }


    private void OnTriggerExit(Collider col)
    {

        if (col.tag == "Player")
        {

            timer.resetTimer();
            Destroy(gameObject);
        }
    }
}

