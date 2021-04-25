using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/ProjectileAbility")]
public class ProjectileAbility : Ability
{
    public float projectileForce = 500f;
    public Rigidbody projectile;

    private ProjectileShooter shooter;


	public override void Initialize(GameObject obj)
	{
        shooter = obj.GetComponent<ProjectileShooter>();
        shooter.Initialize();
        shooter.force = projectileForce;
        shooter.projectile = projectile;
	}

	public override void TriggerAbility()
	{
        shooter.Shoot();
	}
}
