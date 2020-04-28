using UnityEngine;

namespace Game.CharacterSystem.Controllers
{
    public class CharacterMovementController: MonoBehaviour
    {
        private Transform _characterTransform;
        private float _speed;

        public void Initialize(Transform characterTransform, float speed)
        {
            _characterTransform = characterTransform;
            _speed = speed;
        }

        public void Move()
        {
            _characterTransform.Translate(_characterTransform.transform.forward * (Time.deltaTime * _speed));
        }
    }
}
