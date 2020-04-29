using System.Collections.Generic;
using System.Linq;
using Game.LevelSystem.Base;
using Game.ObstacleSystem.Base;
using UnityEngine;

namespace Game.LevelSystem.Managers
{
    public class AssetManager
    {
        private const string OBSTACLE_PATH = "Obstacles/";
        private const string PLATFORM_PATH = "Platforms/";

        
        private List<ObstacleBase> _obstacles;
        private List<PlatformBase> _platforms;
        
        public AssetManager()
        {
            _obstacles = Resources.LoadAll<ObstacleBase>(OBSTACLE_PATH).ToList();
            _platforms = Resources.LoadAll<PlatformBase>(PLATFORM_PATH).ToList();
        }

        public ObstacleBase GetObstacle(ObstacleType obstacleType)
        {
            return _obstacles?.FirstOrDefault(x => x.ObstacleType == obstacleType);
        }

        public PlatformBase GetPlatform(PlatformType platformType)
        {
            return _platforms?.FirstOrDefault(x=> x.PlatformType == platformType);
        }
        
    }
}
