using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] Movement movement;
    bool done = false;
    private void Update()
    {
        if (done) return; 
        if (Input.GetKey(KeyCode.Q)) { movement.Move(Direction.NORTHWEST); done = true; }
        if (Input.GetKey(KeyCode.W)) { movement.Move(Direction.NORTH); done = true; }
        if (Input.GetKey(KeyCode.E)) { movement.Move(Direction.NORTHEAST); done = true; }
        if (Input.GetKey(KeyCode.A)) { movement.Move(Direction.NORTHWEST); done = true; }
        if (Input.GetKey(KeyCode.S)) { movement.Move(Direction.SOUTH); done = true; }
        if (Input.GetKey(KeyCode.D)) { movement.Move(Direction.SOUTHEAST); done = true; }

        // attack stuff here
    }

    public async Task DoActionAsync()
    {
        while (true) {
            await Task.Delay(20);
            if (done) { 
                done = false;
                return;
            }
        }
    }
}
