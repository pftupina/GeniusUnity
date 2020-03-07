using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ScriptableObjectArchitecture;
using System;

public class GameButton : MonoBehaviour
{
    [SerializeField]
    Button button;

    [SerializeField]
    Color mainColor;


    [SerializeField]
    Color highlightColor;

    private void Start()
    {
        button.image.color = mainColor;   
    }


    public void glow()
    {
        StartCoroutine(color(button));
    }

    IEnumerator color(Button button)
    {

        button.image.color = mainColor;
        yield return new WaitForSeconds(0.3f);
        button.image.color = highlightColor;
        yield return new WaitForSeconds(0.3f);
        button.image.color = mainColor;

    }
}


