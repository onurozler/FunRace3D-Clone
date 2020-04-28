using System;
using UnityEngine;
using Utils;

namespace Game.CharacterSystem.Controllers
{
    public class CharacterInputController : MonoBehaviour
    {
        public bool Active;
        
        public event Action OnTapPressing;
        public event Action OnTapReleasing;

        public void Initialize()
        {
            Active = true;
        }
        
        void FixedUpdate()
        {
            if(!Active)
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
