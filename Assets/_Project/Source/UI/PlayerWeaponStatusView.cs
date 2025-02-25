using _Project.Source.Player.Shooting;
using TMPro;
using UnityEngine;

namespace _Project.Source.UI
{
    public class PlayerWeaponStatusView : MonoBehaviour
    {
        [SerializeField] private PlayerShootingController _playerShootingController;
        [SerializeField] private TMP_Text _labelAmmoCount;

        private void OnEnable()
        {
            _playerShootingController.ReloadingStarted += OnReloadingStartedStarted;
            _playerShootingController.AmmoAmountChanged += OnAmmoAmountChanged;
            _playerShootingController.WeaponUnequipped += OnWeaponUnequipped;
        }

        private void OnDisable()
        {
            _playerShootingController.ReloadingStarted -= OnReloadingStartedStarted;
            _playerShootingController.AmmoAmountChanged -= OnAmmoAmountChanged;
            _playerShootingController.WeaponUnequipped -= OnWeaponUnequipped;
        }
        
        private void OnAmmoAmountChanged(int currentAmmo, int maxAmmo)
        {
            _labelAmmoCount.text = $"Ammo: {currentAmmo}/{maxAmmo}";
        }
        
        private void OnReloadingStartedStarted()
        {
            _labelAmmoCount.text = "Reloading...";
        }
        
        private void OnWeaponUnequipped()
        {
            _labelAmmoCount.text = "Weapon Unequipped";
        }
    }
}