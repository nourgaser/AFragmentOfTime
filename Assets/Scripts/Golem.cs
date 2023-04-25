using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : FTCharacter
{

    public override void takeStep() {
        Invoke("_takeStep", 0.75f);
    }

    public void _takeStep()
    {

        int idx = Random.Range(0,6);
        switch (idx)
        {
            case 0:
                goNorth();
                break;
            case 1:
                goNorthWest();
                break;
            case 2:
                goNorthEast();
                break;
            case 3:
                goSouth();
                break;
            case 4:
                goSouthEast();
                break;
            case 5:
                goSouthWest();
                break;

        }
        steps -= 1;
        stepTaken();

    }
}
