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

        public void ResolveHit(Collider[] candidates)
        {
            foreach (var candidate in candidates)
            {
                if (!candidate.TryGetComponent<IDamageable>(out var damageable)) 
                    continue;
                
                damageable.TakeDamage(Damage);
            }
        }
    }
}