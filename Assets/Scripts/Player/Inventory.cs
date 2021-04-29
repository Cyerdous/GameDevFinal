using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int space = 20;
    public List<Item> items = new List<Item>();

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    
    public bool Add(Item item)
    {
        if(!item.isDefaultItem)
        {
            if(items.Count >= space)
            {
                //dont add items to a full inventory
                return false;
            }
            else
            {
                items.Add(item);
                if(onItemChangedCallback != null)
                {
                    onItemChangedCallback.Invoke();
                }
                return true;
            }            
        }
        return false;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        
        if(onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }        
    }
}
