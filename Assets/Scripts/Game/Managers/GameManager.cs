using Game.CharacterSystem.Base;
using UnityEngine;

namespace Game.Managers
{
    public class GameManager : MonoBehaviour
    {
        private void Awake()
        {
            var character = FindObjectOfType<CharacterBase>();
            character.Initialize();
        }
    }
}
