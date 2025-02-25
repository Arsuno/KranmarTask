using System;
using _Project.Source.Inventory;
using _Project.Source.Inventory.ItemTypesConfigs;
using UnityEngine;
using Zenject;

namespace _Project.Source.Player.Equipment
{
    public class ItemUsageHandler : MonoBehaviour
    {
        private Hotbar _hotbar;
        
        [SerializeField] private PlayerCharacter _playerCharacter;
        
        public event Action<Weapon> OnWeaponItemUsed; 

        [Inject]
        public void Construct(Hotbar hotbar)
        {
            _hotbar = hotbar;
        }
        
        private void Start()
        {
            if (_hotbar != null)
                _hotbar.ItemUsed += ItemUsed;
        }

        private void OnDestroy()
        {
            if (_hotbar != null)
                _hotbar.ItemUsed -= ItemUsed;
        }
        
        public void UseWeapon(Weapon weapon)
        {
            OnWeaponItemUsed?.Invoke(weapon);
        }
    
        private void ItemUsed(Item item)
        {
            if (item is IUsable usableItem)
            {
                Debug.Log("Player character " + _playerCharacter);
                usableItem.Use(_playerCharacter);
            }
        }
    }
}