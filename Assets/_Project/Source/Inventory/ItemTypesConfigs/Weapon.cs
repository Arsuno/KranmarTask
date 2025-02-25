using _Project.Source.Player;
using _Project.Source.Player.Shooting;
using UnityEngine;

namespace _Project.Source.Inventory.ItemTypesConfigs
{
    [CreateAssetMenu(menuName = "Configs/Items/New Weapon")]
    public class Weapon : Inventory.ItemTypesConfigs.Item, IUsable
    {
        public int AmmoCapacity;
        public int Damage;
        public float ReloadSpeed;
        public float FireRate;
        public GameObject Prefab;
        public Projectile ProjectilePrefab;
        public float ProjectileLifeTime;
        public ConsumableItem AmmoType;
        
        public void Use(PlayerCharacter player)
        {
            player.ItemUsageHandler.UseWeapon(this);
        }
    }
}