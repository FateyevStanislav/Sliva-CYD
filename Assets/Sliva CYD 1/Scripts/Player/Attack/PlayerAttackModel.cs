using SlivaCYD1.Configs.Player;
using SlivaCYD1.Enemy;
using UnityEngine;

namespace SlivaCYD1.Player.Attack
{
    public class PlayerAttackModel
    {
        public float Damage { get; private set; }
        public float AttackRadius { get; private set; }

        public PlayerAttackModel(PlayerAttackConfig config)
        {
            Damage = config.Damage;
            AttackRadius = config.AttackRadius;
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