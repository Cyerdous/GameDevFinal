using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Equipment")]



public class Equipment : Item
{
    public EquipmentSlot slot;
    public int armorModifier;
    public int attackPowerModifier;
    public int critModifier;
    public int healthModifier;
    public EquipmentManager equipmentManager;

    public override void Use()
    {
        base.Use();
        // Equip item
        // Remove from inventory
        RemoveFromInventory();
    }

	public override void PickUp(GameObject entity)
	{
		base.PickUp(entity);
        equipmentManager = entity.GetComponentInChildren<EquipmentManager>();
        equipmentManager.Equip(this);
	}
}
public enum EquipmentSlot
{
    Head,
    Shoulder,
    Chest,
    Wrists,
    Hands,
    Waist,
    Legs,
    Feet,
    MainHand,
    OffHand,
    OneHand
}