using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firebolt : MonoBehaviour
{
    [SerializeField]
    public int baseDamage = 10;
    private int damage;

    void Start()
    {
        StartCoroutine(SelfDestruct());
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "attackable")
        {
            CalculateDamage();
            collision.gameObject.SendMessage("TakeDamage", damage); // Add damage info to this at some point
            
        }
        Destroy(gameObject);
    }
    void OnTriggerEnter(Collider collider)
    {
        Destroy(gameObject);
    }

    private IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }

    void CalculateDamage()
    {
        damage = baseDamage;
    }
}
