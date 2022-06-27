//////////////////////////////////////////////////
/// File: TypewriterEffect.cs
/// Author: Kyle Tugwell
/// Date created: 04/01/2022
/// Last edit: 05/01/2022
/// Description: System to make typewriter-like text.
/// Comments: https://www.youtube.com/watch?v=C5xnB1dZA_w
//////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    public float typewriterSpeed = 20f;
    public float delayBeforeText = .5f;

    public void Run(string textToType, TextMeshProUGUI textMeshProRef)
    {
        StartCoroutine(TypeText(textToType, textMeshProRef));
    }

    private IEnumerator TypeText(string textToType, TextMeshProUGUI textMeshProRef)
    {
        textMeshProRef.text = string.Empty;

        yield return new WaitForSeconds(delayBeforeText);

        float _t = 0;
        int _charIndex = 0;

        while (_charIndex < textToType.Length)
        {
            _t += Time.deltaTime * typewriterSpeed;
            _charIndex = Mathf.FloorToInt(_t);
            _charIndex = Mathf.Clamp(_charIndex, 0, textToType.Length);

            textMeshProRef.text = textToType.Substring(0, _charIndex);

            yield return null;
        }
    }
}
