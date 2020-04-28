using Game.ObstacleSystem.Base;
using UnityEngine;

namespace Game.ObstacleSystem.ObstaclePiece
{
    public class MovePiece : MonoBehaviour, IObstaclePiece
    {
        public void Push(Rigidbody target)
        {
            target.AddForce(target.transform.up * 5000f);
        }
    }
}
