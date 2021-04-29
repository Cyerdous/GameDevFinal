using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AbilityBarController : MonoBehaviour
{
	List<AbilitySlot> slots = new List<AbilitySlot>();
    public GameObject abilityIconPrefab;
	[SerializeField] GameObject attackOrigin;

	void Awake()
	{
		slots = gameObject.GetComponentsInChildren<AbilitySlot>().ToList();
		slots.ForEach(x => x.InitializeAbility(null, attackOrigin));
	}

    public void AddAbility(Ability ability)
    {
        //Instantiate ui element to abilitybar
        GameObject obj = Instantiate(abilityIconPrefab, gameObject.transform);
        AbilitySlot slot = obj.GetComponentInChildren<AbilitySlot>();
        RectTransform rect = obj.GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector3(100 * slots.Count, 0f );
        slot.InitializeAbility(ability, attackOrigin);

        slots.Add(slot);
    }

	void Update()
	{
		for (int i = 0; i < slots.Count; i++)
		{
			if (Input.GetKey((KeyCode)KeyCode.Alpha1 + i))
			{
				if (slots[i] != null)
				{
					slots[i].UseAbility();
				}
				Debug.Log(i);
			}
		}
	}
}
