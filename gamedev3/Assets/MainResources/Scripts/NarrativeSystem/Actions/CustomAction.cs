using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CustomAction : ScriptableObject
{
    public object ExecuteCustomAction()
    {
        
        Debug.Log("custom action");
        return null;
    }
}
