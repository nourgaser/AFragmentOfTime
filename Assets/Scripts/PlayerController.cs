using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerActions))]
public class PlayerController : MonoBehaviour
{

    [SerializeField] PlayerActions actions;
    public async Task WaitForActionAsync()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.Space)) { return; }

            if (Input.GetKeyDown(KeyCode.Q) && Input.GetKey(KeyCode.LeftShift)) { if (actions.RangedAttack(Direction.NORTHWEST)) return; }
            if (Input.GetKeyDown(KeyCode.W) && Input.GetKey(KeyCode.LeftShift)) { if (actions.RangedAttack(Direction.NORTH)) return; }
            if (Input.GetKeyDown(KeyCode.E) && Input.GetKey(KeyCode.LeftShift)) { if (actions.RangedAttack(Direction.NORTHEAST)) return; }
            if (Input.GetKeyDown(KeyCode.A) && Input.GetKey(KeyCode.LeftShift)) { if (actions.RangedAttack(Direction.SOUTHWEST)) return; }
            if (Input.GetKeyDown(KeyCode.S) && Input.GetKey(KeyCode.LeftShift)) { if (actions.RangedAttack(Direction.SOUTH)) return; }
            if (Input.GetKeyDown(KeyCode.D) && Input.GetKey(KeyCode.LeftShift)) { if (actions.RangedAttack(Direction.SOUTHEAST)) return; }

            if (Input.GetKeyDown(KeyCode.Q)) { if (actions.Move(Direction.NORTHWEST)) return; }
            if (Input.GetKeyDown(KeyCode.W)) { if (actions.Move(Direction.NORTH)) return; }
            if (Input.GetKeyDown(KeyCode.E)) { if (actions.Move(Direction.NORTHEAST)) return; }
            if (Input.GetKeyDown(KeyCode.A)) { if (actions.Move(Direction.SOUTHWEST)) return; }
            if (Input.GetKeyDown(KeyCode.S)) { if (actions.Move(Direction.SOUTH)) return; }
            if (Input.GetKeyDown(KeyCode.D)) { if (actions.Move(Direction.SOUTHEAST)) return; }

            await Async.WaitOneFrame();
        }
    }
}
