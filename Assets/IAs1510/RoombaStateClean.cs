using UnityEngine;

public class RoombaStateClean : RombaState
{
    public override void EnterState(RoombaStateMachine stateMachine)
    {
        stateMachine.agent.speed = 5f;
    }

    public override void ExitState(RoombaStateMachine stateMachine)
    {
    }

    public override void UpdateState(RoombaStateMachine stateMachine)
    {
        if (stateMachine.charge <= 0)
        {
            stateMachine.ChangeState(stateMachine.stateRecharge);
        }

        stateMachine.agent.SetDestination(stateMachine.trashInWorld[0].transform.position);
    }
}
