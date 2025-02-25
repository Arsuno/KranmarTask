using TMPro;
using UnityEngine;

namespace _Project.Source.UI
{
    public class HealthBarView : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private TMP_Text _label;
        [SerializeField] private GameObject _fillObject;

        private void OnEnable()
        {
            _health.Changed += OnHealthChanged;
        }

        private void OnDisable()
        {
            _health.Changed -= OnHealthChanged;   
        }
        
        private void OnHealthChanged()
        { 
            var scaleValue = _health.CurrentValue / 100f;
            _fillObject.transform.localScale = new Vector3(scaleValue, 1, 1);
            
            if (_label != null)
                _label.text = $"Health: {_health.CurrentValue}/{_health.MaxValue}";
        }
    }
}