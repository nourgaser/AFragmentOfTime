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

}
