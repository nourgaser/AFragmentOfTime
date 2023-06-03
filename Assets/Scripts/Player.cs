using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ICharacter
{
    [field: SerializeField] public int NumOfActions { get; set; } = 3;
    [field: SerializeField] public int MaxNumOfActions { get; set; } = 3;

    [SerializeField] PlayerController controller;

    public async Task DoActionAsync()
    {
        controller.enabled = true;
        await controller.DoActionAsync();
        controller.enabled = false;
        NumOfActions--;
        await Task.Delay(150);
    }
}
