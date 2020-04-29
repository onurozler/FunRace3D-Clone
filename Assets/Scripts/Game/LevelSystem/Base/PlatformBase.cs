using UnityEngine;

namespace Game.LevelSystem.Base
{
    public enum PlatformType
    {
        NONE,
        FINISH
    }

    public class PlatformBase : MonoBehaviour
    {
        public virtual PlatformType PlatformType => PlatformType.NONE;
        public bool Active;
        
        public virtual void Initialize()
        {
            Active = true;
        }
    }
}
