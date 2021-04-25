using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firebolt : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(SelfDestruct());
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "attackable")
        {
            collision.gameObject.SendMessage("TakeHit"); // Add damage info to this at some point
            Destroy(gameObject);
        }
    }

    private IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
