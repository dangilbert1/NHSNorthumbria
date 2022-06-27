using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneTaskTrigger : MonoBehaviour
{
    public GameObject PhoneUI;
    public SwitchCameras switchCam;
    public CameraFade_UI camFade;
    public PlayerEnterTrigger playerEnterTrigg;
    public DigitalDisplay phoneNumbersInput;
    public GameObject playerFollowUI;
       

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (phoneNumbersInput.codeSequence == "999")
        {
            StartCoroutine(returnToPLayerCam());
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if ( col.tag == "Player")
        {          
            camFade.fadeInout();           
            StartCoroutine(camswitchdelay());
            playerEnterTrigg.enabled = false;  // turn of the FM dialoughe UI
            playerFollowUI.SetActive(false);
        }
    }

    IEnumerator camswitchdelay()
    {
        yield return new WaitForSeconds(3);
        switchCam.PhoneCamActive();
        PhoneUI.SetActive(true);
    }

    IEnumerator returnToPLayerCam()
    {
        yield return new WaitForSeconds(5);
        switchCam.PlayerCamActive();
        PhoneUI.SetActive(false);
        camFade.fadeInout();
        playerFollowUI.SetActive(true);
    }


}
