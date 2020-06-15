using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;


[CreateAssetMenu(menuName = "GameStateMachine/Decision/BoolChecklist")]
public class ChecklistDecision : Decision
{

    [SerializeField]
    BoolReference[] bools;

    public override bool Decide(StateController controller)
    {
        return CheckList();
    }

    private bool CheckList()
    {
        for (int i = 0; i < bools.Length; i++)
        {
            if (bools[i].Value == false)
            {
                return false;
            }
        }

        return true;
    }
}
