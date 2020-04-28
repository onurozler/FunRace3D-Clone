using System;
using Game.CharacterSystem.Managers;
using UnityEngine;

namespace Game.CharacterSystem.Controllers
{
    public class CharacterPhysicsController : MonoBehaviour
    {
        private CharacterPhysicsManager _characterPhysicsManager;

        public void Initialize(CharacterPhysicsManager characterPhysicsManager)
        {
            _characterPhysicsManager = characterPhysicsManager;
        }

        public void RagdollActivition(bool activate)
        {
            var ragdolls = _characterPhysicsManager.GetRagdollJoints();
            foreach (var ragdoll in ragdolls)
            {
                ragdoll.isKinematic = !activate;
            }
        }


        private void OnCollisionEnter(Collision other)
        {
            
        }
    }
}
