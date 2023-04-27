using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : FTCharacter
{
    PlayerController controller;
    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        controller.enabled = false;
    }
    public override void takeStep()
    {
        controller.enabled = true;
        moved += handleMoved;
    }

    private new void handleMoved(Direction dir)
    {
        moved -= handleMoved;
        base.handleMoved(dir);
    }
}
