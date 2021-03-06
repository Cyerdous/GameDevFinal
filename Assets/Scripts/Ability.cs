using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public string aName = "Ability Name";
    public Sprite aSprite;
    public AudioClip aSound;
    public float aBaseCooldown = 1f;


    public abstract void Initialize(GameObject obj);
    public abstract void TriggerAbility();
}
