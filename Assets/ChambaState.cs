using UnityEngine;

public abstract class ChambaState
{
    public virtual void EnterState(StateMachineChamba stateMachine) { }

    public virtual void ExitState(StateMachineChamba stateMachine) { }

    public virtual void UpdateState(StateMachineChamba stateMachine) { }
}
