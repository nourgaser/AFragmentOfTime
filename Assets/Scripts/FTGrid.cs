using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FTGrid : MonoBehaviour
{
    private static FTGrid instance;

    private Grid grid;
    public static int MinX { get; private set; } = -5;
    public static int MaxX { get; private set; } = 5;
    public static int MinY { get; private set; } = -5;
    public static int MaxY { get; private set; } = 5;

    private void Awake()
    {
        if (instance != null) { GameObject.Destroy(this); return; }

        instance = this;
        grid = GetComponent<Grid>();
    }

    public static Vector3 GetCellCenterWorld(Vector3Int cellPosition)
    {
        return instance.grid.GetCellCenterLocal(cellPosition);
    }

    public static bool OutOfBounds(Vector3Int cellPosition)
    {
        return false;
    }
}
