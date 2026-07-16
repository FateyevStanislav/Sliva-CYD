using UnityEngine;

namespace SlivaCYD1.Configs.Enemy
{
    [CreateAssetMenu(fileName = "DummyHealthConfig", menuName = "SlivaCYD1/Configs/Enemy/Health")]
    public class DummyHealthConfig : ScriptableObject
    {
        public float MaxHealth = 50f;
        public float RespawnDelay = 3f;
    }
}