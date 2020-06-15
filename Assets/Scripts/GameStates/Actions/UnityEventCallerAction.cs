using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "GameStateMachine/Actions/UnityEventCaller")]
public class UnityEventCallerAction : Action
{
    [SerializeField]
    UnityEvent EventsToCall;

    public override void Act(StateController controller)
    {
        EventsToCall.Invoke();
    }
}
