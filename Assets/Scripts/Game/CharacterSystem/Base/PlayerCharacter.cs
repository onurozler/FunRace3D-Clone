using Game.CharacterSystem.Controllers;
using Game.CharacterSystem.Events;
using UnityEngine;
using Utils;

namespace Game.CharacterSystem.Base
{
    public class PlayerCharacter : CharacterBase
    {
        private CharacterInputController _characterInputController;
        
        private Camera _characterCamera;
        private Vector3 _cameraOffset;

        public override void Initialize()
        {
            base.Initialize();
            _characterCamera = Camera.main;
            _cameraOffset = _characterCamera.transform.position - transform.position;
            
            _characterInputController = gameObject.AddComponent<CharacterInputController>();
            _characterInputController.Initialize();

            SubscribeControllerEvents();
            
            GetEventManager().SubscribeEvent(CharacterEventType.ON_STARTED, () =>  _characterInputController.ActivateController());
            GetEventManager().SubscribeEvent(CharacterEventType.ON_FINISHED, () =>
            {
                _characterInputController.DeactivateController();
                GetEventManager().InvokeEvent(CharacterEventType.ON_STARTED);
            });
            GetEventManager().SubscribeEvent(CharacterEventType.ON_DEATH, ()=>_characterInputController.DeactivateController());
            GetEventManager().SubscribeEvent(CharacterEventType.ON_RESTARTED, () =>
                {
                    Timer.Instance.TimerWait(1f, () => _characterInputController.ActivateController());
                });
        }

        private void SubscribeControllerEvents()
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
        }


        #region Camera

        private void LateUpdate()
        {
            if(_characterCamera == null)
                return;
            
            _characterCamera.transform.position = transform.position + _cameraOffset;
        }

        #endregion
    }
}
