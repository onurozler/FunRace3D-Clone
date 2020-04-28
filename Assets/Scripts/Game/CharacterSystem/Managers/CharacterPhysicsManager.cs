using System.Collections.Generic;
using UnityEngine;

namespace Game.CharacterSystem.Managers
{
    public class CharacterPhysicsManager
    { 
        private List<Rigidbody> _ragdollJoints;
        private Rigidbody _mainRigidbody;

        private List<Vector3> _tempRagdollPosition;
        private List<Vector3> _tempRagdollRotation;
        private Vector3 _tempMainPosition;
        
        public CharacterPhysicsManager(List<Rigidbody> ragdollJoints, Rigidbody mainRigidbody)
        {
            _ragdollJoints = ragdollJoints;
            _mainRigidbody = mainRigidbody;

            _tempMainPosition = mainRigidbody.transform.position;
            _tempRagdollPosition = new List<Vector3>();
            _tempRagdollRotation = new List<Vector3>();
            foreach (var rigidbody in _ragdollJoints)
            {
                _tempRagdollPosition.Add(rigidbody.transform.position);
                _tempRagdollRotation.Add(rigidbody.transform.eulerAngles);
            }
        }

        public void ResetRagdollJoints()
        {
            for (int i = 0; i < _ragdollJoints.Count; i++)
            {
                _ragdollJoints[i].position = _tempRagdollPosition[i];
                _ragdollJoints[i].transform.eulerAngles = _tempRagdollRotation[i];
            }
            _mainRigidbody.transform.position = _tempMainPosition;
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
