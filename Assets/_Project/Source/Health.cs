using System;
using UnityEngine;

namespace _Project.Source
{
    public class Health : MonoBehaviour
    {
        private int _value = 100;
        
        [SerializeField] private int _maxValue;

        public event Action Changed;
        
        public int CurrentValue => _value;
        public int MaxValue => _maxValue;

        public void GetDamage(int value)
        {
            Debug.Log(gameObject.name + " was damaged");
            
            if (_value - value > 0)
            {
                _value -= value;
                Changed?.Invoke();
            }
            else
            {
                Changed?.Invoke();
                Destroy(gameObject);
            }
        }

        public void Heal(int value)
        {
            Debug.Log(gameObject.name + " was healed");
            
            if (_value + value <= _maxValue)
            {
                _value += value;
                Changed?.Invoke();
            }
        }
    }
}