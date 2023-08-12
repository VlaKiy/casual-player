using UnityEngine;

namespace Game
{
    public class CasualInputManager : MonoBehaviour
    {
        [SerializeField] private Joystick _joystick;

        public Joystick Joystick => _joystick;

        public void DisableJoystick()
        {
            _joystick.gameObject.SetActive(false);
        }

        public void EnableJoystick()
        {
            _joystick.gameObject.SetActive(true);
        }
    }
}