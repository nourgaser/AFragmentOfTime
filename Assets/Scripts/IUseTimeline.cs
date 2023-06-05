using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUsesTimeline
{
    bool Automatic { get; }
    void DoTimeStep();
    void UndoTimeStep();
}
