using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public override void Die()
    {
        // death animation

        // drop loot

        // destroy game object
        Destroy(gameObject);
    }
}
