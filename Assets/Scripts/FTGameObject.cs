using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class FTGameObject : MonoBehaviour
{
    public int health;
    [SerializeField] protected Vector3Int currentPos;
}
