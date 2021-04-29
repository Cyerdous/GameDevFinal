using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : CharacterStats
{
	private EquipmentManager equipmentManager;
	void Start()
	{
		equipmentManager = gameObject.GetComponent<EquipmentManager>();
		equipmentManager.onEquipmentChanged += OnEquipmentChanged;
	}

	void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
	{
		if (newItem != null)
		{
			armor.AddModifier(newItem.armorModifier);
			attackPower.AddModifier(newItem.attackPowerModifier);
			crit.AddModifier(newItem.critModifier);
			maxHealth.AddModifier(newItem.healthModifier);
            maxMana.AddModifier(newItem.manaModifier);
		}
		if (oldItem != null)
		{
			armor.RemoveModifier(oldItem.armorModifier);
			attackPower.RemoveModifier(oldItem.attackPowerModifier);
			crit.RemoveModifier(oldItem.critModifier);
			maxHealth.RemoveModifier(oldItem.healthModifier);
            maxMana.RemoveModifier(oldItem.manaModifier);
		}

	}

	public override void Die()
	{
		base.Die();
		// Kill the player
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
