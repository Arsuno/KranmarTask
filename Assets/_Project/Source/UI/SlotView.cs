using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Source.UI
{
    public class SlotView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _label;

        private void OnEnable()
        {
            _image.gameObject.SetActive(false);
            _label.gameObject.SetActive(false);
        }

        public void SetIcon(Sprite icon)
        {
            _image.gameObject.SetActive(true);
            _image.sprite = icon;
        }

        public void SetAmountTextValue(int amount)
        {
            if (amount > 1)
            {
                _label.gameObject.SetActive(true);
                _label.text = amount.ToString();    
            }
        }
    }
}