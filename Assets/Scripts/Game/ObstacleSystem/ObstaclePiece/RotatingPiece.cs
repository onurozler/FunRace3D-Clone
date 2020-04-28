using Game.ObstacleSystem.Base;
using UnityEngine;

namespace Game.ObstacleSystem.ObstaclePiece
{
    public class RotatingPiece : MonoBehaviour, IObstaclePiece
    {
        public void Push(Rigidbody target)
        {
            target.AddRelativeForce(target.transform.forward * 10000f);
        }
    }
}
