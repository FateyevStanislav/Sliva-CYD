using UnityEngine;

namespace SlivaCYD1.Player.Attack
{
    public class PlayerAttackController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private PlayerInputReader playerInputReader;
        [SerializeField] private PlayerAttackAnimator playerAttackAnimator;
        [SerializeField] private Transform attackPoint;

        [Header("Settings")]
        [SerializeField] private float damage = 10f;
        [SerializeField] private float attackRadius = 1f;
        [SerializeField] private LayerMask targetLayer;
        
        public bool IsAttacking { get; private set; }

        private PlayerAttackModel playerAttackModel;

        private void Awake()
        {
            playerInputReader ??= GetComponent<PlayerInputReader>();
            playerAttackAnimator ??= GetComponent<PlayerAttackAnimator>();
            playerAttackModel = new PlayerAttackModel(damage);
        }

        private void Update()
        {
            if (IsAttacking) return;

            if (playerInputReader.AttackRequested)
            {
                StartAttack();
                playerInputReader.ClearAttackRequest();
            }
        }

        private void StartAttack()
        {
            IsAttacking = true;
            playerAttackAnimator.UpdateAttackTrigger();
        }

        public void OnAttackHitFrame()
        {
            var candidates = Physics.OverlapSphere(attackPoint.position, attackRadius, targetLayer);
    
            var hitDirection = attackPoint.forward; 
    
            playerAttackModel.ResolveHit(candidates, hitDirection);
        }

        public void OnAttackFinished()
        {
            IsAttacking = false;
        }
    }
}