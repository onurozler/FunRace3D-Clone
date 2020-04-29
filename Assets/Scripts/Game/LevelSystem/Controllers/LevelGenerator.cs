using Game.LevelSystem.Managers;
using Game.LevelSystem.PoolingSystem;
using UnityEngine;
using Zenject;

namespace Game.LevelSystem.Controllers
{
    public class LevelGenerator : MonoBehaviour
    {
        private LevelPoolManager _levelPoolManager;
        private AssetManager _assetManager;
        
        [Inject]
        private void OnInitialize(LevelPoolManager levelPoolManager, AssetManager assetManager)
        {
            _levelPoolManager = levelPoolManager;
            _assetManager = assetManager;
        }
    }
}
