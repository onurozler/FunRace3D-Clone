using Game.ObstacleSystem.ObstaclePiece;
using UnityEngine;

namespace Game.AISystem.ObstacleDetection
{
    public class ObstacleDetector: MonoBehaviour
    {
        private Ray _ray;
        private RaycastHit _raycastHit;
        private bool _isHit = false;

        public bool IsHit()
        {
            return _isHit;
        }
        
        private void FixedUpdate()
        {
            Vector3 rayStart = transform.position;
            rayStart += new Vector3(0,1);
            
            _ray = new Ray(rayStart,transform.forward);
            
            if (Physics.Raycast(_ray,out _raycastHit,1f))
            {
                _isHit = _raycastHit.collider.GetComponent<IObstaclePiece>() != null;
            }
            else
            {
                _isHit = false;
            }
            
            Debug.DrawRay(_ray.origin,_ray.direction * 1f);
        }
        
    }
}
