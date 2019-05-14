using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ResultAction : ScriptableObject
{
    public NarrativeTrigger narrativeTrigger;
    //public NarrativeTrigger narrativeTrigger;
    public CustomAction customAction;

    public void ExecuteAction()
    {
        
        if (narrativeTrigger != null)
        {
            narrativeTrigger.TriggerNarrative();
        }
        if (customAction != null)
        {
            customAction.ExecuteCustomAction();
        }
    }
}
