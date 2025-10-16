using UnityEngine;

public abstract class PredatorState
{
    public abstract void OnEnter(Predator runner);
    
    public abstract void OnUpdate(Predator runner);

    public abstract void OnExit(Predator runner);

    public abstract void OnViewDetect(Predator runner);

    public abstract void OnTriggerEnter(Predator runner, Collider other);
}
