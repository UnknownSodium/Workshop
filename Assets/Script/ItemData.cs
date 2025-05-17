using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// set default name when created
[CreateAssetMenu(fileName = "NewItemData", menuName = "Workshop/ItemData")]

public class ItemData : ScriptableObject
{
    public string itemName;
    public string description;
    public Sprite itemIcon;

    
}
