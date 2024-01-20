using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public int count = 0;
    public TMP_Text counterText;
    
    public void Add() { count++; UpdateText(); }

    public void Subtract() { count--; UpdateText(); }

    private void UpdateText()
    {
        counterText.text = count.ToString();
    }
}
