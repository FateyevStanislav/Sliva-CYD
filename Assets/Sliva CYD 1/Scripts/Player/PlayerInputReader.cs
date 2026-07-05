using UnityEngine;
using UnityEngine.InputSystem;

namespace SlivaCYD1.Player
{
    public class PlayerInputReader : MonoBehaviour
    {
        public Vector2 MoveInput { get; private set; }
        public bool IsSprintPressed { get; private set; }

        public void OnMove(InputValue value) => MoveInput = value.Get<Vector2>();

        public void OnSprint(InputValue value) => IsSprintPressed = value.isPressed;
    }
}
