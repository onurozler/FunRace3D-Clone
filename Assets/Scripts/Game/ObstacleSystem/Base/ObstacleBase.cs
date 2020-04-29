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
        public bool Active { get; private set; }
        public int Speed = 50;
        
        protected Transform _base;

        public void Activate()
        {
            Active = true;
            gameObject.SetActive(Active);
        }
        
        public void Deactivate()
        {
            Active = false;
            gameObject.SetActive(Active);
        }
    }
}
