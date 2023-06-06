using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Orb : FTObject, IUsesTimeline, ICanTakeDamage
{
    public bool Automatic { get { return true; } }

    [field: SerializeField] public Direction direction { get; private set; }

    [field: SerializeField] public int dmg { get; private set; } = 1;

    [field: SerializeField] public int Health { get; set; } = 1;
    [field: SerializeField] public int MaxHealth { get; set; } = 1;


    [SerializeField] Movement movement;

    public void DoTimeStep()
    {
        var neighbour = FTGrid.GetNeighbour(transform.position, direction);
        if (FTGrid.IsWalkable(neighbour))
            movement.Move(direction);
        else
        {
            var occupier = FTGrid.GetOccupier(neighbour)?.GetComponent<ICanTakeDamage>();
            if (occupier != null) occupier.TakeDamage(dmg);
            GameObject.Destroy(gameObject);
        }
    }

    public void UndoTimeStep()
    {
        Debug.Log("Can't undo right now.");
    }

    public static bool Create(Vector3 worldPos, Direction dir)
    {
        Orb orb = GameObject.Instantiate((GameObject)Resources.Load("Prefabs/Orb"), worldPos, Quaternion.identity).GetComponent<Orb>();
        orb.direction = dir;

        return true;
    }

    public void TakeDamage(int dmg)
    {
        GameObject.Destroy(gameObject);
    }
}
