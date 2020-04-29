using System;
using Config;
using Game.CharacterSystem.Base;
using Game.CharacterSystem.Events;
using Game.LevelSystem.Base;
using Game.LevelSystem.PoolingSystem;
using Game.ObstacleSystem.Base;
using UnityEngine;
using Utils;
using Zenject;
using Random = UnityEngine.Random;

namespace Game.LevelSystem.Controllers
{
    public class LevelGenerator : MonoBehaviour
    {
        public Action<Level> OnLevelGenerated;
        
        private static int _counter;
        
        private Level _currentLevel;
        private CharacterBase _mainCharacter;
        private LevelPoolManager _levelPoolManager;
        private Vector3 _startingPosition;
        
        [Inject]
        private void OnInitialize(LevelPoolManager levelPoolManager, CharacterBase characterBase)
        {
            _mainCharacter = characterBase;
            _levelPoolManager = levelPoolManager;
            
            _startingPosition = new Vector3(0,-1,-5);
            _currentLevel = null;
            _counter = 0;
        }

        private void SelectLevelSettings()
        {
            LevelLength levelLength = GameConfig.GetLevelLength(_counter);
            LevelDifficulty levelDifficulty = GameConfig.GetLevelDifficulty(_counter);
            
            _currentLevel = new Level(_counter++,levelLength,levelDifficulty);
        }
        
        public void GenerateLevel()
        {
            SelectLevelSettings();
            
            // Firstly Generate Spawner Platform and Put Character middle of it.
            var platform = _levelPoolManager.GetAvailablePlatform(PlatformType.CLASSIC);
            platform.transform.position = _startingPosition;
            _mainCharacter.transform.position = platform.transform.position;
            Vector3 lastPosition = _startingPosition;
            float increaseAmount = platform.transform.localScale.z / 2;
            
            
            // Generate Other Parts with Obstacles
            for (int i = 0; i < (int)_currentLevel.LevelLength; i++)
            {
                int obstacleProbability = Random.Range(0, 100);
                if (obstacleProbability < (int)_currentLevel.LevelDifficulty && i > 0)
                {
                    int rndObstacle = Random.Range(0, 2);
                    var obstacle = _levelPoolManager.GetAvailableObstacle((ObstacleType)rndObstacle);
                    obstacle.transform.position = new Vector3(obstacle.transform.position.x,obstacle.transform.position.y,lastPosition.z);
                }

                platform = _levelPoolManager.GetAvailablePlatform(PlatformType.CLASSIC);
                UpdateObjectPosition(platform.transform,ref lastPosition,ref increaseAmount);

                // Generate a small platform to make sure obstacles cant collide with finishing
                if (i >= (int)_currentLevel.LevelLength-1)
                {
                    platform = _levelPoolManager.GetAvailablePlatform(PlatformType.CLASSIC);
                    platform.transform.localScale = new Vector3(platform.transform.localScale.x,platform.transform.localScale.y,4);
                    UpdateObjectPosition(platform.transform,ref lastPosition,ref increaseAmount);
                }
                
            }
            
            // Generate Finishing Platform

            platform = _levelPoolManager.GetAvailablePlatform(PlatformType.FINISH);
            UpdateObjectPosition(platform.transform,ref lastPosition,ref increaseAmount);
            
            OnLevelGenerated.SafeInvoke(_currentLevel);
            
            _mainCharacter.GetEventManager().InvokeEvent(CharacterEventType.ON_STARTED);
        }

        private void UpdateObjectPosition(Transform objTransform, ref Vector3 lastposition,ref float increaseAmount)
        {
            var cachedObjTransform = objTransform.transform;
            cachedObjTransform.position = lastposition;
            cachedObjTransform.Translate(0,0,increaseAmount + cachedObjTransform.localScale.z / 2);
            
            lastposition = cachedObjTransform.transform.position;
            increaseAmount = cachedObjTransform.localScale.z / 2;
        }
    }
    
}
