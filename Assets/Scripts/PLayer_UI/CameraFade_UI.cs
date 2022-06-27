using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFade_UI : MonoBehaviour
{
    public GameObject camFadeUi;
    private CanvasGroup canvGroup;
    public float Duration;
    public bool isFaded;
    public SwitchCameras switchCamera;

    // Start is called before the first frame update
    void Start()
    {
         canvGroup = camFadeUi.GetComponent<CanvasGroup>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeOut()
    {
        StartCoroutine(DoFadeOut(canvGroup, 1.0f , 0));
        Debug.Log(" Fade Black Out");
    }

    public void FadeIn()
    {
        camFadeUi.SetActive(true);
        StartCoroutine(delayActivate());
  
        Debug.Log(" Fade Black In ");

    }

    public void fadeInout()
    {
        StartCoroutine(FadeinandOut());
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

        StartCoroutine(delayDeActivate());
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

    IEnumerator delayActivate()
    {
       
        yield return new WaitForSeconds(1);  // small delay after UI object active
        
        StartCoroutine(DoFadeIn(canvGroup, 0, 1.0f));


    }
    IEnumerator delayDeActivate()
    {

        yield return new WaitForSeconds(1);  // small delay after UI object active
        camFadeUi.SetActive(false);


    }

    IEnumerator FadeinandOut()
    {
        FadeIn();
        yield return new WaitForSeconds(5);  // small delay after UI object active
        FadeOut();
        camFadeUi.SetActive(false);


    }
}


