using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using ScriptableObjectArchitecture;

public class PseudoGameManager : MonoBehaviour
{

    [SerializeField]
    IntGameEvent glowButton;

    [SerializeField]
    List<int> buttonOrder;

    [SerializeField]
    IntReference buttonCount;

    [SerializeField]
    BoolGameEvent showSequenceEvent;

    private int expectedButtonIndex;

    private void Start()
    {

        buttonOrder = new List<int>();

        addButtonToOrder();
        StartCoroutine(showOrder());

    }

    void addButtonToOrder()
    {
        int n = Random.Range(0, buttonCount.Value);
        buttonOrder.Add(n);
    }

    IEnumerator showOrder()
    {
        showSequenceEvent.Raise(false);

        yield return new WaitForSeconds(1f);
        foreach (int n in buttonOrder)
        {
            glowButton.Raise(n);
            yield return new WaitForSeconds(1f);
        }
        expectedButtonIndex = 0;

        showSequenceEvent.Raise(true);
    }

    public void buttonPressed(int n)
    {
        
        if (n == buttonOrder[expectedButtonIndex])
        {
            expectedButtonIndex++;

            if (expectedButtonIndex >= buttonOrder.Count)
            {
                addButtonToOrder();
                StartCoroutine(showOrder());

            }
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
