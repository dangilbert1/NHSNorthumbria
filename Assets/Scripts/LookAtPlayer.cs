using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform target;
    public Transform looker;
    private bool canLook;
    private float turnSpeed;
  
    void Start()
    {
        turnSpeed = 0.2f;
        lookAtPLayer();
    }

    // Update is called once per frame
    void Update()
    {  if ( canLook)
        {

            turnSpeed = 2.5f;
            Vector3 targetPos = new Vector3(target.position.x, target.position.y, target.position.z);
            Vector3 dir = targetPos - looker.transform.position;
            dir.y = 0;                                                 // keep the direction strictly horizontal
            Quaternion rot = Quaternion.LookRotation(dir);
            looker.transform.rotation = Quaternion.Slerp(looker.transform.rotation, rot, turnSpeed * Time.deltaTime);  // slerp to the desired rotation over time

        }

    }

    public void lookAtPLayer()
    {
        canLook = true;
    }
    public void NolookAtPLayer()
    {
        canLook = false;
    }
}
