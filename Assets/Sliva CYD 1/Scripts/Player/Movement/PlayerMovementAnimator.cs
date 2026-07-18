using UnityEngine;
using VContainer;

namespace SlivaCYD1.Player.Movement
{
    public class PlayerMovementAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private string speedParameterName = "Speed";
        
        private int speedParameterHash;
        [Inject] private PlayerMovementModel playerMovementModel;
        
        private void Awake()
        {
            animator ??= GetComponentInChildren<Animator>();
            speedParameterHash = Animator.StringToHash(speedParameterName);
        }
        
        private void OnEnable()
        {
            playerMovementModel.OnCurrentSpeedChanged += UpdateMovementSpeed;
        }

        private void OnDisable()
        {
            playerMovementModel.OnCurrentSpeedChanged -= UpdateMovementSpeed;
        }

        public void UpdateMovementSpeed(PlayerMovementModel playerMovementModel)
        {
            var normalizedSpeed = playerMovementModel.CurrentSpeed / playerMovementModel.RunSpeed;
            animator.SetFloat(speedParameterHash, normalizedSpeed);
        }
    }
}