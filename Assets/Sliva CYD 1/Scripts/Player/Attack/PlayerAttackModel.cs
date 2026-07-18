using System;
using SlivaCYD1.Configs.Player;

namespace SlivaCYD1.Player.Attack
{
    public class PlayerAttackModel
    {
        public float Damage { get; private set; }
        public float AttackRadius { get; private set; }
        public bool IsAttacking { get; private set; }
        
        public event Action<PlayerAttackModel> OnAttacked;

        public PlayerAttackModel(PlayerAttackConfig config)
        {
            Damage = config.Damage;
            AttackRadius = config.AttackRadius;
        }

        public void SetIsAttacking(bool isAttacking)
        {
            IsAttacking = isAttacking;
            if (isAttacking)
                OnAttacked?.Invoke(this);
        }
    }
}