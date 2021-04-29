using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySlot : MonoBehaviour
{
    public AbilityCoolDown ability;

    void Awake()
    {
        ability = (AbilityCoolDown)gameObject.GetComponent<AbilityCoolDown>();
    }

    public void InitializeAbility(Ability ab, GameObject holder)
    {
        if(ab != null)
        {
            ability.Initialize(ab, holder); 
        }
    }

    public void UseAbility()
    {
        ability.UseAbility();
    }
}
