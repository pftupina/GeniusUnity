using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ScriptableObjectArchitecture;
using System;
using UnityEngine.Events;

public class GameButton : MonoBehaviour
{

    [Header("Data")]
    [SerializeField]
    int buttonId;

    [SerializeField]
    Color mainColor;

    [SerializeField]
    Color highlightColor;

    [Header("Events")]
    [SerializeField]
    IntGameEvent buttonPressedEvent;

    [SerializeField]
    UnityEvent onGlow;


    [Header("Component references")]
    [SerializeField]
    Button buttonComponent;


    private void OnValidate()
    {
        buttonComponent.image.color = mainColor;
    }

    public void buttonPressed()
    {
        buttonPressedEvent.Raise(buttonId);
    }

    public void checkId(int id)
    {
        if (id == buttonId)
        {
            onGlow.Invoke();
        }
    }

    public void glow()
    {
        _ = StartCoroutine(color(buttonComponent));
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


