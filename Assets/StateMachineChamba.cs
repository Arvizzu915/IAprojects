using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class StateMachineChamba : MonoBehaviour, ITimeListener
{
    [SerializeField] private MeshRenderer m_Renderer;

    public Material[] clothes;

    public ChambaState currentState;

    public ChambaStateGo stateGo = new();
    public ChambaStateWork stateWork = new();
    public ChambaStateReturn stateReturn = new();

    public Transform home;
    public Transform workplace;

    public bool Changing = false;

    public NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentState = stateGo;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void ChangeState(ChambaState state)
    {
        currentState.ExitState(this);
        currentState = state;
        currentState.EnterState(this);
    }

    public IEnumerator ChangeClothes(Material material)
    {
        Changing = true;
        yield return new WaitForSeconds(3f);
        m_Renderer.material = material;
        Changing = false;
    }

    public void ChangeToDay()
    {
        ChangeState(stateGo);
    }

    public void ChangeToNight()
    {
        ChangeState(stateReturn);
    }
}
