using System.Collections.Generic;
using System.Linq;
using Game.LevelSystem.Base;
using Game.LevelSystem.Managers;
using Game.ObstacleSystem.Base;
using UnityEngine;
using Zenject;

namespace Game.LevelSystem.PoolingSystem
{
    public class LevelPoolManager : MonoBehaviour
    {
        private AssetManager _assetManager;
        
        private List<PlatformBase> _platformBases;
        private List<ObstacleBase> _obstacleBases;

        [Inject]
        private void OnInitialize(AssetManager assetManager)
        {
            _assetManager = assetManager;
            
            _platformBases = new List<PlatformBase>();
            _obstacleBases = new List<ObstacleBase>();
            //_platformBases = GetComponentsInChildren<PlatformBase>()?.ToList();
            //_obstacleBases = GetComponentsInChildren<ObstacleBase>()?.ToList();
        }

        public PlatformBase GetAvailablePlatform(PlatformType platformType)
        {
            var platform = _platformBases?.FirstOrDefault(x => x.PlatformType == platformType && !x.Active);
            if (platform == null)
            {
                platform = Instantiate(_assetManager.GetPlatform(platformType));
                platform.transform.SetParent(transform);
                _platformBases.Add(platform);
            }
            
            platform.Activate();
            return platform;
        }

        public ObstacleBase GetAvailableObstacle(ObstacleType obstacleType)
        {
            var obstacle = _obstacleBases?.FirstOrDefault(x => x.ObstacleType == obstacleType && !x.Active);
            if (obstacle == null)
            {
                obstacle = Instantiate(_assetManager.GetObstacle(obstacleType));
                obstacle.Initialize();
                obstacle.transform.SetParent(transform);
                _obstacleBases.Add(obstacle);
            }
            
            obstacle.Activate();
            return obstacle;
        }


        public void DeactivateWholePool()
        {
            foreach (var platform in _platformBases)
            {
                platform.Deactivate();
            }

            foreach (var obstacleBase in _obstacleBases)
            {
                obstacleBase.Deactivate();
            }
        }
    }
}
