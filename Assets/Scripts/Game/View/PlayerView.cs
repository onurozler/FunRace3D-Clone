using Game.CharacterSystem.Base;
using Game.CharacterSystem.Events;
using Game.LevelSystem.Base;
using Game.LevelSystem.Controllers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.View
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Text _levelInfo;
        [SerializeField] private Text _playerInfo;

        private CharacterBase _mainCharacter;
        private LevelGenerator _levelGenerator;
        
        [Inject]
        private void OnInitialize(CharacterBase characterBase, LevelGenerator levelGenerator)
        {
            _levelGenerator = levelGenerator;
            _mainCharacter = characterBase;
        }

        public void Initialize()
        {
            _mainCharacter.GetEventManager().SubscribeEvent(CharacterEventType.ON_STARTED, UpdatePlayerHealth);
            _mainCharacter.GetEventManager().SubscribeEvent(CharacterEventType.ON_DEATH, UpdatePlayerHealth);

            _levelGenerator.OnLevelGenerated += UpdateLevelInfo;
        }
        
        public void UpdateLevelInfo(Level level)
        {
            _levelInfo.text =
                $"Level Index : {level.LevelIndex} \nLevel Length : {level.LevelLength} \nLevel Difficulty : {level.LevelDifficulty}";
        }

        public void UpdatePlayerHealth()
        {
            _playerInfo.text = "Player Health : " + _mainCharacter.PlayerHealth;
        }
    }
}
