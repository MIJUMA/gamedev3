using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType
{
    CraftableResource,
    Uncraftable
}

[CreateAssetMenu]
public class EquippableItem : Item
{
    public int StrengthBonus;
    [Space]
    public EquipmentType EquipmentType;


    
}

