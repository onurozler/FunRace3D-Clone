using Game.ObstacleSystem.ObstaclePiece;
using UnityEngine;

namespace Game.ObstacleSystem.Base
{
    public class RotatingObstacle : ObstacleBase
    {
        public override ObstacleType ObstacleType => ObstacleType.ROTATING;
        private Transform _rotationBlock;
        private bool _started = false;
        
        public override void Initialize()
        {
            _base = transform.Find("Base");
            _rotationBlock = GetComponentInChildren<RotatingPiece>().transform;
            _started = true;
        }

        public void FixedUpdate()
        {
            if(!_started)
                return;
            
            _rotationBlock.RotateAround(_base.position,Vector3.up, Speed * Time.deltaTime);
        }

    }
}
