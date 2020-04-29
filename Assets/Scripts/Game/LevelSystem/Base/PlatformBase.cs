using UnityEngine;

namespace Game.LevelSystem.Base
{
    public enum PlatformType
    {
        CLASSIC,
        FINISH
    }

    public class PlatformBase : MonoBehaviour
    {
        public virtual PlatformType PlatformType => PlatformType.CLASSIC;
        public bool Active { get; private set; }
        
        public void Activate()
        {
            Active = true;
            gameObject.SetActive(true);
        }
        
        public void Deactivate()
        {
            Active = false;
            gameObject.SetActive(false);
        }
    }
}
