using System;
using Game.CharacterSystem.Base;
using Game.LevelSystem.Controllers;
using Game.View;
using UnityEngine;
using Zenject;

namespace Game.Managers
{
    public class GameManager : MonoBehaviour
    {
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
            _levelGenerator.GenerateLevel();
        }
    }
}
