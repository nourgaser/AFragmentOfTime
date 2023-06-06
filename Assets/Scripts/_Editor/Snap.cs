using UnityEngine;
using System.Linq;

[ExecuteInEditMode]
public class Snap : MonoBehaviour
{
    private void Update()
    {
        Grid grid = GameObject.Find("Grid").GetComponent<Grid>();
        foreach (var obj in GameObject.FindObjectsOfType<GameObject>().Select(obj => obj.GetComponent<FTObject>()))
        {
            if (obj != null) obj.transform.position = grid.GetCellCenterLocal(grid.WorldToCell(obj.transform.position));
        }
    }
}
