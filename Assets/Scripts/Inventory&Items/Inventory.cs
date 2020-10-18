using System.Collections.Generic;
using UnityEngine;

namespace GameJam2020
{
    [CreateAssetMenu(menuName = "Inventory&Items/Inventory")]
    public class Inventory : ScriptableObject
    {
        [SerializeField] private List<Item> items = new List<Item>();
        private List<Item> trash = new List<Item>();

        public List<Item> Items => items;

        public void AddItem(Item item)
        {
            if(items.Contains(item))
                return;
            items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            if (!items.Contains(item))
                return;
            items.Remove(item);
            trash.Add(item);
        }

        public void ClearInventory()
        {
            items.Clear();
        }

        public bool ContainsItem(Item item, bool everHadItem = false)
        {
            if(everHadItem)
                return items.Contains(item) || trash.Contains(item);
            else
                return items.Contains(item);
            
        }

    }
}