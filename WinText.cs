using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class WinText : MonoBehaviour
{
    public string[] text;
    public Text wintext;
    public float numberOfStrings = 4f; 
    private void Awake()
    {
        float x = Random.Range(0f, numberOfStrings);

        int index = Mathf.RoundToInt(x);

        string currentText = text[index];
        wintext.text = currentText; 
    }
}
