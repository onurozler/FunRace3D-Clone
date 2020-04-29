using Game.CharacterSystem.Base;
using Game.LevelSystem.Base;
using Game.LevelSystem.PoolingSystem;
using Game.ObstacleSystem.Base;
using UnityEngine;
using Zenject;

namespace Game.LevelSystem.Controllers
{
    public class LevelGenerator : MonoBehaviour
    {
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
            _currentLevel = new Level(_counter++,LevelLength.SHORT,LevelDifficulty.EASY);
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
                    var obstacle = _levelPoolManager.GetAvailableObstacle(ObstacleType.ROTATING);
                    obstacle.transform.position = new Vector3(obstacle.transform.position.x,obstacle.transform.position.y,lastPosition.z);
                }

                platform = _levelPoolManager.GetAvailablePlatform(PlatformType.CLASSIC);
                platform.transform.position = lastPosition;
                platform.transform.Translate(0,0,increaseAmount + platform.transform.localScale.z / 2);

                lastPosition = platform.transform.position;
                increaseAmount = platform.transform.localScale.z / 2;
                    
                if (i >= (int)_currentLevel.LevelLength-1)
                {
                    // Generate a small platform to make sure obstacles cant collide with finishing
                    platform = _levelPoolManager.GetAvailablePlatform(PlatformType.CLASSIC);
                    platform.transform.localScale = new Vector3(platform.transform.localScale.x,platform.transform.localScale.y,4);
                    platform.transform.position = lastPosition;
                    platform.transform.Translate(0,0,increaseAmount + platform.transform.localScale.z / 2);
                    
                    lastPosition = platform.transform.position;
                    increaseAmount = platform.transform.localScale.z / 2;
                }
                
            }
            
            // Generate Finishing Platform

            platform = _levelPoolManager.GetAvailablePlatform(PlatformType.FINISH);
            platform.transform.position = lastPosition;
            platform.transform.Translate(0,0,increaseAmount + platform.transform.localScale.z / 2);
        }
        
        
    }
}
