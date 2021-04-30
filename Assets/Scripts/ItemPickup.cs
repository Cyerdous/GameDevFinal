using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item; 
	public override void Interact(GameObject interactSource)
	{
		base.Interact(interactSource);
        
        PickUp();
	}
    void PickUp()
    {
        // Items that are stored in an inventory need a reference to that inventory
        // Mostly to avoid the singleton design pattern that makes multiplayer difficult
        item.PickUp(interactor);   
        Destroy(gameObject);
    }
}
