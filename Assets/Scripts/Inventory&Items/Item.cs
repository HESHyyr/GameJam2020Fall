using UnityEngine;

namespace GameJam2020
{
    [CreateAssetMenu(menuName = "Inventory&Items/Item")]
    public class Item : ScriptableObject
    {
        [SerializeField] private new string name;
        [SerializeField] private string description;

        public string Name => name;
        public string Description => description;


    }
}