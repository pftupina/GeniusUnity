using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "GameStateMachine/Actions/DirectTransition")]
public class DirectTransitionAction : Action
{
    [SerializeField]
    State NextState;

    public override void Act(StateController controller)
    {
        DoTransition(controller);
    }

    private void DoTransition(StateController controller)
    {
        controller.TransitionToState(NextState);
    }
}
