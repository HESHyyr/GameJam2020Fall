using GameJam2020;
using SpookuleleGames.ServiceLocator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LockedObject : MonoBehaviour
{
    [SerializeField] private string typicalResponse;
    [SerializeField] private Item requiredItem;
    [SerializeField] private UnityEvent action;

    public void TryUnlock()
    {
        Item equippedItem = InventoryPanel.CurrentlySelectedItem();

        if(equippedItem == null)
        {
            ActionLogManager.LogActionStatic(typicalResponse);
        } else if(equippedItem != requiredItem)
        {
            ActionLogManager.LogActionStatic("It didn't have any effect.");
        } else
        {
            InventoryPanel.UnEquipStatic();
            ServiceLocator.GetService<Inventory>().RemoveItem(requiredItem);
            action.Invoke();
        }
    }

}
