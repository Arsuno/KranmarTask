using System;
using System.Collections.Generic;
using _Project.Source.Data;
using _Project.Source.Inventory.Configs;
using _Project.Source.Inventory.ItemTypesConfigs;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace _Project.Source.Inventory
{
    public class Hotbar : MonoBehaviour
    {
        private readonly List<HotbarSlot> _slots = new();
        
        private int _slotCount;
        private GameData _loadedData;
        
        [SerializeField] private HotbarConfig _config;
        
        public event Action<List<HotbarSlot>> HotbarSlotsChanged;
        public event Action<Item> ItemUsed;
        public event Action Changed;
        
        public List<HotbarSlot> Slots => _slots;
        
        [Inject]
        private void InitializeAfterInject()
        {
            Initialize(_loadedData);
        }
    
        private void Update()
        {
            for (int i = 0; i < _slotCount; i++)
            {
                Key key = (Key)((int)Key.Digit1 + i);
                
                if (Keyboard.current[key].wasPressedThisFrame)
                    SelectSlot(i);
            }
        }
        
        public void SetGameData(GameData data)
        {
            _loadedData = data;
        }

        public List<HotbarSlotData> GetData()
        {
            List<HotbarSlotData> data = new();

            foreach (var slot in _slots)
            {
                data.Add(new HotbarSlotData()
                {
                    Item = slot.Item,
                    ItemAmount = slot.ItemAmount,
                });
            }
            
            return data;
        }
        
        public void AddItem(Item item, int amount)
        {
            foreach (var slot in _slots)
            {
                if (slot.Item == item)
                {
                    slot.AddItemAmount(amount);
                    HotbarSlotsChanged?.Invoke(_slots);
                    Changed?.Invoke();
                    
                    return;
                }
            }
            
            foreach (var slot in _slots)
            {
                if (slot.Item == null)
                {
                    slot.AssignItem(item, item.StartAmount);
                    HotbarSlotsChanged?.Invoke(_slots);
                    Changed?.Invoke();
                    
                    return;
                }
            }

            Debug.Log("Hotbar is full!");
        }

        public void RemoveItem(Item item, int amount)
        {
            foreach (var slot in _slots)
            {
                if (slot.Item == item)
                {
                    slot.RemoveItemAmount(amount);
                    HotbarSlotsChanged?.Invoke(_slots);
                    Changed?.Invoke();
                    
                    return;
                }
            }
        }

        public int GetItemAmount(Item item)
        {
            foreach (var slot in _slots)
            {
                if (slot.Item == item)
                    return slot.ItemAmount;
            }

            return 0;
        }
    
        private void SelectSlot(int index)
        {
            if (index < 0 || index >= _slotCount) return;
            
            if (_slots[index].Item != null)
                ItemUsed?.Invoke(_slots[index].Item);
        }
        
        private void Initialize(GameData data)
        {
            Debug.Log("Initializing Hotbar with data: " + data);
            
            _slots.Clear();
            _slotCount = _config.SlotsAmount;
            
            if (data == null)
            {
                Debug.Log("No save data, using default items.");
                
                if (_config.StartItems.Length <= 0) return;
            
                for (var i = 0; i < _slotCount; i++)
                {
                    _slots.Add(new HotbarSlot());

                    if (i < _config.StartItems.Length)
                        _slots[i].AssignItem(_config.StartItems[i], _config.StartItems[i].StartAmount);
                }
            }
            else
            {
                Debug.Log($"Loading {data.HotbarSlots.Count} slots from save");
                
                for (var i = 0; i < _slotCount; i++)
                {
                    if (i < data.HotbarSlots.Count)
                    {
                        _slots.Add(new HotbarSlot());
                        _slots[i].AssignItem(data.HotbarSlots[i].Item, data.HotbarSlots[i].ItemAmount);
                    }
                }
            }
            
            HotbarSlotsChanged?.Invoke(_slots);
        }
    }
}