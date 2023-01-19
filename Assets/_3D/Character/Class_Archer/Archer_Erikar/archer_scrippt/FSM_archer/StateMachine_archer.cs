public class StateMachine_archer
{
    public State_archer currentState;

    public void Initialize(State_archer startingState)
    {
        currentState = startingState;
        startingState.Enter();
    }

    public void ChangeState(State_archer newState)
    {
        currentState.Exit();

        currentState = newState;
        newState.Enter();
    }

    
}
