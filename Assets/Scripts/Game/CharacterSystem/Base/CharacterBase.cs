using System.Linq;
using Game.CharacterSystem.Controllers;
using Game.CharacterSystem.Events;
using Game.CharacterSystem.Managers;
using UnityEngine;
using Utils;

namespace Game.CharacterSystem.Base
{
    public class CharacterBase : MonoBehaviour
    {

        #region Managers

        private CharacterPhysicsManager _characterPhysicsManager;
        private CharacterEventManager _characterEventManager;

        #endregion

        #region Controllers
        
        private CharacterMovementController _characterMovementController;
        private CharacterInputController _characterInputController;
        private CharacterPhysicsController _characterPhysicsController;
        private CharacterAnimatorController _characterAnimatorController;
        
        #endregion
        
        public void Initialize()
        {
            var ragdollJoints = GetComponentsInChildren<Rigidbody>().Where(x => x.gameObject != gameObject).ToList();
            var mainRigidbody = GetComponent<Rigidbody>();
            var animator = GetComponent<Animator>();
            
            _characterEventManager = new CharacterEventManager();
            _characterPhysicsManager = new CharacterPhysicsManager(ragdollJoints,mainRigidbody);
            
            _characterAnimatorController = new CharacterAnimatorController(animator);
            _characterPhysicsController = gameObject.AddComponent<CharacterPhysicsController>();
            _characterInputController = gameObject.AddComponent<CharacterInputController>();
            _characterMovementController = gameObject.AddComponent<CharacterMovementController>();

            _characterInputController.Initialize();
            _characterMovementController.Initialize(transform, 5f);
            _characterPhysicsController.Initialize(_characterPhysicsManager,_characterEventManager);
            
            // Controller Event Subscriptions
            _characterInputController.OnTapPressing += ()=>
            {
                _characterMovementController.Move();
                _characterAnimatorController.PerformRunAnimation();
            };

            _characterInputController.OnTapReleasing += () =>
            {
                _characterAnimatorController.PerformIdleAnimation();
            };

            // Character Event Subscriptions
            
            _characterEventManager.SubscribeEvent(CharacterEventType.ON_DEATH, Die);
            _characterEventManager.SubscribeEvent(CharacterEventType.ON_RESTARTED,Reset);
            
        }


        private void Die()
        {
            _characterAnimatorController.DeactivateAnimator();
            _characterInputController.DeactivateController();
        }
        
        private void Reset()
        {
            Timer.Instance.TimerWait(2f, () =>
            {
                _characterAnimatorController.ActivateAnimator();
                _characterPhysicsController.ResetPhysics();
                _characterInputController.ActivateController();
            });
        }
    }
}
