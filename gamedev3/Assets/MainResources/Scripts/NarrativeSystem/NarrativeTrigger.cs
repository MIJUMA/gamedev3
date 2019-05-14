using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class NarrativeTrigger : ScriptableObject
{
   public Narrative narrative;

   public void TriggerNarrative()
    {
        FindObjectOfType<NarrativeManager>().StartNarrative(narrative);
    }
}