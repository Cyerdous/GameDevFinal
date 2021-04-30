using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public Stat armor;
    public Stat attackPower;
    public Stat crit;
    public Stat maxHealth;
    public int currentHealth { get; private set; } 
    public Stat maxMana;
    public int currentMana { get; private set; }

    void Awake()
    {
        currentMana = maxMana.GetValue();
        currentHealth = maxHealth.GetValue();
    }

    public virtual void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        
        Debug.Log($"taking {damage} damage");
		currentHealth -= damage;
		if (currentHealth <= 0)
		{
			Die();
		}

    }

    public virtual void Die()
    {
        //override this!
    }
}
