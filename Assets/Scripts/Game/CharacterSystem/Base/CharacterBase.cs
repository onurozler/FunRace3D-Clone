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
        
        private CharacterMovementController _characterMovementController;
        private CharacterInputController _characterInputController;
        private CharacterPhysicsController _characterPhysicsController;
        private CharacterAnimatorController _characterAnimatorController;
        
        #endregion

        private Camera _characterCamera;
        private Vector3 _cameraOffset;

        public void Initialize()
        {
            PlayerHealth = 3;
            
            _characterCamera = Camera.main;
            _cameraOffset = _characterCamera.transform.position - transform.position;

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
            _characterMovementController.Initialize(transform,GameConfig.CHARACTER_SPEED);
            _characterPhysicsController.Initialize(_characterPhysicsManager,_characterEventManager);

            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
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
            
            _characterEventManager.SubscribeEvent(CharacterEventType.ON_STARTED, () =>
            {
                PlayerHealth = 3;
                _characterInputController.ActivateController();
            });
            
            _characterEventManager.SubscribeEvent(CharacterEventType.ON_FINISHED, () =>
            {
                _characterAnimatorController.PerformIdleAnimation();
                _characterInputController.DeactivateController();
                _characterEventManager.InvokeEvent(CharacterEventType.ON_STARTED);
            });
            
            _characterEventManager.SubscribeEvent(CharacterEventType.ON_DEATH, OnDeath);
            _characterEventManager.SubscribeEvent(CharacterEventType.ON_RESTARTED, OnRestart);
        }


        public CharacterEventManager GetEventManager()
        {
            return _characterEventManager;
        }
        
        #region Camera

        private void LateUpdate()
        {
            if(_characterCamera == null)
                return;
            
            _characterCamera.transform.position = transform.position + _cameraOffset;
        }

        #endregion
        
        #region EventMethods

        private void OnDeath()
        {
            _characterAnimatorController.DeactivateAnimator();
            _characterInputController.DeactivateController();
            
            PlayerHealth--;

            _characterEventManager.InvokeEvent(CharacterEventType.ON_RESTARTED);
        }
        
        private void OnRestart()
        {
            Timer.Instance.TimerWait(2f, () =>
            {
                _characterAnimatorController.ActivateAnimator();
                _characterInputController.ActivateController();
                
                
                _characterPhysicsController.ResetPhysics();

                /*
                if (PlayerHealth <= 0)
                {
                
                }
                else
                {
                    _characterPhysicsController.RevertPhysics();
                }*/
            });
        }
        
        #endregion
    }
}
