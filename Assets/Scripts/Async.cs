using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Async : MonoBehaviour
{

    static Async instance;

    void Awake() {
        if (instance != null) {
            Destroy(this);
            return;
        }
        instance = this;
    }

    public static Task<bool> WaitOneFrame()
    {
        var tcs = new TaskCompletionSource<bool>();
        instance.StartCoroutine(WaitOneFrame(tcs));
        return tcs.Task;
    }

    static IEnumerator WaitOneFrame(TaskCompletionSource<bool> tcs)
    {
        yield return null;
        tcs.SetResult(true);
    }
}
