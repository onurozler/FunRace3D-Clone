using Game.CharacterSystem.Base;
using Game.LevelSystem.PoolingSystem;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField]
        private CharacterBase _mainCharacter;
        [SerializeField]
        private LevelPoolManager _levelPoolManager;

        
        public override void InstallBindings()
        {
            Container.BindInstance(_mainCharacter).AsSingle().NonLazy();
            Container.BindInstance(_levelPoolManager).AsSingle().NonLazy();
        }
    }
}