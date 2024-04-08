using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IInvetoryObserver
{
    private Item[] _items = new Item[16];

    public void AddItem(Item item)
    {
        for (int i = 0; i < _items.Length; i++)
        {
            if (_items[i] == null)
            {
                _items[i] = item;
                break;  
            }
        }
    }
}
