using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class FTGrid : MonoBehaviour
{
    private static FTGrid instance;

    private Grid grid;

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

    public static Vector3Int WorldToCell(Vector3 pos)
    {
        return instance.grid.WorldToCell(pos);
    }

    public static Tilemap[] Tilemaps { get {
        return instance.grid.GetComponentsInChildren<Tilemap>(true);
    } }

}
