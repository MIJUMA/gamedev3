using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class NarrativeAudio : ScriptableObject
{
    public AudioClip[] AudioClips;

    public AudioClip GetNarrativeClip(int i)
    {
        if (i < AudioClips.Length && i >= 0)
        {
            return AudioClips[i];
        }
        return null;
    }
}
