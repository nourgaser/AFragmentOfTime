using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FTObject : MonoBehaviour
{
    public static Action<FTObject> created, destroyed;

    protected virtual void Start()
    {
        created?.Invoke(this);
    }

    protected virtual void OnDestroy()
    {
        destroyed?.Invoke(this);
    }

    public static implicit operator FTObject(GameObject obj) {
        return obj.GetComponent<FTObject>();
    }
}
