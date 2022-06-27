using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameras : MonoBehaviour
{
    public GameObject PlayerCam;
    public GameObject PhoneCam;
    void Start()
    {
        PlayerCam.SetActive(true);
        PhoneCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerCamActive()
    {
        PlayerCam.SetActive(true);
        PhoneCam.SetActive(false);
    }

    public void PhoneCamActive()
    {
        PlayerCam.SetActive(false);
        PhoneCam.SetActive(true);
    }


}

