using UnityEngine;

public abstract class RombaState
{
    public abstract void EnterState(RoombaStateMachine stateMachine);

    public abstract void UpdateState(RoombaStateMachine stateMachine);

    public abstract void ExitState(RoombaStateMachine stateMachine);
}
