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
    BoolReference buttonsEnabled;

    [Header("Events")]
    [SerializeField]
    IntGameEvent buttonPressedEvent;

    [SerializeField]
    UnityEvent onGlow;

    [Header("Component references")]
    [SerializeField]
    Button buttonComponent;

    public void Update()
    {
        buttonComponent.interactable = buttonsEnabled.Value;
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
}


