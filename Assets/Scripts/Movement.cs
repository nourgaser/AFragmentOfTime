using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;
public class Movement : MonoBehaviour
{
    Vector3Int currentPos;

    public static Action<Vector3Int, Vector3Int, FTObject> moved;

    private void Start()
    {
        currentPos = FTGrid.WorldToCell(transform.position);
        transform.position = FTGrid.GetCellCenterWorld(currentPos);

    }

    public bool Move(Direction dir)
    {
        var newPos = FTGrid.GetNeighbour(currentPos, dir);
        if (!FTGrid.IsWalkable(newPos)) return false;
        
        var oldPos = currentPos;
        currentPos = newPos;
        moved?.Invoke(oldPos, newPos, gameObject);
        transform.position = FTGrid.GetCellCenterWorld(currentPos);
        return true;
    }
}
