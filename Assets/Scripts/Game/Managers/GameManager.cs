using System;
using Game.CharacterSystem.Base;
using Game.LevelSystem.Controllers;
using UnityEngine;
using Zenject;

namespace Game.Managers
{
    public class GameManager : MonoBehaviour
    {
        private CharacterBase _mainCharacter;
        private LevelGenerator _levelGenerator;
        
        [Inject]
        private void OnInitialize(CharacterBase mainCharacter, LevelGenerator levelGenerator)
        {
            _mainCharacter = mainCharacter;
            _levelGenerator = levelGenerator;
        }

        private void Start()
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            _mainCharacter.Initialize();
            _levelGenerator.GenerateLevel();
        }
    }
}
