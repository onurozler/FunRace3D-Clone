using System.Linq;
using Config;
using Game.CharacterSystem.Controllers;
using Game.CharacterSystem.Events;
using Game.CharacterSystem.Managers;
using UnityEngine;
using Utils;

namespace Game.CharacterSystem.Base
{
    public class CharacterBase : MonoBehaviour
    {
        public int PlayerHealth;

        #region Managers

        private CharacterPhysicsManager _characterPhysicsManager;
        private CharacterEventManager _characterEventManager;

        #endregion

        #region Controllers
        
        protected CharacterMovementController _characterMovementController;
        protected CharacterPhysicsController _characterPhysicsController;
        protected CharacterAnimatorController _characterAnimatorController;
        
        #endregion



        public virtual void Initialize()
        {
            PlayerHealth = 3;
            
            var ragdollJoints = GetComponentsInChildren<Rigidbody>().Where(x => x.gameObject != gameObject).ToList();
            var mainRigidbody = GetComponent<Rigidbody>();
            var animator = GetComponent<Animator>();
            
            _characterEventManager = new CharacterEventManager();
            _characterPhysicsManager = new CharacterPhysicsManager(ragdollJoints,mainRigidbody);
            
            _characterAnimatorController = new CharacterAnimatorController(animator);
            _characterPhysicsController = gameObject.AddComponent<CharacterPhysicsController>();
            _characterMovementController = gameObject.AddComponent<CharacterMovementController>();

            _characterMovementController.Initialize(transform,GameConfig.CHARACTER_SPEED);
            _characterPhysicsController.Initialize(_characterPhysicsManager,_characterEventManager);

            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            // Character Event Subscriptions

            _characterEventManager.SubscribeEvent(CharacterEventType.ON_STARTED, OnStarted);
            _characterEventManager.SubscribeEvent(CharacterEventType.ON_FINISHED, OnFinished);
            _characterEventManager.SubscribeEvent(CharacterEventType.ON_DEATH, OnDeath);
            _characterEventManager.SubscribeEvent(CharacterEventType.ON_RESTARTED, OnRestart);
        }


        public CharacterEventManager GetEventManager()
        {
            return _characterEventManager;
        }
        
        
        #region EventMethods

        private void OnStarted()
        {
            PlayerHealth = 3;
        }
        
        private void OnFinished()
        {
            _characterAnimatorController.PerformIdleAnimation();
        }
        
        private void OnDeath()
        {
            _characterAnimatorController.DeactivateAnimator();
            PlayerHealth--;
            _characterEventManager.InvokeEvent(CharacterEventType.ON_RESTARTED);
        }
        
        private void OnRestart()
        {
            Timer.Instance.TimerWait(1f, () =>
            {
                _characterAnimatorController.ActivateAnimator();
                if (PlayerHealth < 1)
                {
                    _characterPhysicsController.ResetPhysics();
                    _characterEventManager.InvokeEvent(CharacterEventType.ON_STARTED);
                }
                else
                {
                    _characterPhysicsController.RevertPhysics();
                }
            });
        }
        
        #endregion
    }
}
