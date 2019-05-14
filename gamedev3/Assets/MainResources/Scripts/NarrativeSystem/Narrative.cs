using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]
public class Narrative
{
    public string name;
    public Sprite image;
    public Dialogue dialogue;

    public Sprite GetImage()
    {
        return this.image;
    }

    public Dialogue GetDialogue()
    {
        return this.dialogue;
    }

}
