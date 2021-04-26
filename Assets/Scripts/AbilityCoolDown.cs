using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCoolDown : MonoBehaviour
{
	public string abilityButtonAxisName = "Fire1";
	public Image darkMask;
	public Text coolDownTextDisplay;

	[SerializeField] private Ability ability;
	[SerializeField] private GameObject weaponHolder;
	private Image myButtonImage;
	private AudioSource abilitySource;
	private float cooldownDuration;
	private float nextReadyTime;
	private float cooldownTime;

	void Start()
	{
		Initialize(ability, weaponHolder);
	}

	public void Initialize(Ability selectedAbility, GameObject weaponHolder)
	{
		ability = selectedAbility;
		myButtonImage = GetComponent<Image>();
		abilitySource = GetComponent<AudioSource>();
		myButtonImage.sprite = ability.aSprite;
		darkMask.sprite = ability.aSprite;
		cooldownDuration = ability.aBaseCooldown;
		ability.Initialize(weaponHolder);
		AbilityReady();
	}

	void Update()
	{
		bool cooldownComplete = Time.time > nextReadyTime;
		if (cooldownComplete)
		{
			AbilityReady();
			if (Input.GetButton(abilityButtonAxisName))
			{
				ButtonTriggered();
			}
		}
		else
		{
			Cooldown();
		}
	}

	private void AbilityReady()
	{
		coolDownTextDisplay.enabled = false;
		darkMask.enabled = false;
	}

	private void Cooldown()
	{
		cooldownTime -= Time.deltaTime;
		float roundedCd = Mathf.Round(cooldownTime);
		coolDownTextDisplay.text = roundedCd.ToString();
		darkMask.fillAmount = cooldownTime / cooldownDuration;
	}

	private void ButtonTriggered()
	{
		nextReadyTime = cooldownDuration + Time.time;
		cooldownTime = cooldownDuration;
		darkMask.enabled = true;
		coolDownTextDisplay.enabled = true;

		abilitySource.clip = ability.aSound;
		abilitySource.Play();
		ability.TriggerAbility();
	}
}
