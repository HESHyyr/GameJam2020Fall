using UnityEngine;

namespace GameJam2020
{
    [CreateAssetMenu(menuName = "Inventory&Items/Item")]
    public class Item : ScriptableObject
    {
        [SerializeField] private new string name;
        [SerializeField, TextArea(3, 5)] private string description;
        [SerializeField] private Sprite sprite;

        public string Name => name;
        public string Description => description;
        public Sprite Sprite => sprite;

    }
}