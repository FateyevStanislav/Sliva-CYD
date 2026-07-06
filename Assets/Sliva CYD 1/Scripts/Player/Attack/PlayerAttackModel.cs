using SlivaCYD1.Enemy;
using UnityEngine;

namespace SlivaCYD1.Player.Attack
{
    public class PlayerAttackModel
    {
        public float Damage { get; }

        public PlayerAttackModel(float damage)
        {
            Damage = damage;
        }

        public void ResolveHit(Collider[] candidates, Vector3 hitDirection)
        {
            foreach (var candidate in candidates)
            {
                if (candidate.TryGetComponent<IDamageable>(out var damageable)) 
                {
                    damageable.TakeDamage(Damage);
                    
                    if (candidate.TryGetComponent<DummyPhysicsShake>(out var shake))
                    {
                        shake.ApplyImpact(hitDirection);
                    }
                }
            }
        }
    }
}