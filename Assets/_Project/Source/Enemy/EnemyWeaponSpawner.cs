using _Project.Source.Inventory.ItemTypesConfigs;
using UnityEngine;

namespace _Project.Source.Enemy
{
    public class EnemyWeaponSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _weaponHoldTransform;
        [SerializeField] private Transform _weaponParent;

        public GameObject CurrentWeaponObject { get; set; }
        
        public void SpawnWeaponModel(Weapon weapon)
        {
            if (CurrentWeaponObject != null)
                Destroy(CurrentWeaponObject); 
            
            if (weapon.Prefab != null)
                CurrentWeaponObject = Instantiate(weapon.Prefab, _weaponHoldTransform.position, _weaponHoldTransform.rotation, _weaponParent);
        }
    }
}