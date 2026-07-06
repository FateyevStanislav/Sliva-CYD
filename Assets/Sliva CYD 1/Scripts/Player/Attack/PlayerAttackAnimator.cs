using UnityEngine;

namespace SlivaCYD1.Player.Attack
{
    public class PlayerAttackAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private string attackParameterName = "Attack";
        
        private int attackParameterHash;

        private void Awake()
        {
            animator ??= GetComponentInChildren<Animator>();
            attackParameterHash = Animator.StringToHash(attackParameterName);
        }

        public void UpdateAttackTrigger()
        {
            animator.SetTrigger(attackParameterHash);
        }
    }
}