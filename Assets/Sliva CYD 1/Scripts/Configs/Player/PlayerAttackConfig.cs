using UnityEngine;

namespace SlivaCYD1.Configs.Player
{
    [CreateAssetMenu(fileName = "PlayerAttackConfig", menuName = "SlivaCYD1/Configs/Player/Attack")]
    public class PlayerAttackConfig : ScriptableObject
    {
        public float Damage = 10f;
        public float AttackRadius = 1f;
    }
}