using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Projectile Ability Item")]
public class ProjectileAbilityItem : Item
{
    public ProjectileAbility ability;
    [SerializeField] GameObject canvas;
    private AbilityBarController controller;
	public override void PickUp(GameObject entity)
	{
		base.PickUp(entity);
        controller = entity.GetComponentInChildren<AbilityBarController>();
        
        controller.AddAbility(ability);     
	}
}
