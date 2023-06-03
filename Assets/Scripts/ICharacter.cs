using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter
{
    int NumOfActions { get; set; }
    int MaxNumOfActions { get; set; }
    public Task DoActionAsync();
}
