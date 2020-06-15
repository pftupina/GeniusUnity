using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "GameStateMachine/State")]
public class State : ScriptableObject 
{
    [SerializeField]
    Action[] onStartActions;
    [SerializeField]
    Action[] onUpdateActions;
    [SerializeField]
    Action[] onExitActions;

    [SerializeField]
    Transition[] transitions;

    public Color sceneGizmoColor = Color.grey;


    public void StartState(StateController controller)
    {
        DoStartActions(controller);
    }

    public void UpdateState(StateController controller)
    {
        DoUpdateActions (controller);
        CheckTransitions (controller);
    }


    public void ExitState(StateController controller)
    {
        DoExitActions(controller);
    }


    private void DoStartActions(StateController controller)
    {
        for (int i = 0; i < onStartActions.Length; i++) {
            onStartActions[i].Act (controller);
            Debug.Log("Action for starting " + controller.currentState.name);
        }
    }

    private void DoUpdateActions(StateController controller)
    {
        for (int i = 0; i < onUpdateActions.Length; i++)
        {
            onUpdateActions[i].Act(controller);
        }
    }

    private void DoExitActions(StateController controller)
    {
        for (int i = 0; i < onExitActions.Length; i++)
        {
            onExitActions[i].Act(controller);
        }
    }

    private void CheckTransitions(StateController controller)
    {
        for (int i = 0; i < transitions.Length; i++) 
        {
            bool decisionSucceeded = transitions [i].decision.Decide (controller);

            if (decisionSucceeded) {
                controller.TransitionToState (transitions [i].trueState);
            } else 
            {
                controller.TransitionToState (transitions [i].falseState);
            }
        }
    }


}