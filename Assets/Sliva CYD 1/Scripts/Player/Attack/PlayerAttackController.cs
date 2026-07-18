using SlivaCYD1.Enemy;
using UnityEngine;
using VContainer;

namespace SlivaCYD1.Player.Attack
{
    public class PlayerAttackController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private PlayerInputReader playerInputReader;
        [SerializeField] private Transform attackPoint;

        [Header("Settings")]
        [SerializeField] private LayerMask targetLayer;
        
        [Inject] private PlayerAttackModel playerAttackModel;

        private void Awake()
        {
            playerInputReader ??= GetComponent<PlayerInputReader>();
        }
        
        private void Update()
        {
            if (playerAttackModel.IsAttacking) return;

            if (playerInputReader.AttackRequested)
            {
                StartAttack();
                playerInputReader.ClearAttackRequest();
            }
        }

        private void StartAttack()
        {
            playerAttackModel.SetIsAttacking(true);
        }

        public void OnAttackHitFrame()
        {
            var candidates = Physics.OverlapSphere(
                attackPoint.position, 
                playerAttackModel.AttackRadius, 
                targetLayer);
    
            var hitDirection = attackPoint.forward; 
    
            ResolveHit(candidates, hitDirection);
        }
        
        private void ResolveHit(Collider[] candidates, Vector3 hitDirection)
        {
            foreach (var candidate in candidates)
            {
                if (candidate.TryGetComponent<IDamageable>(out var damageable)) 
                {
                    damageable.TakeDamage(playerAttackModel.Damage);
                    
                    if (candidate.TryGetComponent<DummyPhysicsShake>(out var shake))
                    {
                        shake.ApplyImpact(hitDirection);
                    }
                }
            }
        }

        public void OnAttackFinished()
        {
            playerAttackModel.SetIsAttacking(false);
        }
    }
}