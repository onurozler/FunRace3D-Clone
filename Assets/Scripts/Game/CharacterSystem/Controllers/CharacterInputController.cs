using System;
using UnityEngine;
using Utils;

namespace Game.CharacterSystem.Controllers
{
    public class CharacterInputController : MonoBehaviour
    {
        private bool _active;
        
        public event Action OnTapPressing;
        public event Action OnTapReleasing;

        public void Initialize()
        {
            _active = true;
        }

        public void ActivateController()
        {
            _active = true;
        }
        
        public void DeactivateController()
        {
            _active = false;
        }
        
        void FixedUpdate()
        {
            if(!_active)
                return;
            
            if (Input.GetMouseButton(0))
            {
                OnTapPressing.SafeInvoke();
            }
            else
            {
                OnTapReleasing.SafeInvoke();
            }
        }
    }
}
