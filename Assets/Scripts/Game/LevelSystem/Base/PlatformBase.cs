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
        public bool Active;
        
        public virtual void Initialize()
        {
            Active = true;
        }
    }
}
