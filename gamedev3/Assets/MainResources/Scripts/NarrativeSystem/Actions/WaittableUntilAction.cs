using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaittableUntilAction : CustomAction
{
    public IEnumerator ExecuteCustomAction()
    {
        yield return new WaitUntil(() => false);
    }
}
