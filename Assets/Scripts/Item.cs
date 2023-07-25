using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    [SerializeField] ItemType itemType;
    [SerializeField] string itemName;
    [TextArea]
    [SerializeField] string description;
    [SerializeField] int effect;


    public enum ItemType
    {
        weapon,
        armour,
        recovery,
        tool
    }

    public string ItemName { get => itemName; }
    public ItemType ItemTypeName { get => itemType; }

    public string Description { get => description; }
    public int ItemEffect { get => effect; }
}
