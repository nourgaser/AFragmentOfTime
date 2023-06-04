using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] Movement movement;

    public async Task DoActionAsync()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.Q)) { movement.Move(Direction.NORTHWEST); return; }
            if (Input.GetKey(KeyCode.W)) { movement.Move(Direction.NORTH); return; }
            if (Input.GetKey(KeyCode.E)) { movement.Move(Direction.NORTHEAST); return; }
            if (Input.GetKey(KeyCode.A)) { movement.Move(Direction.NORTHWEST); return; }
            if (Input.GetKey(KeyCode.S)) { movement.Move(Direction.SOUTH); return; }
            if (Input.GetKey(KeyCode.D)) { movement.Move(Direction.SOUTHEAST); return; }
            await Async.WaitOneFrame();
        }
    }
}
