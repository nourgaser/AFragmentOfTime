using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;
public enum Direction { NORTH, SOUTH, NORTHEAST, NORTHWEST, SOUTHEAST, SOUTHWEST }
public class Movement: MonoBehaviour
{
    Vector3Int currentPos = Vector3Int.zero;
    
    protected void _Move(Vector3 pos, Direction dir)
    {
        transform.position = pos;
    }

    private void goNorth()
    {
        var temp = currentPos;
        temp.x += 1;
        if (isValidMove(temp))
        {
            currentPos = temp;
        }
        _Move(FTGrid.GetCellCenterWorld(currentPos), Direction.NORTH);
    }
    private void goSouth()
    {
        var temp = currentPos;
        temp.x -= 1;
        if (isValidMove(temp))
        {
            currentPos = temp;
        }
        _Move(FTGrid.GetCellCenterWorld(currentPos), Direction.SOUTH);
    }
    private void goNorthEast()
    {
        var temp = currentPos;
        if (temp.y % 2 != 0) temp.x += 1;
        temp.y += 1;
        if (isValidMove(temp))
        {
            currentPos = temp;
        }
        _Move(FTGrid.GetCellCenterWorld(currentPos), Direction.NORTHEAST);
    }
    private void goNorthWest()
    {
        var temp = currentPos;
        if (temp.y % 2 != 0) temp.x += 1;
        temp.y -= 1;
        if (isValidMove(temp))
        {
            currentPos = temp;
        }
        _Move(FTGrid.GetCellCenterWorld(currentPos), Direction.NORTHWEST);
    }
    private void goSouthEast()
    {
        var temp = currentPos;
        if (temp.y % 2 == 0) temp.x -= 1;
        temp.y += 1;
        if (isValidMove(temp))
        {
            currentPos = temp;
        }
        _Move(FTGrid.GetCellCenterWorld(currentPos), Direction.SOUTHEAST);
    }
    private void goSouthWest()
    {
        var temp = currentPos;
        if (temp.y % 2 == 0) temp.x -= 1;
        temp.y -= 1;
        if (isValidMove(temp))
        {
            currentPos = temp;
        }
        _Move(FTGrid.GetCellCenterWorld(currentPos), Direction.SOUTHWEST);
    }
    public void Move(Direction dir)
    {
        switch (dir)
        {
            case Direction.NORTH:
                goNorth();
                break;
            case Direction.SOUTH:
                goSouth();
                break;
            case Direction.NORTHEAST:
                goNorthEast();
                break;
            case Direction.NORTHWEST:
                goNorthWest();
                break;
            case Direction.SOUTHEAST:
                goSouthEast();
                break;
            case Direction.SOUTHWEST:
                goSouthWest();
                break;
        }
    }
    public bool isValidMove(Vector3Int pos)
    {
        Tilemap tilemap = FTGrid.Tilemaps[0];
        TileBase tile = tilemap.GetTile(pos);
        return tile.name.Contains("floor", System.StringComparison.OrdinalIgnoreCase);
    }
}
