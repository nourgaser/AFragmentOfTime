using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public void SpawnOrb(Direction dir){
        Orb.Create(FTGrid.GetCellCenterWorld(FTGrid.GetNeighbour(transform.position, dir)), dir);
    }
}
