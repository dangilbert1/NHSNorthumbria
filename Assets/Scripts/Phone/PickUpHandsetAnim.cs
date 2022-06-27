using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHandsetAnim : MonoBehaviour
{
    private Animator anim;
    public GameObject digiDisplayOff;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void PickUpPhoneHandset()
    {
        anim.SetBool("PickUpPhone", true);
        anim.SetBool("PutDownPhone", false);

        digiDisplayOff.SetActive(false);
    }

    public void PutDownPhoneHandset()
    {
        anim.SetBool("PickUpPhone", false);
        anim.SetBool("PutDownPhone", true);
    }
}
