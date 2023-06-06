using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public bool SpawnOrb(Direction dir)
    {
        var neighbour = FTGrid.GetNeighbour(transform.position, dir);

        if (FTGrid.IsOccupied(neighbour)) return false;

        return Orb.Create(FTGrid.GetCellCenterWorld(neighbour), dir);
    }
}
