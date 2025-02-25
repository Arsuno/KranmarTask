using UnityEngine;

namespace _Project.Source.Inventory.ItemTypesConfigs
{
    public class Item : ScriptableObject
    {
        public Sprite Icon;
        public int StartAmount;
        public int AddAmount;
        public int StackAmount;
    }
}
