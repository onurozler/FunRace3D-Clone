using System.Collections.Generic;
using UnityEngine;

namespace Game.CharacterSystem.Managers
{
    public class CharacterPhysicsManager
    { 
        private List<Rigidbody> _ragdollJoints;
        private Rigidbody _mainRigidbody;

        public CharacterPhysicsManager(List<Rigidbody> ragdollJoints, Rigidbody mainRigidbody)
        {
            _ragdollJoints = ragdollJoints;
            _mainRigidbody = mainRigidbody;
        }

        public List<Rigidbody> GetRagdollJoints()
        {
            return _ragdollJoints;
        }

        public Rigidbody GetMainRigidbody()
        {
            return _mainRigidbody;
        }
    }
}
