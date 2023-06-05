using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(RangedAttack))]


public class PlayerActions : MonoBehaviour
{
    [SerializeField] Movement movement;
    [SerializeField] RangedAttack rangedAttack;


    public void Move(Direction dir)
    {
        movement.Move(dir);
    }

    public void RangedAttack(Direction dir)
    {
        rangedAttack.SpawnOrb(dir);
    }

}
