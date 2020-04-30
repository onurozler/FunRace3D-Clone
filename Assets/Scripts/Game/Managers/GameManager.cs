using System;
using Game.AISystem.Base;
using Game.CharacterSystem.Base;
using Game.CharacterSystem.Events;
using Game.LevelSystem.Controllers;
using Game.View;
using UnityEngine;
using Zenject;

namespace Game.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private AICharacter _aiCharacter;
        
        private CharacterBase _mainCharacter;
        private PlayerView _playerView;
        private LevelGenerator _levelGenerator;
        
        [Inject]
        private void OnInitialize(CharacterBase mainCharacter, LevelGenerator levelGenerator, PlayerView playerView)
        {
            _mainCharacter = mainCharacter;
            _levelGenerator = levelGenerator;
            _playerView = playerView;
        }

        private void Start()
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            _mainCharacter.Initialize();
            _playerView.Initialize();
            _levelGenerator.Initialize();
            
            _aiCharacter.Initialize();
        }
    }
}
