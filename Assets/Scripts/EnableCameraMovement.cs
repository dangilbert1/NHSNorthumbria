using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCameraMovement : MonoBehaviour
{
    //[SerializeField] private bool CameraCanMove;
    
    
    public FirstPersonAIO cameraMove;
    public Transform target;
    public Transform PlayerCam;
    private bool userCameraControl; // take over control of camera for auto look at character

    public bool cursorCanLock;
    void Start()
    {

        Screen.SetResolution(1280, 720, FullScreenMode.ExclusiveFullScreen, 60);
        //CameraCanMove = cameraMove.enableCameraMovement;
        userCameraControl = true;

        disableCamMove();
    }
    // Update is called once per frame
    void Update()
    {
        if (!userCameraControl)
        {
            cameraMove.GetComponent<FirstPersonAIO>().enabled = false;

            Vector3 targetPos = new Vector3(target.position.x, target.position.y, target.position.z);
            Vector3 dir = targetPos - PlayerCam.transform.position;
            dir.y = 0;                                                 // keep the direction strictly horizontal
            Quaternion rot = Quaternion.LookRotation(dir);
            PlayerCam.transform.rotation = Quaternion.Slerp(PlayerCam.transform.rotation, rot, 2f * Time.deltaTime);  // slerp to the desired rotation over time

            if (PlayerCam.transform.rotation == rot)   // when slerp is completed
            {
                Debug.Log("  Slerp Reached target .......  ");
                cameraMove.GetComponent<FirstPersonAIO>().enabled = true;
                RestoreCameraControl();


            }


        }
        else if (userCameraControl)
        {
            cameraMove.GetComponent<FirstPersonAIO>().enabled = true;
        }

        if (cursorCanLock)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        else { Cursor.lockState = CursorLockMode.None; }

    }
    // use this simply lock player to lock player
    public void enableCamMove()      // player controls camera
    {
        cameraMove.enableCameraMovement = true;
        cameraMove.playerCanMove = true;       
    }
    public void disableCamMove()   // player cannot control camera 
    {
       cameraMove.enableCameraMovement = false;
       cameraMove.playerCanMove = false;
    }

    // use this to lock player but force to look at Character

    public void TakeOverCameraControl()  // get current pos/rot   then lerp from to look at fire warden 
    {
        userCameraControl = false; // disable user control
        disableCamMove();
       
    }
    public void RestoreCameraControl()  // get current pos/rot   then lerp from to look at fire warden 
    {
        userCameraControl = true; // enable user control
        enableCamMove();
       
    }

  
    IEnumerator delay()     // in here temp to simulate time for ui to pop up 
    {
        yield return new WaitForSeconds(5);
    }
}
