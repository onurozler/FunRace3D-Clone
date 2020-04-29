using Game.CharacterSystem.Base;
using UnityEngine;
using Zenject;

namespace Game.Managers
{
    public class GameManager : MonoBehaviour
    {

        private CharacterBase _mainCharacter;
        
        [Inject]
        private void OnInitialize(CharacterBase mainCharacter)
        {
            _mainCharacter = mainCharacter;

            InitializeGame();
        }

        private void InitializeGame()
        {
            _mainCharacter.Initialize();
        }
    }
}
