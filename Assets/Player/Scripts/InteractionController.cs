using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [SerializeField] private float interactionRadius = 3f;
    [SerializeField] private GameObject player;
    [SerializeField] private string interactButton;
    
    private Camera firstPerson;

    void Start()
    {
        firstPerson = player.GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(interactButton))
        {
            Vector3 camCenter = firstPerson.ViewportToWorldPoint(new Vector3(.5f, .5f, 0));
            RaycastHit hit;
            if(Physics.Raycast(camCenter, firstPerson.transform.forward, out hit, interactionRadius))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    interactable.Interact(player);
                }
            }
        }
    }
}
