using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/// <summary>
///  setting the PLayer personal name from PLayerNameInput main menu 
/// </summary>
public class PlayerNameText : MonoBehaviour

{
    public  GameObject UInurseCanvas;
    public  GameObject helloText;
    private TextMeshProUGUI myPlayerName;
    public  GameObject PlayerNameUI;
    public  GameObject dialogue_Welcome;
    public  GameObject dialogueIntroFM;
    private TextMeshProUGUI FMintroText;
 
    public GameObject nurseDialogue;
    private Animator anim;
    public EnableCameraMovement EnableCamMove;



    // Use this for initialization
    void Start()
    {

        myPlayerName = PlayerNameUI.GetComponent<TextMeshProUGUI>();
        myPlayerName.text =  PlayerNameInput.playerName ;

        FMintroText = dialogueIntroFM.GetComponent<TextMeshProUGUI>();

        anim = nurseDialogue.GetComponent<Animator>();

        
        StartCoroutine(UIanimWait());
    }

    // Update is called once per frame
    void Update()
    {

    }
    void UIAnim()
    {
        anim.SetBool("IsOpen", true);
        StartCoroutine(WelcomeWait());
    }

    IEnumerator UIanimWait()
    {
        yield return new WaitForSeconds(2);
        UIAnim();
    }

    IEnumerator WelcomeWait()
    {
        yield return new WaitForSeconds(4);
        welcomeIntro();
    }
    private void welcomeIntro()
    {       
        dialogue_Welcome.SetActive(true);
        helloText.SetActive(false);
        StartCoroutine(FMWait());
    }
    IEnumerator FMWait()
    {
        yield return new WaitForSeconds(4);
        dialogueIntroFM.SetActive(true);
        dialogue_Welcome.SetActive(false);

        yield return new WaitForSeconds(4);
        FMintroText.text = "The Firewarden will guide you through the training." ;

        yield return new WaitForSeconds(4);
        FMintroText.text = " Please continue.";

        yield return new WaitForSeconds(4);

        UInurseCanvas.SetActive(false);
        EnableCamMove.RestoreCameraControl();

        //StartButton.SetActive(true);
    }
   
    private void FireMashallIntro()
    {
        dialogueIntroFM.SetActive(true);
        dialogue_Welcome.SetActive(false);
    }
}

