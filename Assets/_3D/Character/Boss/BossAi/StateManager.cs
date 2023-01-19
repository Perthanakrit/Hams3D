using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    State_Boss currentState;
    // Start is called before the first frame update
    private void SwitchToTheNextState(State_Boss nextState)
    {
        currentState = nextState;
    }
}
