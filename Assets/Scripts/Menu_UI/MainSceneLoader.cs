using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneLoader : MonoBehaviour
{
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMainScene_Delayed()
    {
        StartCoroutine(delay());
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene("Hospital_Enviroment");
    }

    IEnumerator delay()
    {
         yield return new WaitForSeconds(3);
        LoadMainScene();

    }
}
