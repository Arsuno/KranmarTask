using _Project.Source.Data;
using _Project.Source.Inventory;
using UnityEngine;
using Zenject;

namespace _Project.Source.SaveLoadSystems
{
    public class GameSaveController : MonoBehaviour
    {
        private ISaveLoadSystem _saveLoadSystem;
        private Hotbar _hotbar;

        [Inject]
        public void Construct(ISaveLoadSystem saveLoadSystem, Hotbar hotbar)
        {
            _saveLoadSystem = saveLoadSystem;
            _hotbar = hotbar;
        }

        private void OnEnable()
        {
            _hotbar.Changed += SaveGame;
        }

        private void OnDisable()
        {
            _hotbar.Changed -= SaveGame;
        }

        private void SaveGame()
        {
            var data = CollectGameData();
            _saveLoadSystem.Save(data);
        }

        private GameData CollectGameData()
        {
            var data = new GameData()
            {
                HotbarSlots = _hotbar.GetData()
            };
            
            return data;
        }
    }
}