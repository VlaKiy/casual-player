using UnityEngine;

namespace Game.Entity
{
    public class CasualPlayerMovement
    {
        private float _speedForward;
        private float _speedHorizontal;
        private float _forceOfPushBack;

        private Rigidbody _rigidbody;

        public CasualPlayerMovement(Rigidbody rigidbody, float speedForward, float speedHorizontal, float forceOfPushBack)
        {
            _speedForward = speedForward;
            _rigidbody = rigidbody;
            _speedHorizontal = speedHorizontal;
            _forceOfPushBack = forceOfPushBack;
        }

        public void MoveHorizontal(float x)
        {
            MoveRigidbodyByVelocity(new Vector3(x * _speedHorizontal, 0, 0));
        }

        public void MoveForward()
        {
            MoveRigidbodyByVelocity(Vector3.forward * _speedForward);
        }

        public void PushBack()
        {
            MoveRigidbodyByVelocity(Vector3.back * _forceOfPushBack);
        }

        private void MoveRigidbodyByVelocity(Vector3 velocity)
        {
            _rigidbody.MovePosition(_rigidbody.position + velocity * Time.deltaTime);
        }
    }
}