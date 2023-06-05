using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private SortedDictionary<int, ICharacter> characters;
    private HashSet<IUsesTimeline> automaticTimelineObjects;
    private int currentPriority = 1;

    private void Awake()
    {
        automaticTimelineObjects = new HashSet<IUsesTimeline>();
        characters = new SortedDictionary<int, ICharacter>();

        FTObject.created += (obj => HandleCreated(obj));
        FTObject.destroyed += (obj => HandleDestroyed(obj));
    }

    private void Start()
    {
        GameLoop();
    }

    async void GameLoop()
    {
        while (true)
        {
            await characters[currentPriority].DoActionAsync();

            foreach (var obj in automaticTimelineObjects)
            {
                obj.DoTimeStep();
            }

            if (characters[currentPriority].NumOfActions == 0) GetNextCharacter();
            await Task.Delay(100);
        }
    }

    private void GetNextCharacter()
    {
        currentPriority = GetNextPriority();
        characters[currentPriority].NumOfActions = characters[currentPriority].MaxNumOfActions;
    }

    public void HandleCreated(FTObject obj)
    {
        var t = obj.GetComponent<IUsesTimeline>();
        if (t != null && t.Automatic) automaticTimelineObjects.Add(t);

        ICharacter characterToAdd = obj.GetComponent<ICharacter>();
        if (characterToAdd != null)
        {
            int priority = characters.Count > 0 ? characters.Last().Key+1 : 1;
            characterToAdd.Priority = priority;
            characters.Add(priority, characterToAdd);
        }
    }

    public void HandleDestroyed(FTObject obj)
    {
        var t = obj.GetComponent<IUsesTimeline>();
        if (t != null && t.Automatic) automaticTimelineObjects.Remove(t);

        ICharacter characterToRemove = obj.GetComponent<ICharacter>();
        if (characterToRemove != null) {
            characters.Remove(characterToRemove.Priority);
            if (characterToRemove.Priority == currentPriority) GetNextCharacter();
        }
    }

    private int GetNextPriority()
    {
        var t = characters.Keys.FirstOrDefault(key => key > currentPriority);
        return t == 0 ? characters.First().Key : t;
    }

    private int GetPreviousPriority()
    {
        var t = characters.Keys.LastOrDefault(key => key < currentPriority);
        return t == 0 ? characters.Last().Key : t;
    }
}
