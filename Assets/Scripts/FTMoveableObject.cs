using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;
public enum Direction { NORTH, SOUTH, NORTHEAST, NORTHWEST, SOUTHEAST, SOUTHWEST }
abstract public class FTMoveableObject : FTGameObject
{

    public Action<Direction> startedMoving;
    public Action<Direction> moved;

    [SerializeField] float speed = 1f;
    [SerializeField] bool isMoving = false;
    [SerializeField] Vector3 targetWorldPoisition;


    protected virtual void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetWorldPoisition, Time.deltaTime * speed);
            if (transform.position == targetWorldPoisition) EndMove();
        }
    }

    Direction currDir;
    protected void Move(Vector3 pos, Direction dir)
    {
        isMoving = true;
        targetWorldPoisition = pos;
        currDir = dir;
        startedMoving?.Invoke(dir);
    }

    void EndMove()
    {
        isMoving = false;
        moved?.Invoke(currDir);
    }

    public void goNorth()
    {
        var temp = currentPos;
        temp.x += 1;
        if (isValidMove(temp))
        {
            currentPos = temp;
        }
        Move(FTGrid.GetCellCenterWorld(currentPos), Direction.NORTH);
    }
    public void goSouth()
    {
        var temp = currentPos;
        temp.x -= 1;
        if (isValidMove(temp))
        {
            currentPos = temp;
        }
        Move(FTGrid.GetCellCenterWorld(currentPos), Direction.SOUTH);
    }
    public void goNorthEast()
    {
        var temp = currentPos;
        if (temp.y % 2 != 0) temp.x += 1;
        temp.y += 1;
        if (isValidMove(temp))
        {
            currentPos = temp;
        }
        Move(FTGrid.GetCellCenterWorld(currentPos), Direction.NORTHEAST);
    }
    public void goNorthWest()
    {
        var temp = currentPos;
        if (temp.y % 2 != 0) temp.x += 1;
        temp.y -= 1;
        if (isValidMove(temp))
        {
            currentPos = temp;
        }
        Move(FTGrid.GetCellCenterWorld(currentPos), Direction.NORTHWEST);
    }
    public void goSouthEast()
    {
        var temp = currentPos;
        if (temp.y % 2 == 0) temp.x -= 1;
        temp.y += 1;
        if (isValidMove(temp))
        {
            currentPos = temp;
        }
        Move(FTGrid.GetCellCenterWorld(currentPos), Direction.SOUTHEAST);
    }
    public void goSouthWest()
    {
        var temp = currentPos;
        if (temp.y % 2 == 0) temp.x -= 1;
        temp.y -= 1;
        if (isValidMove(temp))
        {
            currentPos = temp;
        }
        Move(FTGrid.GetCellCenterWorld(currentPos), Direction.SOUTHWEST);
    }

    public bool isValidMove(Vector3Int pos)
    {
        Tilemap tilemap = FTGrid.Tilemaps[0];
        TileBase tile = tilemap.GetTile(pos);
        return tile.name.Contains("floor", System.StringComparison.OrdinalIgnoreCase);
    }
}
