using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item")]
public class Item : ScriptableObject
{
    public string itemID;
    public enum ItemType { Weapon, Tool, Armor, Consumable, Material, Currency};
    public ItemType itemType;

    public Sprite icon;
    public int stackSize;
}

[System.Serializable]
public class ItemStack
{
    public Item item;
    public int amount;
}
