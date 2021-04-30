using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [SerializeField] private float interactionRadius = 3f;
    [SerializeField] private GameObject player;
    [SerializeField] private string interactButton = "Interact";
    
    private Camera firstPerson;

    void Start()
    {
        firstPerson = player.GetComponentInChildren<Camera>();
    }

    void Update()
    {
        if(Input.GetKeyDown(interactButton))
        {
            Debug.Log("attempting to interact");
            Vector3 camCenter = firstPerson.ViewportToWorldPoint(new Vector3(.5f, .5f, 0));
            RaycastHit hit;
            if(Physics.Raycast(camCenter, firstPerson.transform.forward, out hit, interactionRadius))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    Debug.Log("found interactable");
                    interactable.Interact(player);
                }
            }
        }
    }
}
