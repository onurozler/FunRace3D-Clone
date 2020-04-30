using Game.AISystem.Base;
using UnityEngine;

namespace Game.AISystem.State
{
    public class RunState : IAIState
    {
        private AICharacter _aiCharacter;

        public RunState(AICharacter character)
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
                _aiCharacter.Move();
            }
            else
            {
                _aiCharacter.ChangeState(_aiCharacter.StopState);
            }
        }
        
    }
}
