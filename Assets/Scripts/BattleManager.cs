using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public ICharacter[] characters;
    ICharacter CurrentCharacter { get { return characters[idx]; } }
    public int idx = 0;

    private void Start()
    {
        characters = FindObjectsOfType<MonoBehaviour>().OfType<ICharacter>().ToArray();
        TimeStep();
    }
    
    async void TimeStep()
    {
        while (true)
        {
            await CurrentCharacter.DoActionAsync();
            if (CurrentCharacter.NumOfActions == 0) getNextCharacter();
        }
    }

    private void getNextCharacter()
    {
        idx++;
        if (idx > characters.Length - 1) idx = 0;
        CurrentCharacter.NumOfActions = CurrentCharacter.MaxNumOfActions;
    }
}
