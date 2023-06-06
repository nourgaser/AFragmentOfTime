using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(RangedAttack))]


public class PlayerActions : MonoBehaviour
{
    [SerializeField] Movement movement;
    [SerializeField] RangedAttack rangedAttack;


    public bool Move(Direction dir)
    {
        return movement.Move(dir);
    }

    public bool RangedAttack(Direction dir)
    {
        return rangedAttack.SpawnOrb(dir);
    }

}
