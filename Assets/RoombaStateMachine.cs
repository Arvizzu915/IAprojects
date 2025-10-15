using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(NavMeshAgent))]
public class RoombaStateMachine : MonoBehaviour
{
    public RoombaStateIdle stateIdle = new();
    public RoombaStateClean stateClean = new();
    public RoombaStateRecharge stateRecharge = new();

    public float charge = 100;

    public NavMeshAgent agent;

    public RombaState currentState; 

    public Transform chargeStation;

    public bool trash = false;

    public List<Trash> trashInWorld = new();


    void Start()
    {
        currentState = stateIdle;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);

        if (trashInWorld.Count > 0)
        {
            trash = true;
        }
        else
        {
            trash = false;
        }
    }

    public void ChangeState(RombaState state)
    {
        currentState.ExitState(this);
        currentState = state;
        currentState.EnterState(this);
    }

    public void CleanTrash(GameObject trash)
    {
        Destroy(trash);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Trash>(out Trash trash))
        {
            trashInWorld.Remove(trash);
        }
    }
}
