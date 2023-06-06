using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Enemy : FTObject, ICharacter, ICanTakeDamage
{
    [field: SerializeField] public int NumOfActions { get; set; } = 1;
    [field: SerializeField] public int MaxNumOfActions { get; set; } = 1;
    [SerializeField] Movement movement;

    [field: SerializeField] public int Health { get; set; } = 2;
    [field: SerializeField] public int MaxHealth { get; set; } = 2;
    [field: SerializeField] public int Priority { get; set; }

    public async Task DoActionAsync()
    {
        List<Direction> legalDirections = new List<Direction>();
        foreach (var direction in Enum.GetValues(typeof(Direction)))
        {
            var neighbour = FTGrid.GetNeighbour(transform.position, (Direction)direction);
            if (FTGrid.IsWalkable(neighbour))
            {
                legalDirections.Add((Direction)direction);
            }
        }
        if (legalDirections.Count > 0)
        {
            int choice = UnityEngine.Random.Range(0, legalDirections.Count);
            movement.Move(legalDirections[choice]);
        }
        NumOfActions--;
        await Task.Delay(25);
    }

    public void TakeDamage(int dmg)
    {
        Health -= dmg;
        if (Health <= 0)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
