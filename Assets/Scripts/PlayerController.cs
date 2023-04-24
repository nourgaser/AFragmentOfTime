using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : FTMoveableObject
{
    private new void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Q)) { GoNorthWest(); }
        if (Input.GetKeyDown(KeyCode.W)) { GoNorth(); }
        if (Input.GetKeyDown(KeyCode.E)) { GoNorthEast(); }
        if (Input.GetKeyDown(KeyCode.A)) { GoSouthWest(); }
        if (Input.GetKeyDown(KeyCode.S)) { GoSouth(); }
        if (Input.GetKeyDown(KeyCode.D)) { GoSouthEast(); }
    }
}
