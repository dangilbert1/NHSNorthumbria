using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DigitalDisplay : MonoBehaviour
{
    [SerializeField]
    private Sprite[] digits;

    [SerializeField]
    private Image[] characters;
    public string codeSequence;

    public TextMeshProUGUI phoneText;
    void Start()
    {
        codeSequence = "";

        for ( int i = 0;  i <= characters.Length -1; i++)
        {
            characters[i].sprite = digits[10];
        }

        PushTheButton.ButtonPressed += AddDigitToCodeSequence;
    }

    private void AddDigitToCodeSequence ( string digitEntered)
    {
        if (codeSequence.Length < 3)
        {
            switch (digitEntered)
            {
                case "Zero":
                    codeSequence += "0";
                    DisplayCodeSequence(0);
                    break;

                case "One":
                    codeSequence += "1";
                    DisplayCodeSequence(1);
                    break;

                case "Two":
                    codeSequence += "2";
                    DisplayCodeSequence(2);
                    break;

                case "Three":
                    codeSequence += "3";
                    DisplayCodeSequence(3);
                    break;

                case "Four":
                    codeSequence += "4";
                    DisplayCodeSequence(4);
                    break;

                case "Five":
                    codeSequence += "5";
                    DisplayCodeSequence(5);
                    break;

                case "Six":
                    codeSequence += "6";
                    DisplayCodeSequence(6);
                    break;

                case "Seven":
                    codeSequence += "7";
                    DisplayCodeSequence(7);
                    break;

                case "Eight":
                    codeSequence += "8";
                    DisplayCodeSequence(8);
                    break;

                case "Nine":
                    codeSequence += "9";
                    DisplayCodeSequence(9);
                    break;
            }

        }


            switch (digitEntered)
            {
                case "Star":
                    ResetDisplay();
                    break;

                case "Hash":
                    if ( codeSequence.Length > 0)
                    {
                        //CheckResults();
                    }
                    break;
            }
        }

        

    

    private void DisplayCodeSequence(int digitJustEntered)
    {
        switch (codeSequence.Length)
        {
            case 1:
                characters[0].sprite = digits[10];
                characters[1].sprite = digits[10];
                characters[2].sprite = digits[10];
                characters[3].sprite = digits[digitJustEntered];
                break;

            case 2:
                characters[0].sprite = digits[10];
                characters[1].sprite = digits[10];
                characters[2].sprite = characters[3].sprite;
                characters[3].sprite = digits[digitJustEntered];
                break;

            case 3:
                characters[0].sprite = digits[10];
                characters[1].sprite = characters[2].sprite;
                characters[2].sprite = characters[3].sprite;
                characters[3].sprite = digits[digitJustEntered];
                break;

            //case 4:
            //    characters[0].sprite = characters[1].sprite;
            //    characters[1].sprite = characters[2].sprite;
            //    characters[2].sprite = characters[3].sprite;
            //    characters[3].sprite = digits[digitJustEntered];
            //    break;
        }
    }

    private void CheckResults()
    {
        if ( codeSequence == "999"  )     
        {
            phoneText.text = "   Calling the emergency services ";
            Debug.Log(" Calling Fireman Sam .....");
        }

        else
        {
            phoneText.text = "   Incorrect number for any assistance... ";
            ResetDisplay();
        }
    }

    private void ResetDisplay()
    {

        for (int i = 0; i <= characters.Length - 1; i++)
        {
            characters[i].sprite = digits[10];
        }
        codeSequence = "";
    }

    private void OnDestroy()
    {
        PushTheButton.ButtonPressed -= AddDigitToCodeSequence;
    }

    private void Update()
    {
        if (codeSequence.Length >=  3)
        {
            StartCoroutine(delay());    // delay to before checkingand reseting 
            Debug.Log(codeSequence);
        }
    }

    IEnumerator delay()
    {
         yield return new WaitForSeconds(1.5f);
        CheckResults();
        //ResetDisplay();
    }


}
