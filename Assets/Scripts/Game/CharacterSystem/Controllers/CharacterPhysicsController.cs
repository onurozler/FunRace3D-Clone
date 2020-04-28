using System;
using System.Linq;
using Game.CharacterSystem.Managers;
using Game.ObstacleSystem.Base;
using UnityEngine;
using Utils;

namespace Game.CharacterSystem.Controllers
{
    public class CharacterPhysicsController : MonoBehaviour
    {
        public event Action OnCharacterDied;

        private CharacterPhysicsManager _characterPhysicsManager;

        public void Initialize(CharacterPhysicsManager characterPhysicsManager)
        {
            _characterPhysicsManager = characterPhysicsManager;
            RagdollActivition(false);
        }

        public void ResetPhysics()
        {
            RagdollActivition(false);
            _characterPhysicsManager.ResetRagdollJoints();
        }

        private void RagdollActivition(bool activate)
        {
            _characterPhysicsManager.GetMainRigidbody().isKinematic = activate;
            _characterPhysicsManager.GetMainRigidbody().GetComponent<Collider>().enabled = !activate;
            
            var ragdolls = _characterPhysicsManager.GetRagdollJoints();
            foreach (var ragdoll in ragdolls)
            {
                ragdoll.GetComponent<Collider>().enabled = activate;
                ragdoll.isKinematic = !activate;
            }
        }
        
        private void OnCollisionEnter(Collision other)
        {
            var obstacle = other.gameObject.GetComponent<IObstaclePiece>();
            if (obstacle != null)
            {
                RagdollActivition(true);
                
                // Pushing ragdoll hips to get more realistic result
                var hips = _characterPhysicsManager.GetRagdollJoints().FirstOrDefault(x => x.gameObject.name == "Hips");
                obstacle.Push(hips);
                
                // Trigger character death event
                OnCharacterDied.SafeInvoke();
            }
        }
    }
}
