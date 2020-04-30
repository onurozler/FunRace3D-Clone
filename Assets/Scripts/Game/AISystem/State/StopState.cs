
using Game.AISystem.Base;
using UnityEngine;

namespace Game.AISystem.State
{
    public class StopState : IAIState
    {
        private AICharacter _aiCharacter;
        
        public StopState(AICharacter character)
        {
            _aiCharacter = character;
        }

        public void OnEnter()
        {
            _aiCharacter.Stop();
        }

        public void OnUpdate()
        {
            if (!_aiCharacter.ObstacleDetector.IsHit())
            {
                _aiCharacter.ChangeState(_aiCharacter.RunState);
            }
        }
    }
}
