using SlivaCYD1.Player.Attack;
using SlivaCYD1.Player.Stamina;
using UnityEngine;
using VContainer;

namespace SlivaCYD1.Player.Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovementController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private CharacterController characterController;
        [SerializeField] private PlayerInputReader playerInputReader;
        [SerializeField] private PlayerMovementAnimator playerMovementAnimator;
        [SerializeField] private Transform cameraTransform;
        
        [Inject] private PlayerStaminaModel playerStaminaModel;
        [Inject] private PlayerMovementModel playerMovementModel;

        private void Awake()
        {
            characterController ??= GetComponent<CharacterController>();
            playerInputReader ??= GetComponent<PlayerInputReader>();
            playerMovementAnimator ??= GetComponent<PlayerMovementAnimator>();
        }
        
        private void Update()
        {
            UpdateSpeed();
            
            var moveDirection = GetMoveDirection();
            
            Move(moveDirection);
            Rotate(moveDirection);
        }
        
        private void UpdateSpeed()
        {
            var targetSpeed = GetTargetSpeed();

            var changeRate = targetSpeed > playerMovementModel.CurrentSpeed
                ? playerMovementModel.Acceleration
                : playerMovementModel.Deceleration;

            playerMovementModel.SetCurrentSpeed(Mathf.MoveTowards(
                playerMovementModel.CurrentSpeed,
                targetSpeed,
                changeRate * Time.deltaTime));
        }
        
        private float GetTargetSpeed()
        { 
            if (playerInputReader.MoveInput == Vector2.zero)
                return 0f;

            return playerStaminaModel.IsSprintActive
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
    }
}