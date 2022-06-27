using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Not currently used in Project 09/06/22 DG
/// </summary>

public class PlayerPreferences : MonoBehaviour

{

    public static string MyPlayerName;
    void Awake()
    {
        Debug.Log(MyPlayerName);
        GameObject[] objs = GameObject.FindGameObjectsWithTag("PlayerPrefs");
        

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);


       
    }
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
