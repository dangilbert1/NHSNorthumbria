using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitThenActivate : MonoBehaviour
{
    public GameObject objectToActivate;
    public float delay;
    void Start()
    {
        StartCoroutine(wait());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator wait()
    {
 
        yield return new WaitForSeconds(delay);
        objectToActivate.SetActive(true);

    }
}
