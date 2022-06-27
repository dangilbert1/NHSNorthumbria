using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnterOfficeTrigger : MonoBehaviour
{
     
   
    public GameObject  fireWardUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if ( col.tag == "Player")
        {

            fireWardUI.SetActive(true);
        

        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            Destroy(gameObject);

        }
    }
}
