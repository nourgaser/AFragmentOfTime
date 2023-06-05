using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerActions))]
public class PlayerController : MonoBehaviour
{

    [SerializeField] PlayerActions actions;
    public async Task DoActionAsync()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Q) && Input.GetKey(KeyCode.LeftShift)) { actions.RangedAttack(Direction.NORTHWEST); return; }
            if (Input.GetKeyDown(KeyCode.W) && Input.GetKey(KeyCode.LeftShift)) { actions.RangedAttack(Direction.NORTH); return; }
            if (Input.GetKeyDown(KeyCode.E) && Input.GetKey(KeyCode.LeftShift)) { actions.RangedAttack(Direction.NORTHEAST); return; }
            if (Input.GetKeyDown(KeyCode.A) && Input.GetKey(KeyCode.LeftShift)) { actions.RangedAttack(Direction.SOUTHWEST); return; }
            if (Input.GetKeyDown(KeyCode.S) && Input.GetKey(KeyCode.LeftShift)) { actions.RangedAttack(Direction.SOUTH); return; }
            if (Input.GetKeyDown(KeyCode.D) && Input.GetKey(KeyCode.LeftShift)) { actions.RangedAttack(Direction.SOUTHEAST); return; }

            if (Input.GetKeyDown(KeyCode.Q)) { actions.Move(Direction.NORTHWEST); return; }
            if (Input.GetKeyDown(KeyCode.W)) { actions.Move(Direction.NORTH); return; }
            if (Input.GetKeyDown(KeyCode.E)) { actions.Move(Direction.NORTHEAST); return; }
            if (Input.GetKeyDown(KeyCode.A)) { actions.Move(Direction.SOUTHWEST); return; }
            if (Input.GetKeyDown(KeyCode.S)) { actions.Move(Direction.SOUTH); return; }
            if (Input.GetKeyDown(KeyCode.D)) { actions.Move(Direction.SOUTHEAST); return; }

            await Async.WaitOneFrame();
        }
    }
}
