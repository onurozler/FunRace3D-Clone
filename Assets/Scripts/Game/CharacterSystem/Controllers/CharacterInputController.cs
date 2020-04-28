using System;
using UnityEngine;

namespace Game.CharacterSystem.Controllers
{
    public class CharacterInputController : MonoBehaviour
    {
        public event Action OnTapPressing;
        public event Action OnTapReleasing; 
        
        void FixedUpdate()
        {
            if (Input.GetMouseButton(0))
            {
                if (OnTapPressing != null) OnTapPressing();
            }
            else
            {
                if (OnTapReleasing != null) OnTapReleasing();
            }
        }
    }
}
