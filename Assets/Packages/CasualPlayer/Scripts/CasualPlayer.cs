using Exceptor.Utilities;
using Game.Utils;
using UnityEngine;

namespace Game.Entity
{
    [RequireComponent(typeof(Rigidbody))]
    public class CasualPlayer : MonoBehaviour
    {
        [SerializeField] private float _speedForward = 5f;
        [SerializeField] private float _speedHorizontal = 5f;
        [SerializeField] private float _forceOfPushBack = 200f;

        [SerializeField] private bool _awakeForwardMovement = false;

        private bool _hasPlayerMovedJoystick = false;

        private Rigidbody _rigidbody;
        private CasualPlayerMovement _playerMovement;
        private CasualInputManager _inputManager;

        #region Monobehaviour
        private void Awake()
        {
            Initialize();
        }

        private void FixedUpdate()
        {
            if (_awakeForwardMovement)
            {
                _hasPlayerMovedJoystick = true;
            }

            if (_hasPlayerMovedJoystick)
            {
                MoveForward();
            }

            if (_inputManager.Joystick.Horizontal != 0)
            {
                MoveHorizontal(_inputManager.Joystick.Horizontal);
                _hasPlayerMovedJoystick = true;
            }
        }
        #endregion

        #region Initialization

        public void Initialize()
        {
            var casualInputManager = GameObject.Find("CasualInputManager");

            if (casualInputManager && casualInputManager.TryGetComponent(out CasualInputManager inputManager))
            {
                _inputManager = inputManager;
            }
            else
            {
                _inputManager.ThrowIfNull(nameof(_inputManager), "You should add CasualInputManager prefab to scene!");
            }

            _rigidbody = GetComponent<Rigidbody>();
            _playerMovement = new CasualPlayerMovement(_rigidbody, _speedForward, _speedHorizontal, _forceOfPushBack);
            
        }

        #endregion

        #region Movement

        public void PushBack()
        {
            _playerMovement.PushBack();
        }

        private void MoveHorizontal(float x)
        {
            _playerMovement.MoveHorizontal(x);
        }

        private void MoveForward()
        {
            _playerMovement.MoveForward();
        }


        #endregion

        public void Die()
        {
            _inputManager.DisableJoystick();
            TransformUtils.DetachAllChildren(transform);

            gameObject.SetActive(false);
        }
    }
}