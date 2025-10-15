using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;

public class ChambaStateGo : ChambaState
{
    public override void EnterState(StateMachineChamba stateMachine) 
    {
        stateMachine.StartCoroutine(stateMachine.ChangeClothes(stateMachine.clothes[1]));
        Debug.Log("Ya a la chamba :c");
        stateMachine.agent.SetDestination(stateMachine.workplace.position);
    }

    public override void ExitState(StateMachineChamba stateMachine) 
    {
        
    }

    public override void UpdateState(StateMachineChamba stateMachine) 
    {
        if (!stateMachine.Changing)
        {
            stateMachine.agent.speed = 3;
        }
        else
        {
            stateMachine.agent.speed = 0;
        }

        if (Vector3.Distance(stateMachine.transform.position, stateMachine.workplace.position) < 0.1f)
        {
            Debug.Log("cambiar");
            stateMachine.ChangeState(stateMachine.stateWork);
        }
    }
}
