using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class FTGrid : MonoBehaviour
{
    private static FTGrid instance;

    private Grid grid;

    private Dictionary<Vector3Int, FTObject> occupiedCells;

    private void Awake()
    {
        if (instance != null) { GameObject.Destroy(this); return; }

        instance = this;
        occupiedCells = new Dictionary<Vector3Int, FTObject>();
        grid = GetComponent<Grid>();

        FTObject.created += (obj => { occupiedCells.Add(WorldToCell(obj.transform.position), obj); });
        FTObject.destroyed += (orb) => { occupiedCells.Remove(WorldToCell(orb.transform.position)); };
        Movement.moved += HandleMoved;
    }

    public static Vector3 GetCellCenterWorld(Vector3Int cellPosition)
    {
        return instance.grid.GetCellCenterLocal(cellPosition);
    }

    public static Vector3Int WorldToCell(Vector3 pos)
    {
        return instance.grid.WorldToCell(pos);
    }

    public static Tilemap[] Tilemaps
    {
        get
        {
            return instance.grid.GetComponentsInChildren<Tilemap>(true);
        }
    }

    public static Vector3Int GetNeighbour(Vector3 worldPos, Direction dir)
    {
        return GetNeighbour(WorldToCell(worldPos), dir);
    }

    public static Vector3Int GetNeighbour(Vector3Int cell, Direction dir)
    {
        switch (dir)
        {
            case Direction.NORTH:
                return new Vector3Int(cell.x + 1, cell.y, cell.z);
            case Direction.NORTHEAST:
                return new Vector3Int(cell.y % 2 != 0 ? cell.x + 1 : cell.x, cell.y + 1, cell.z);

            case Direction.NORTHWEST:
                return new Vector3Int(cell.y % 2 != 0 ? cell.x + 1 : cell.x, cell.y - 1, cell.z);

            case Direction.SOUTH:
                return new Vector3Int(cell.x - 1, cell.y, cell.z);

            case Direction.SOUTHEAST:
                return new Vector3Int(cell.y % 2 == 0 ? cell.x - 1 : cell.x, cell.y + 1, cell.z);

            case Direction.SOUTHWEST:
                return new Vector3Int(cell.y % 2 == 0 ? cell.x - 1 : cell.x, cell.y - 1, cell.z);

        }
        return Vector3Int.zero;
    }


    public static void HandleMoved(Vector3Int from, Vector3Int to, FTObject obj)
    {
        instance.occupiedCells.Remove(from);
        instance.occupiedCells.Add(to, obj);
    }

    public static bool IsOccupied(Vector3Int cell)
    {
        return instance.occupiedCells.ContainsKey(cell);
    }

    public static FTObject GetOccupier(Vector3Int cell)
    {
        return IsOccupied(cell) ? instance.occupiedCells[cell] : null;
    }

    public static bool IsWalkable(Vector3Int cell)
    {
        Tilemap tilemap = FTGrid.Tilemaps[0];
        TileBase tile = tilemap.GetTile(cell);
        if (!tile.name.Contains("floor", System.StringComparison.OrdinalIgnoreCase)) return false;
        if (FTGrid.IsOccupied(cell)) return false;

        return true;
    }
}
