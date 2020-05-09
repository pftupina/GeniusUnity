using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class ButtonSoundPlayer : MonoBehaviour
{
    [SerializeField]
    AudioClipCollection ButtonSound;

    [SerializeField]
    AudioSource Source;

    public void playSound(int i)
    {
        if(ButtonSound[i] != null)
        {
            Source.PlayOneShot(ButtonSound[i]);
        }
    }
}
