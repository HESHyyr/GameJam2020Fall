using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameJam2020 {
    public class ItemPickup : MonoBehaviour
    {

        [SerializeField] Inventory playerInventory;
        [SerializeField] Item item;

        

        void Start()
        {

            if (playerInventory.ContainsItem(item, true))
            {
                Destroy(gameObject);
            }
        }

        public void OnPressed()
        {
            playerInventory.AddItem(item);
            ActionLogManager.LogActionStatic("Picked up <color=red>" + item.Name + ".");
            Destroy(gameObject);
        }
    }
}