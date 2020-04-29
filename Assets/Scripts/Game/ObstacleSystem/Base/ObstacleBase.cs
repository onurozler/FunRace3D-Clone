using UnityEngine;

namespace Game.ObstacleSystem.Base
{
    public enum ObstacleType
    {
        SQUEEZING,
        ROTATING
    }
    
    public abstract class ObstacleBase : MonoBehaviour
    {
        public abstract ObstacleType ObstacleType { get; }
        public bool Active;
        public int Speed;
        
        protected Transform _base;

        public virtual void Initialize()
        {
            Active = false;
            Speed = 50;
        }
    }
}
