using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PseudoGameManager : MonoBehaviour
{
    [SerializeField]
    GameButton[] gameButtons;


    [SerializeField]
    List<int> buttonOrder;

    private int expectedButtonIndex;

    private void Start()
    {
        buttonOrder = new List<int>();

        addButtonToOrder();
        StartCoroutine(showOrder());

    }

    void addButtonToOrder()
    {
        int n = Random.Range(0, gameButtons.Length);
        buttonOrder.Add(n);
    }

    IEnumerator showOrder()
    {

        yield return new WaitForSeconds(1f);
        foreach (int n in buttonOrder)
        {
            gameButtons[n].glow();
            yield return new WaitForSeconds(1f);
        }
        expectedButtonIndex = 0;
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
