using UnityEngine;

public class RoombaStateRecharge : RombaState
{
    public override void EnterState(RoombaStateMachine stateMachine)
    {
        stateMachine.agent.speed = 2.5f;

        stateMachine.agent.SetDestination(stateMachine.chargeStation.position);
    }

    public override void ExitState(RoombaStateMachine stateMachine)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(RoombaStateMachine stateMachine)
    {
        if (Vector3.Distance(stateMachine.transform.position, stateMachine.chargeStation.position) < 0.1f)
        {
            if (stateMachine.charge < 100)
            {
                stateMachine.charge += 1;
            }
            else
            {
                stateMachine.ChangeState(stateMachine.stateIdle);
            }
        }
    }
}
