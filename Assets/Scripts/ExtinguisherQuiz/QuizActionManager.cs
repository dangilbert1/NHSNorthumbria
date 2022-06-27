using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizActionManager : MonoBehaviour
{
    public QuizManagerExtuinguishers quizManager;
    public int i = 0;
    public Animator anim;
    public GameObject fireWarden;
    public GameObject spray;
    public GameObject fire;
   

    float lerpDuration = 3;
    float startValue = 1f;
    float endValue = 0;
    public float flameSize;

    public GameObject WaterExtinguisher;
    public GameObject co2Extinguisher;
    public GameObject foamExtinguisher;
    public GameObject powderExtinguisher;
   

    void Start()
    {
        anim = fireWarden.GetComponent<Animator>();
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (quizManager.correctAnswer)
        {
           if ( quizManager.QuestionNumber == 1)
            {
                //  spawn firextinguisher
            }
        }
    }

    public void ButtonPress()
    {

        i++;

        i = Mathf.Min(i, 3);

        if (i == 1.0f)
        {
            anim.SetBool("Choose", true);
            anim.SetBool("pickUp", false);
            anim.SetBool("sprayLoop", false);
        }

        if (i == 2.0f)
        {
            anim.SetBool("Choose", false);
            anim.SetBool("pickUp", true);
            anim.SetBool("sprayLoop", false);
        }

        if (i == 3.0f)
        {
            anim.SetBool("Choose", false);
            anim.SetBool("pickUp", false);
            anim.SetBool("sprayLoop", true);
        }

    }

    public void Spray()
    {
        spray.SetActive(true);
        StartCoroutine(flameOut());
    }

   
    public IEnumerator flameOut()
    {

        {
            float timeElapsed = 0;
            while (timeElapsed < lerpDuration)
            {
                flameSize = Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration);
                timeElapsed += Time.deltaTime;
                yield return null;

                fire.transform.localScale = new Vector3(flameSize, flameSize, flameSize);
            }
        }


    }
}
