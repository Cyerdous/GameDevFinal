using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    [HideInInspector] public Rigidbody projectile;
    [HideInInspector] public float weaponRange;
    [HideInInspector] public float force;
    public Transform spawn;

    private Camera fpsCam;

    public void Initialize()
    {
        Debug.Log("initializing projectileshooter");
        fpsCam = GetComponentInParent<Camera>();
        weaponRange = 50f;
    }

    public void Shoot()
    {
        Debug.Log("attempting to fire");
        Rigidbody proj = Instantiate(projectile, spawn.position, transform.rotation) as Rigidbody;

        Vector3 camCenter = fpsCam.ViewportToWorldPoint(new Vector3(.5f, .5f, 0));
        RaycastHit hit;

        Vector3 weaponFire;

        if(Physics.Raycast(camCenter, fpsCam.transform.forward, out hit, weaponRange))
        {
            weaponFire = hit.point - spawn.transform.position;
            Debug.Log("Raycast" + hit.point.ToString());
        }
        else
        {
            Vector3 point = camCenter + (fpsCam.transform.forward * weaponRange);
            weaponFire = point - spawn.transform.position;
        }
        weaponFire.Normalize();
        proj.AddForce(weaponFire * force);
    }
}
