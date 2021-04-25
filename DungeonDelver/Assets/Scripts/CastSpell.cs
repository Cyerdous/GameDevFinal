using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpell : MonoBehaviour
{
    public GameObject Firebolt;
    public float Force = 50.0f;
    public Vector3 Torque = new Vector3(100, 0, 0);
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject firebolt = (GameObject)Instantiate(Firebolt, transform.position, transform.rotation);
            firebolt.name = "firebolt";
            firebolt.transform.position = transform.TransformPoint(2*Vector3.forward);
            firebolt.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, 0, Force));
            firebolt.GetComponent<Rigidbody>().AddRelativeTorque(Torque);
        }
    }
}
