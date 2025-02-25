using _Project.Source.Player;
using UnityEngine;

namespace _Project.Source.Inventory.ItemTypesConfigs
{
    [CreateAssetMenu(menuName = "Configs/Items/New Healing Item")]
    public class HealingItem : Item, IUsable
    {
        public int HealingAmount;
        
        public void Use(PlayerCharacter player)
        {
            player.Hotbar.RemoveItem(this, 1);
            player.Health.Heal(HealingAmount);
        }
    }
}