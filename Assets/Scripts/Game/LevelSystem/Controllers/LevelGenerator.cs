using Game.CharacterSystem.Base;
using Game.LevelSystem.Base;
using Game.LevelSystem.PoolingSystem;
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
        private Vector3 _startingPoint;
        
        [Inject]
        private void OnInitialize(LevelPoolManager levelPoolManager, CharacterBase characterBase)
        {
            _mainCharacter = characterBase;
            _levelPoolManager = levelPoolManager;
            
            _startingPoint = new Vector3(0,-1,-5);
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
            var spawnerPlatform = _levelPoolManager.GetAvailablePlatform(PlatformType.CLASSIC);
            spawnerPlatform.transform.position = _startingPoint;
            _mainCharacter.transform.position = spawnerPlatform.transform.position;
            Vector3 lastPosition = _startingPoint * spawnerPlatform.transform.localScale.z;
            
            // Generate Other Parts with Obstacles
            for (int i = 0; i < (int)_currentLevel.LevelLength; i++)
            {
                int obstacleProbability = Random.Range(0, 100);
                if (obstacleProbability < (int)_currentLevel.LevelDifficulty)
                {
                    Debug.Log("Test");
                }
                else
                {
                    
                }
            }
            
            // Generate Finishing Platform
        }
        
        
    }
}
