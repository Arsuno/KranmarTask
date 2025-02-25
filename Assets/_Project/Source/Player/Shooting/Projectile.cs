using System;
using UnityEngine;

namespace _Project.Source.Player.Shooting
{
    public class Projectile : MonoBehaviour
    {
        private int _damage;
        private float _speed;
        private Vector3 _direction;
        private float _elapsedTime;
        private float _lifeTime;
        
        [SerializeField] private Rigidbody _rigidbody;
        
        public event Action<Projectile> ReachedTarget; 

        public void Initialize(int damage, float speed, Vector3 direction, float lifetime)
        {
            _damage = damage;
            _speed = speed;
            _direction = direction;
            _elapsedTime = 0f;
            _lifeTime = lifetime;
            
            _rigidbody.velocity = _direction * _speed;
        }

        private void FixedUpdate()
        {
            if (_elapsedTime < _lifeTime)
                _elapsedTime += Time.fixedDeltaTime;
            else
                ReachedTarget?.Invoke(this);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Health targetHealth))
            {
                Debug.Log("Пуля попала в " + other.gameObject.name);
                targetHealth.GetDamage(_damage);
            }
        
            ReachedTarget?.Invoke(this);
        }
    }
}