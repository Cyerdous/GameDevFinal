using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShooter : MonoBehaviour
{
    [HideInInspector] public int gunDamage = 1;
    [HideInInspector] public float weaponRange = 50f;
    [HideInInspector] public float hitForce = 100f;
    
    [HideInInspector] public LineRenderer laserLine;
    public Transform spawn;


    private Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);


    void Initialize()
    {
        laserLine = GetComponent<LineRenderer>();
        fpsCam = GetComponentInParent<Camera>();

    }

    void Fire()
    {
		StartCoroutine(ShotEffect());

		Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(.5f, .5f, 0));
		RaycastHit hit;

		laserLine.SetPosition(0, spawn.position);
		if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
		{
			laserLine.SetPosition(1, hit.point);
            

		}
		else
		{
			laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
		}
    }

    private IEnumerator ShotEffect()
    {
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;

    }
}
