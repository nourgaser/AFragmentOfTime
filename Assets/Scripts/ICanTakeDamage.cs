using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanTakeDamage
{
    public int Health {get; set;}

    public int MaxHealth {get; set;}

    public void TakeDamage(int dmg);

}
