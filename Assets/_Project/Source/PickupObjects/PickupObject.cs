using System.Collections;
using _Project.Source.Inventory.ItemTypesConfigs;
using _Project.Source.Player;
using UnityEngine;

namespace _Project.Source.PickupObjects
{
    public class PickupObject : MonoBehaviour, IInteractable
    {
        [SerializeField] private Item _item;
        [SerializeField] private GameObject _interactableObject;
        [SerializeField] private BoxCollider _collider;
        [SerializeField] private float _respawnTime;
        
        public Item Item => _item;
        
        public void Interact(IItemCollector collector)
        {
            collector.CollectItem(this);
            _collider.enabled = false;
            _interactableObject.SetActive(false);
            StartCoroutine(WaitForRespawn());
        }

        private IEnumerator WaitForRespawn()
        {
            yield return new WaitForSeconds(_respawnTime);
            _interactableObject.SetActive(true);
            _collider.enabled = true;
        }
    }
}