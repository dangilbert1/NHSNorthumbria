using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPromptsTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<PlayerPromptsManager>().StartDialogue(dialogue);
    }
}
