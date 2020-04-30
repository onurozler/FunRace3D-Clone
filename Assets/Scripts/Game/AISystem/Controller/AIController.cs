using Game.AISystem.Base;
using UnityEngine;

namespace Game.AISystem.Controller
{
    public class AIController : MonoBehaviour
    {
        [SerializeField]
        private AICharacter _basicAI;

        public void Initialize()
        {
            _basicAI.Initialize();
        }
        

        private void FixedUpdate()
        {
            
        }
    }
}
