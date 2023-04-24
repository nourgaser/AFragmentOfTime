using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class FTMoveableObject : MonoBehaviour
{
    [SerializeField] Vector3Int currentPos;

    protected virtual void Update()
    {
        transform.position = FTGrid.GetCellCenterWorld(currentPos);
    }

    public void GoNorth() { currentPos.x += 1; Clamp(); }
    public void GoSouth() { currentPos.x -= 1; Clamp(); }
    public void GoNorthEast()
    {
        if (currentPos.y % 2 != 0) currentPos.x += 1;
        currentPos.y += 1;
        Clamp();
    }
    public void GoNorthWest()
    {
        if (currentPos.y % 2 != 0) currentPos.x += 1;
        currentPos.y -= 1;
        Clamp();
    }
    public void GoSouthEast()
    {
        if (currentPos.y % 2 == 0) currentPos.x -= 1;
        currentPos.y += 1;
        Clamp();
    }
    public void GoSouthWest()
    {
        if (currentPos.y % 2 == 0) currentPos.x -= 1;
        currentPos.y -= 1;
        Clamp();
    }
    private void Clamp()
    {
        currentPos.x = Mathf.Clamp(currentPos.x, FTGrid.MinX, FTGrid.MaxX);
        currentPos.y = Mathf.Clamp(currentPos.y, FTGrid.MinY, FTGrid.MaxY);
    }
}
