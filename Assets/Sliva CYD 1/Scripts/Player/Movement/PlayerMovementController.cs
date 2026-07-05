using SlivaCYD1.Player.Stamina;
using UnityEngine;

namespace SlivaCYD1.Player.Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovementController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private CharacterController characterController;
        [SerializeField] private PlayerInputReader playerInputReader;
        [SerializeField] private PlayerMovementAnimatorView playerMovementAnimatorView;
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private PlayerStaminaController playerStaminaController;

        [Header("Settings")]
        [SerializeField] private float walkSpeed = 5f;
        [SerializeField] private float runSpeed = 10f;
        [SerializeField] private float acceleration = 8f;
        [SerializeField] private float deceleration = 20f;
        [SerializeField] private float rotationSmooth = 10f;
        
        private PlayerMovementModel playerMovementModel;

        private void Awake()
        {
            characterController ??= GetComponent<CharacterController>();
            playerInputReader ??= GetComponent<PlayerInputReader>();
            playerMovementAnimatorView ??= GetComponent<PlayerMovementAnimatorView>();
            playerStaminaController ??= GetComponent<PlayerStaminaController>();

            playerMovementModel = new PlayerMovementModel(
                walkSpeed,
                runSpeed,
                acceleration,
                deceleration,
                rotationSmooth);
        }
        
        private void Update()
        {
            UpdateSpeed();
            
            var moveDirection = GetMoveDirection();
            
            Move(moveDirection);
            Rotate(moveDirection);
            UpdateAnimation();
        }
        
        private void UpdateSpeed()
        {
            var targetSpeed = GetTargetSpeed();

            var changeRate = targetSpeed > playerMovementModel.CurrentSpeed
                ? playerMovementModel.Acceleration
                : playerMovementModel.Deceleration;

            playerMovementModel.CurrentSpeed = Mathf.MoveTowards(
                playerMovementModel.CurrentSpeed,
                targetSpeed,
                changeRate * Time.deltaTime);
        }
        
        private float GetTargetSpeed()
        {
            if (playerInputReader.MoveInput == Vector2.zero)
                return 0f;

            return playerStaminaController.IsSprintActive
                ? playerMovementModel.RunSpeed
                : playerMovementModel.WalkSpeed;
        }
        
        private void Move(Vector3 moveDirection)
        {
            var motion = moveDirection * (playerMovementModel.CurrentSpeed * Time.deltaTime);
            characterController.Move(motion);
        }
        
        private void Rotate(Vector3 moveDirection)
        {
            if (moveDirection == Vector3.zero)
                return;

            var targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                playerMovementModel.RotationSmooth * Time.deltaTime * 100f);
        }
        
        private Vector3 GetMoveDirection()
        {
            var input = playerInputReader.MoveInput;

            var forward = cameraTransform.forward;
            var right = cameraTransform.right;

            forward.y = 0f;
            right.y = 0f;

            forward.Normalize();
            right.Normalize();

            var moveDirection = forward * input.y + right * input.x;

            if (moveDirection.sqrMagnitude > 1f)
            {
                moveDirection.Normalize();
            }

            return moveDirection;
        }
        
        private void UpdateAnimation()
        {
            var normalizedSpeed = playerMovementModel.CurrentSpeed / playerMovementModel.RunSpeed;
            playerMovementAnimatorView.UpdateMovementSpeed(normalizedSpeed);
        }
    }
}