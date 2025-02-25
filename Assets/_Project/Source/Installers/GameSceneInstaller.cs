using _Project.Source.Data;
using _Project.Source.Inventory;
using _Project.Source.SaveLoadSystems;
using UnityEngine;
using Zenject;

namespace _Project.Source.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private Hotbar _hotbar;
        
        public override void InstallBindings()
        {
            ISaveLoadSystem saveLoadService = new JSONSaveLoadSystem();
            var data = saveLoadService.Load<GameData>();

            Container.Bind<ISaveLoadSystem>().FromInstance(saveLoadService).AsSingle();
            Container.Bind<Hotbar>().FromInstance(_hotbar).AsSingle().NonLazy();

            _hotbar.SetGameData(data);
        }
    }
}