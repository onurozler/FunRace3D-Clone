using Game.CharacterSystem.Base;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField]
        private CharacterBase _mainCharacter;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_mainCharacter).AsSingle().NonLazy();
        }
    }
}