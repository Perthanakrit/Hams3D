public class StateMachine_Warrior
{
    public State_Warrior currentState;

    public void Initialize(State_Warrior startingState)
    {
        currentState = startingState;
        startingState.Enter();
    }

    public void ChangeState(State_Warrior newState)
    {
        currentState.Exit();

        currentState = newState;
        newState.Enter();
    }

    
}
