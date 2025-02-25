using UnityEngine;

namespace _Project.Source.Inventory.Configs
{
    [CreateAssetMenu(fileName = "HotbarConfig", menuName = "Configs/Hotbar Config")]
    public class HotbarConfig : ScriptableObject
    {
        public int SlotsAmount;
        public ItemTypesConfigs.Item[] StartItems;
    }
}