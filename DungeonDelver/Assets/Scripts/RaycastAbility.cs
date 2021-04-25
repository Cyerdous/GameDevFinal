using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/RaycastAbility")]
public class RaycastAbility : Ability
{
    public int rayDamage = 1;
    public float range = 50f;
    public float hitForce = 100f;
    public Color laserColor = Color.white;

    private RaycastShooter rcShoot;

    public override void Initialize(GameObject obj)
    {

    }

    public override void TriggerAbility()
    {

    }

}
