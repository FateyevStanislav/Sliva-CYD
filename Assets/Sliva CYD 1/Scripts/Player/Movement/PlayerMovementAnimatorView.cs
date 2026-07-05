using UnityEngine;

namespace SlivaCYD1.Player.Movement
{
    public class PlayerMovementAnimatorView : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private string speedParameterName = "Speed";
        
        private int speedParameterHash;

        private void Awake()
        {
            animator ??= GetComponentInChildren<Animator>();
            speedParameterHash = Animator.StringToHash(speedParameterName);
        }

        public void UpdateMovementSpeed(float normalizedSpeed)
        {
            animator.SetFloat(speedParameterHash, normalizedSpeed);
        }
    }
}