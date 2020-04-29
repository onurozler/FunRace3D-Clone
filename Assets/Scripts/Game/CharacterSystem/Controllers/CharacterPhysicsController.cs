using System.Linq;
using Game.CharacterSystem.Events;
using Game.CharacterSystem.Managers;
using Game.LevelSystem.Base;
using Game.ObstacleSystem.ObstaclePiece;
using UnityEngine;

namespace Game.CharacterSystem.Controllers
{
    public class CharacterPhysicsController : MonoBehaviour
    {
        private CharacterEventManager _characterEventManager;
        private CharacterPhysicsManager _characterPhysicsManager;

        public void Initialize(CharacterPhysicsManager characterPhysicsManager, CharacterEventManager characterEventManager)
        {
            _characterEventManager = characterEventManager;
            _characterPhysicsManager = characterPhysicsManager;
            RagdollActivition(false);
        }

        public void RevertPhysics()
        {
            RagdollActivition(false);
            _characterPhysicsManager.RevertRagdollJoints();
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
                //_characterPhysicsManager.SaveRagdollJoints();
                
                RagdollActivition(true);
                
                // Pushing ragdoll hips to get more realistic result
                var hips = _characterPhysicsManager.GetRagdollJoints().FirstOrDefault(x => x.gameObject.name == "Hips");
                obstacle.Push(hips);
                
                // Invoke proper event
                _characterEventManager.InvokeEvent(CharacterEventType.ON_DEATH);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            var finish = other.GetComponent<EndPlatform>();
            if (finish != null)
            {
                _characterEventManager.InvokeEvent(CharacterEventType.ON_FINISHED);
            }
        }
    }
}
