using UnityEngine;

public class ChambaStateReturn : ChambaState
{
    public override void EnterState(StateMachineChamba stateMachine)
    {
        stateMachine.StartCoroutine(stateMachine.ChangeClothes(stateMachine.clothes[1]));
        stateMachine.agent.SetDestination(stateMachine.home.position);
    }

    public override void ExitState(StateMachineChamba stateMachine)
    {
        
    }

    public override void UpdateState(StateMachineChamba stateMachine)
    {
        if (!stateMachine.Changing)
        {
            stateMachine.agent.speed = 2.5f;
        }
        else
        {
            stateMachine.agent.speed = 0;
        }

        if (Vector3.Distance(stateMachine.transform.position, stateMachine.home.position) < 0.05f)
        {
            stateMachine.ChangeState(stateMachine.stateGo);
        }
    }
}
