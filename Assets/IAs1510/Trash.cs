using UnityEngine;

public class Trash : MonoBehaviour
{
    private void OnEnable()
    {
        RoombaStateMachine machine = FindFirstObjectByType<RoombaStateMachine>();

        machine.trashInWorld.Add(this);
    }
}
