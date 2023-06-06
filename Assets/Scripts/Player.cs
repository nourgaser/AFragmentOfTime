using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : FTObject, ICharacter
{
    [field: SerializeField] public int NumOfActions { get; set; } = 3;
    [field: SerializeField] public int MaxNumOfActions { get; set; } = 3;
    public int Priority { get; set; }

    [SerializeField] PlayerController controller;

    public async Task DoActionAsync()
    {
        controller.enabled = true;
        await controller.WaitForActionAsync();
        controller.enabled = false;
        NumOfActions--;
        await Task.Delay(25);
    }
}
