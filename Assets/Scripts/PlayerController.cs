using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Player player;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) { player.goNorthWest(); }
        if (Input.GetKeyDown(KeyCode.W)) { player.goNorth(); }
        if (Input.GetKeyDown(KeyCode.E)) { player.goNorthEast(); } 
        if (Input.GetKeyDown(KeyCode.A)) { player.goSouthWest(); }
        if (Input.GetKeyDown(KeyCode.S)) { player.goSouth(); }
        if (Input.GetKeyDown(KeyCode.D)) { player.goSouthEast(); }
    }
}
