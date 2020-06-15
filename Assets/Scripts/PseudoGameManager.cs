using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using ScriptableObjectArchitecture;
using UnityEngine.Events;

public class PseudoGameManager : MonoBehaviour
{

    [SerializeField]
    IntGameEvent glowButton;

    [SerializeField]
    IntReference buttonCount;

    [SerializeField]
    BoolReference sequenceIsShowing;

    [SerializeField]
    UnityEvent onSuccess;

    [SerializeField]
    UnityEvent onFail;

    private int expectedButtonIndex;
    List<int> buttonOrder;

    private void Start()
    {
        buttonOrder = new List<int>();
        addButtonToOrder();
    }

    void addButtonToOrder()
    {
        int n = Random.Range(0, buttonCount.Value);
        buttonOrder.Add(n);
    }

    IEnumerator showOrder()
    {
        sequenceIsShowing.Value = true;

        yield return new WaitForSeconds(1f);
        foreach (int n in buttonOrder)
        {
            glowButton.Raise(n);
            yield return new WaitForSeconds(1f);
        }
        expectedButtonIndex = 0;

        sequenceIsShowing.Value = false;
    }

    public void ShowSequence()
    {
        StartCoroutine(showOrder());
    }

    public void buttonPressed(int n)
    {
        Debug.Log(n.ToString());
        
        if (n == buttonOrder[expectedButtonIndex])
        {
            expectedButtonIndex++;

            if (expectedButtonIndex >= buttonOrder.Count)
            {
                onSuccess.Invoke();
                addButtonToOrder();
                StartCoroutine(showOrder());

            }
        }
        else
        {
            onFail.Invoke();
        }
    }

}
