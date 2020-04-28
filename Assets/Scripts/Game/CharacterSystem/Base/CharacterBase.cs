using System.Linq;
using Game.CharacterSystem.Controllers;
using Game.CharacterSystem.Managers;
using UnityEngine;

namespace Game.CharacterSystem.Base
{
    public class CharacterBase : MonoBehaviour
    {

        #region Managers

        private CharacterPhysicsManager _characterPhysicsManager;

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
            
            _characterPhysicsManager = new CharacterPhysicsManager(ragdollJoints,mainRigidbody);
            _characterAnimatorController = new CharacterAnimatorController(animator);
            
            _characterPhysicsController = gameObject.AddComponent<CharacterPhysicsController>();
            _characterInputController = gameObject.AddComponent<CharacterInputController>();
            _characterMovementController = gameObject.AddComponent<CharacterMovementController>();

            _characterMovementController.Initialize(transform, 5f);
            _characterPhysicsController.Initialize(_characterPhysicsManager);
            
            _characterPhysicsController.RagdollActivition(false);
            
            // Event Subscriptions
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
    }
}
