using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [Header("")]
    public ItemStack[] hotbar = new ItemStack[8];

    [Header("")]
    public ItemStack[] inventory = new ItemStack[48];

    [Header("")]
    public Item armor_Helm;
    public Item armor_Chest;
    public Item armor_Leggings;
    public Item armor_Boots;

 }
