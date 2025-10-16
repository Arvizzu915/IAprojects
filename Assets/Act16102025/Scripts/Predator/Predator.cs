using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(NavMeshAgent))]
public class Predator : MonoBehaviour
{
    public PredatorState initialState;

    public PredatorState currentState;

    public PredatorStateSearching stateSearching;
    public PredatorStateLurking stateLurking;
    public PredatorStateChasing stateChasing;
    public PredatorStateFollowing stateFollowing;
    public PredatorStateTired stateTired;

    public NavMeshAgent agent;

    private void Start()
    {
        currentState = initialState;
    }

    void Update()
    {
        currentState.OnUpdate(this);
    }

    public void ChangeState(PredatorState newState)
    {
        if (newState == currentState) return;

        currentState?.OnExit(this);

        currentState = newState;    

        currentState?.OnEnter(this);
    }

    public void ViewConeDetect(List<Transform> targets)
    {
        currentState.OnViewDetect(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
