using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFireMarshallAnims : MonoBehaviour
{
    public Animator FireMarshAnim;   // FireMarshall  Animator Component

   [SerializeField]
    private bool resetAnimBools;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if ( resetAnimBools)
        {
            foreach (AnimatorControllerParameter parameter in FireMarshAnim.parameters)
            {
                if (parameter.type == AnimatorControllerParameterType.Bool)
                    FireMarshAnim.SetBool(parameter.name, false);
            }

            resetAnimBools = false;

        }
        

    }


    private void OnTriggerEnter(Collider col)
    {
        if ( col.gameObject.name == "Player_Trigger_00")
        {
            Debug.Log(" Trigger 00 ");  
            FireMarshAnim.SetBool("Male_Talking", true);  // talking
        }

       if (col.gameObject.name == "Player_Trigger_01")
        {
            Debug.Log(" Trigger 01 ");
           
            FireMarshAnim.SetBool("R_Hand_Gesture", true);

        }

         if (col.gameObject.name == "Player_Trigger_02")
        {
            Debug.Log(" Trigger 02 ");
            
            FireMarshAnim.SetBool("Male_Talking", true);
        }

        if (col.gameObject.name == "Player_Trigger_03")
        {
            Debug.Log(" Trigger 03 ");

            FireMarshAnim.SetBool("Male_Talking", true);  // talking

        }

        if (col.gameObject.name == "Player_Trigger_04")
        {
            Debug.Log(" Trigger 04 ");

            FireMarshAnim.SetBool("R_Hand_Gesture", true);  // talking

        }

        if (col.gameObject.name == "Player_Trigger_05")
        {
            Debug.Log(" Trigger 05 ");

            FireMarshAnim.SetBool("R_Hand_Gesture", true);  // talking

        }

        if (col.gameObject.name == "Player_Trigger_06")
        {
            Debug.Log(" Trigger 06 ");

            FireMarshAnim.SetBool("Male_Talking", true);  // talking

        }
    }

    public void resetBools()
    {
        resetAnimBools = true;    // set false by continue button
    }
}
