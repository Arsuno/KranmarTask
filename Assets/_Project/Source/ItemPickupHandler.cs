using _Project.Source.PickupObjects;
using _Project.Source.Player;
using UnityEngine;

namespace _Project.Source
{
    public class ItemPickupHandler : MonoBehaviour
    {
        private IItemCollector _itemCollector;
        
        public void Initialize(IItemCollector itemCollector)
        {
            _itemCollector = itemCollector;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out PickupObject pickupObject))
            {
                Debug.Log("Try pickup object");
                TryPickup(pickupObject);
            }
        }
        
        private void TryPickup(PickupObject pickupObject)
        {
            pickupObject.Interact(_itemCollector);
        }
    }
}