using _Project.Source.Inventory.ItemTypesConfigs;
using UnityEngine;

namespace _Project.Source.Player.Equipment
{
    public class PlayerWeaponSpawner : MonoBehaviour //Не очень название, т.к и спавнит и удаляет
    {
        [SerializeField] private PlayerEquipment _playerEquipment;
        [SerializeField] private Transform _weaponHoldTransform;
        [SerializeField] private Transform _weaponParent;
        
        public GameObject CurrentWeaponObject { get; private set; }

        private void OnEnable()
        {
            _playerEquipment.WeaponEquipped += SpawnWeaponModel;
            _playerEquipment.WeaponUnequipped += DestroyWeaponModel;
        }

        private void OnDisable()
        {
            _playerEquipment.WeaponEquipped -= SpawnWeaponModel;
            _playerEquipment.WeaponUnequipped -= DestroyWeaponModel;
        }

        private void SpawnWeaponModel(Weapon weapon)
        {
            if (CurrentWeaponObject != null)
                Destroy(CurrentWeaponObject); 
            
            if (weapon.Prefab != null)
                CurrentWeaponObject = Instantiate(weapon.Prefab, _weaponHoldTransform.position, _weaponHoldTransform.rotation, _weaponParent);
        }

        private void DestroyWeaponModel()
        {
            if (CurrentWeaponObject != null)
                Destroy(CurrentWeaponObject);
        }
    }
}