using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleUI_Fade : MonoBehaviour
{
    private CanvasGroup canvGroup;
    public float Duration;
    void Start()
    {
        canvGroup = GetComponent<CanvasGroup>();
        Duration = 4f;
        FadeOut();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeOut()
    {
        StartCoroutine(DoFadeOut(canvGroup, 1.0f, 0));
        Debug.Log(" Fade Black Out");
    }

    public void FadeIn()
    {
        StartCoroutine(DoFadeOut(canvGroup, 0, 1.0f));
        Debug.Log(" Fade Black Out");

        Debug.Log(" Fade Black In ");

    }

    public IEnumerator DoFadeOut(CanvasGroup canvGroup, float start, float end)//Runto complition beforex
    {


        float counter = 0f;

        while (counter < Duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / Duration);

            yield return null; //Because we don't need a return value.
        }

        Destroy(gameObject);

       
    }
    public IEnumerator DoFadeIn(CanvasGroup canvGroup, float start, float end)//Runto complition beforex
    {


        float counter = 0f;

        while (counter < Duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / Duration);

            yield return null; //Because we don't need a return value.
        }
    }
}
