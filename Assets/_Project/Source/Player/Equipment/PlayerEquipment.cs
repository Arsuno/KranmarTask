using System;
using _Project.Source.Inventory.ItemTypesConfigs;
using UnityEngine;

namespace _Project.Source.Player.Equipment
{
    public class PlayerEquipment : MonoBehaviour
    {
        private Weapon _equippedWeapon;
        
        [SerializeField] private ItemUsageHandler _itemUsageHandler;
        
        public event Action<Weapon> WeaponEquipped;
        public event Action WeaponUnequipped;

        private void Start()
        {
            _itemUsageHandler.OnWeaponItemUsed += EquipWeapon;
        }

        private void OnDestroy()
        {
            _itemUsageHandler.OnWeaponItemUsed -= EquipWeapon;
        }

        private void EquipWeapon(Weapon weapon)
        {
            if (_equippedWeapon == weapon)
            {
                UnequipWeapon();
                return;
            }

            _equippedWeapon = weapon;
            WeaponEquipped?.Invoke(weapon);
        }

        private void UnequipWeapon()
        {
            if (_equippedWeapon == null) return;
            
            _equippedWeapon = null;
            WeaponUnequipped?.Invoke();
        }
    }
}