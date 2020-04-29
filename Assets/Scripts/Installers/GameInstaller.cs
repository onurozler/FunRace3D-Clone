using Game.CharacterSystem.Base;
using Game.LevelSystem.Controllers;
using Game.LevelSystem.Managers;
using Game.LevelSystem.PoolingSystem;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private CharacterBase _mainCharacter;
        [SerializeField] private LevelPoolManager _levelPoolManager;
        [SerializeField] private LevelGenerator _levelGenerator;

        
        public override void InstallBindings()
        {
            Container.BindInstance(_mainCharacter).AsSingle().NonLazy();
            Container.BindInstance(_levelPoolManager).AsSingle().NonLazy();
            Container.BindInstance(_levelGenerator).AsSingle().NonLazy();
            
            Container.Bind<AssetManager>().AsSingle().NonLazy();
        }
    }
}