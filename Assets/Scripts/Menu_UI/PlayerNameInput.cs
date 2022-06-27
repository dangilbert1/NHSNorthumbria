using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerNameInput : MonoBehaviour
{

   
    public static string playerName;
    public TMP_InputField user_InputField;
    public TextMeshProUGUI user_name;
    public GameObject nullName;
    public GameObject button;
    public GameObject NameEnterUI;



    
    public void setName()
    {   if (user_InputField.text == "")
        {
            NameEnterUI.SetActive(false);
            nullName.SetActive (true);
            return;
        }

         else
        {
            nullName.SetActive(false);
            button.SetActive(false);

            user_name.text = user_InputField.text;
            playerName = user_name.text;
            user_name.text = user_name.text;

            SceneManager.LoadScene("Hospital_Enviroment");

        }
       

       
    }
}
