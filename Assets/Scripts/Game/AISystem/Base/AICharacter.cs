using System;
using Game.AISystem.ObstacleDetection;
using Game.AISystem.State;
using Game.CharacterSystem.Base;
using Game.CharacterSystem.Events;

namespace Game.AISystem.Base
{
    public class AICharacter : CharacterBase
    {
        private IAIState _currentState;

        public bool IsFinished;
        public ObstacleDetector ObstacleDetector;
        public IAIState RunState;
        public IAIState StopState;

        public override void Initialize()
        {
            base.Initialize();

            ObstacleDetector = GetComponent<ObstacleDetector>();
            IsFinished = false;
            RunState = new RunState(this);
            StopState =new StopState(this);

            _currentState = StopState;
            _currentState.OnEnter();
            
            GetEventManager().SubscribeEvent(CharacterEventType.ON_FINISHED, () =>
            {
                ChangeState(StopState);
                IsFinished = true;
            });

        }

        private void FixedUpdate()
        {
            if(_currentState == null || IsFinished)
                return;
            
            _currentState.OnUpdate();
        }

        public void Stop()
        {
            _characterAnimatorController.PerformIdleAnimation();
        }

        public void Move()
        {
            _characterMovementController.Move();
            _characterAnimatorController.PerformRunAnimation();
        }
        
        public void ChangeState(IAIState state)
        {
            _currentState = state;
            _currentState.OnEnter();
        }
    }
}
