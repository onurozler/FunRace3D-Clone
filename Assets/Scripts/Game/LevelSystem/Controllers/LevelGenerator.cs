using Game.LevelSystem.PoolingSystem;
using UnityEngine;
using Zenject;

namespace Game.LevelSystem.Controllers
{
    public class LevelGenerator : MonoBehaviour
    {
        private LevelPoolManager _levelPoolManager;
        
        [Inject]
        private void OnInitialize(LevelPoolManager levelPoolManager)
        {
            _levelPoolManager = levelPoolManager;
        }
    }
}
