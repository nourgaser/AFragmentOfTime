using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : FTCharacter
{

    private void Start()
    {
        transform.position = FTGrid.GetCellCenterWorld(currentPos);
    }

    public override void takeStep()
    {

        int idx = Random.Range(0, 6);
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
        moved += handleMoved;
    }
}
