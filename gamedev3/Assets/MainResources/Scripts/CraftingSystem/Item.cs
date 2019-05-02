using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string ItemName;
    public Sprite icon;


    public virtual Item GetCopy()
    {
        return this;
    }

    public virtual void Destroy()
    {

    }
}
