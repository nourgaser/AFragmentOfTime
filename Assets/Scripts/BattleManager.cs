using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public FTCharacter[] characters;
    FTCharacter currentCharacter { get { return characters[idx]; } }
    private void Start()
    {
        currentCharacter.stepTaken += handleStep;
        currentCharacter.takeStep();

    }

    private void handleStep()
    {
        if (currentCharacter.steps != 0)
        {
            currentCharacter.takeStep();
        }
        else
        {
            currentCharacter.stepTaken -= handleStep;
            getNextCharacter();
            currentCharacter.steps = currentCharacter.maxSteps;
            currentCharacter.stepTaken += handleStep;
            handleStep();
        }
    }

    public int idx = 0;
    private void getNextCharacter()
    {
        idx++;
        if (idx > characters.Length - 1) idx = 0;
    }


}
