using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class PlayerFollowWarning : MonoBehaviour
{
    public GameObject followPromptText;
    private bool blinker;
    public float blinkspeed = 0.25f;
    public TextMeshProUGUI textToFade;

    void Start()
    {
        StartCoroutine(Blinkin());

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator Blinkin()
    {
         yield return new WaitForSeconds(blinkspeed);

        textToFade.GetComponent<TextMeshProUGUI>().DOFade(1, blinkspeed);
        StartCoroutine(Blinkout());
    }

    IEnumerator Blinkout()
    {
        yield return new WaitForSeconds(blinkspeed);

        textToFade.GetComponent<TextMeshProUGUI>().DOFade(0, blinkspeed);
        StartCoroutine(Blinkin());

    }




}
