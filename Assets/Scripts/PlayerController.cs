using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Player player;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Q)) { player.goNorthWest(); enabled = false; }
        if (Input.GetKey(KeyCode.W)) { player.goNorth(); enabled = false; }
        if (Input.GetKey(KeyCode.E)) { player.goNorthEast(); enabled = false; }
        if (Input.GetKey(KeyCode.A)) { player.goSouthWest(); enabled = false; }
        if (Input.GetKey(KeyCode.S)) { player.goSouth(); enabled = false; }
        if (Input.GetKey(KeyCode.D)) { player.goSouthEast(); enabled = false; }
    }
}
