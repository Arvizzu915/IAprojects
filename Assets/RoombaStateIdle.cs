using UnityEngine;

public class RoombaStateIdle : RombaState
{
    public override void EnterState(RoombaStateMachine stateMachine)
    {
        Debug.Log("durando en la chamba");
        stateMachine.agent.speed = 0.0f;
    }

    public override void ExitState(RoombaStateMachine stateMachine)
    {
        Debug.Log("MOMENTOOO");
    }

    public override void UpdateState(RoombaStateMachine stateMachine)
    {
        if (stateMachine.trash)
        {
            stateMachine.ChangeState(stateMachine.stateClean);
        }
    }
}
