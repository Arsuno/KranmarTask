using UnityEngine;

namespace _Project.Source.Player.Shooting
{
    public class WeaponFirePoint : MonoBehaviour
    {
        [SerializeField] private Transform _position;
        
        public Transform Position => _position;
    }
}