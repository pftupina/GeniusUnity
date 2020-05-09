using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
using UnityEngine.Events;

public class FadeController : MonoBehaviour
{
    [Header("On Start")]
    [SerializeField]
    UnityEvent fadeInStart;

    [SerializeField]
    UnityEvent fadeOutStart;


    [Header("On End")]
    [SerializeField]
    UnityEvent fadeInComplete;

    [SerializeField]
    UnityEvent fadeOutComplete;

    public void startFadeIn()
    {
        fadeInStart.Invoke();
    }

    public void startFadeOut()
    {
        fadeOutStart.Invoke();
    }

    public void onFadeInComplete()
    {
        fadeInComplete.Invoke();
    }


    public void onFadeOutComplete()
    {
        fadeOutComplete.Invoke();
    }

}
