using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item", fileName = "New Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public Inventory inventory;

    public virtual void Use()
    {
        //Override me!
    }

    public virtual void PickUp(GameObject entity)
    {
        //Override me!
    }

    public Item RemoveFromInventory()
    {
        inventory.Remove(this);
        inventory = null;
        return this;
    }
}
