using System.Collections.Generic;
using UnityEngine;

namespace Game.CharacterSystem.Managers
{
    public class CharacterPhysicsManager
    { 
        private List<Rigidbody> _ragdollJoints;
        private Rigidbody _mainRigidbody;

        #region TempPositions

        private List<Vector3> _lastRagdollPosition;
        private List<Vector3> _lastRagdollRotation;
        private Vector3 _lastMainPosition;
        
        
        private List<Vector3> _firstRagdollPosition;
        private List<Vector3> _firstRagdollRotation;
        private Vector3 _firstMainPosition;

        #endregion

        
        public CharacterPhysicsManager(List<Rigidbody> ragdollJoints, Rigidbody mainRigidbody)
        {
            _ragdollJoints = ragdollJoints;
            _mainRigidbody = mainRigidbody;

            _firstMainPosition = mainRigidbody.transform.position;
            _firstRagdollPosition = new List<Vector3>();
            _firstRagdollRotation = new List<Vector3>();
            foreach (var rigidbody in _ragdollJoints)
            {
                _firstRagdollPosition.Add(rigidbody.transform.position);
                _firstRagdollRotation.Add(rigidbody.transform.eulerAngles);
            }
        }

        public void SaveRagdollJoints()
        {
            _lastMainPosition = _mainRigidbody.transform.position;
            _lastRagdollPosition = new List<Vector3>();
            _lastRagdollRotation = new List<Vector3>();
            foreach (var rigidbody in _ragdollJoints)
            {
                _lastRagdollPosition.Add(rigidbody.transform.position);
                _lastRagdollRotation.Add(rigidbody.transform.eulerAngles);
            }
        }

        public void RevertRagdollJoints()
        {
            for (int i = 0; i < _ragdollJoints.Count; i++)
            {
                _ragdollJoints[i].position = _lastRagdollPosition[i];
                _ragdollJoints[i].transform.eulerAngles = _firstRagdollRotation[i];
            }
            _mainRigidbody.transform.position = _lastMainPosition;
        }
        
        public void ResetRagdollJoints()
        {
            for (int i = 0; i < _ragdollJoints.Count; i++)
            {
                _ragdollJoints[i].position = _firstRagdollPosition[i];
                _ragdollJoints[i].transform.eulerAngles = _firstRagdollRotation[i];
            }
            _mainRigidbody.transform.position = _firstMainPosition;
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
