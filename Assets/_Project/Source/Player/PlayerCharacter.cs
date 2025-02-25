using _Project.Source.Inventory;
using _Project.Source.PickupObjects;
using _Project.Source.Player.Equipment;
using UnityEngine;
using Zenject;

namespace _Project.Source.Player
{
    public class PlayerCharacter : MonoBehaviour, IItemCollector
    {
        [SerializeField] private Health _health;
        [SerializeField] private PlayerEquipment _equipment;
        [SerializeField] private ItemUsageHandler _itemUsageHandler;
        [SerializeField] private ItemPickupHandler _itemPickupHandler;
        
        public Health Health => _health;
        public Hotbar Hotbar { get; private set; }
        public ItemUsageHandler ItemUsageHandler => _itemUsageHandler;

        [Inject]
        private void Construct(Hotbar hotbar)
        {
            Hotbar = hotbar;
        }

        private void Start()
        {
            _itemPickupHandler.Initialize(this);
        }

        public void CollectItem(PickupObject pickupObject)
        {
            Debug.Log(pickupObject.Item.StackAmount);
            Hotbar.AddItem(pickupObject.Item, pickupObject.Item.AddAmount);
        }
    }
}