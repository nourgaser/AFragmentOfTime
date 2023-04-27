using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

abstract public class FTCharacter : FTMoveableObject
{
    public int steps;
    public int maxSteps;
    public abstract void takeStep();
    public Action stepTaken;

    [SerializeField] FTCharacterAnimator animator;

    protected virtual void handleMoved(Direction dir)
    {
        steps--;
        moved -= handleMoved;
        stepTaken?.Invoke();
    }
}
