using UnityEngine;

public class StateController : MonoBehaviour
{

    public State currentState;

    [HideInInspector] public float stateTimeElapsed;

    void Start()
    {
        if(currentState != null)
        {
            currentState.StartState(this);
        }
    }


    void Update()
    {
        currentState.UpdateState(this);
    }

    void OnDrawGizmos()
    { 
    }

    public void TransitionToState(State nextState)
    {
        if (nextState != null)
        {
            OnExitState();
            Debug.Log("Transitioning from " + currentState.name + " to " + nextState.name);
            currentState = nextState;
            currentState.StartState(this);
        }
    }


    private void OnExitState()
    {
        currentState.ExitState(this);
        stateTimeElapsed = 0;
    } 
}