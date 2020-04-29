using System.Collections.Generic;
using System.Linq;
using Game.LevelSystem.Base;
using Game.ObstacleSystem.Base;
using UnityEngine;

namespace Game.LevelSystem.PoolingSystem
{
    public class LevelPoolManager : MonoBehaviour
    {
        private List<PlatformBase> _platformBases;
        private List<ObstacleBase> _obstacleBases;

        private void Awake()
        {
            _platformBases = GetComponentsInChildren<PlatformBase>()?.ToList();
            _obstacleBases = GetComponentsInChildren<ObstacleBase>()?.ToList();
        }
    }
}
