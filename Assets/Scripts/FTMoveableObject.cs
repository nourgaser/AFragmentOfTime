using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;
abstract public class FTMoveableObject : FTGameObject
{
    [SerializeField] Vector3Int currentPos;
    public Action moved;

    protected virtual void Update()
    {

        transform.position = FTGrid.GetCellCenterWorld(currentPos);
    }

    public void goNorth()
    {
        var temp = currentPos;
        temp.x += 1;
        if (isValidMove(temp))
        {
            currentPos = temp;
            moved?.Invoke();
        }
    }
    public void goSouth()
    {
        var temp = currentPos;
        temp.x -= 1;
        if (isValidMove(temp))
        {
            currentPos = temp;
            moved?.Invoke();
        }
    }
    public void goNorthEast()
    {
        var temp = currentPos;
        if (temp.y % 2 != 0) temp.x += 1;
        temp.y += 1;
        if (isValidMove(temp))
        {
            currentPos = temp;
            moved?.Invoke();
        }
    }
    public void goNorthWest()
    {
        var temp = currentPos;
        if (temp.y % 2 != 0) temp.x += 1;
        temp.y -= 1;
        if (isValidMove(temp))
        {
            currentPos = temp;
            moved?.Invoke();
        }
    }
    public void goSouthEast()
    {
        var temp = currentPos;
        if (temp.y % 2 == 0) temp.x -= 1;
        temp.y += 1;
        if (isValidMove(temp))
        {
            currentPos = temp;
            moved?.Invoke();
        }
    }
    public void goSouthWest()
    {
        var temp = currentPos;
        if (temp.y % 2 == 0) temp.x -= 1;
        temp.y -= 1;
        if (isValidMove(temp))
        {
            currentPos = temp;
            endStep();
        }
    }

    public bool isValidMove(Vector3Int pos)
    {
        Tilemap tilemap = FTGrid.Tilemaps[0];
        TileBase tile = tilemap.GetTile(pos);
        return tile.name.Contains("floor", System.StringComparison.OrdinalIgnoreCase);
    }

    private void endStep()
    {
        moved?.Invoke();
    }
}
