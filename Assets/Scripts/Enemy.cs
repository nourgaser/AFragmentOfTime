using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Enemy : MonoBehaviour, ICharacter
{
    [field: SerializeField] public int NumOfActions { get; set; } = 1;
    [field: SerializeField] public int MaxNumOfActions { get; set; } = 1;
    [SerializeField] Movement movement;
    private void Start()
    {
        movement = GetComponent<Movement>();
    }
    public async Task DoActionAsync()
    {
        int choice = Random.Range(0, 6);
        switch (choice)
        {
            case 0:
                movement.Move(Direction.NORTH);
                break;
            case 1:
                movement.Move(Direction.NORTHEAST);
                break;
            case 2:
                movement.Move(Direction.NORTHWEST);
                break;
            case 3:
                movement.Move(Direction.SOUTH);
                break;
            case 4:
                movement.Move(Direction.SOUTHEAST);
                break;
            case 5:
                movement.Move(Direction.SOUTHWEST);
                break;
        }
        NumOfActions--;
        await Task.Delay(1000);
    }
}
