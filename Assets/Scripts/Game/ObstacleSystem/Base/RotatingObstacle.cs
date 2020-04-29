using Game.ObstacleSystem.ObstaclePiece;
using UnityEngine;

namespace Game.ObstacleSystem.Base
{
    public class RotatingObstacle : ObstacleBase
    {
        public override ObstacleType ObstacleType => ObstacleType.ROTATING;
        
        private Transform _rotationBlock;

        private void Awake()
        {
            _base = transform.Find("Base");
            _rotationBlock = GetComponentInChildren<RotatingPiece>().transform;
        }

        public void FixedUpdate()
        {
            _rotationBlock.RotateAround(_base.position,Vector3.up, Speed * Time.deltaTime);
        }

    }
}
