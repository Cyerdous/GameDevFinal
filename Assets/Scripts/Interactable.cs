using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float interactRadius;
    //bool hasInteracted = false;
    protected GameObject interactor;

    public void OnMouseOver()
    {
        //highlight edges

        //display interact key message
    }

    public virtual void Interact(GameObject interactSource)
    {
        interactor = interactSource;   
    }
}
