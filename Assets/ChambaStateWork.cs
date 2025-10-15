using UnityEngine;

public class ChambaStateWork : ChambaState
{
    public override void EnterState(StateMachineChamba stateMachine)
    {
        stateMachine.StartCoroutine(stateMachine.ChangeClothes(stateMachine.clothes[2]));
        stateMachine.agent.speed = 0;
        Debug.Log("A chambear");
    }

    public override void ExitState(StateMachineChamba stateMachine)
    {
        Debug.Log("Fuga");
    }

    public override void UpdateState(StateMachineChamba stateMachine)
    {
        //chamba logic
    }
}
