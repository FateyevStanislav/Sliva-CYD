using UnityEngine;

namespace SlivaCYD1.Configs.Player
{
    [CreateAssetMenu(fileName = "PlayerStaminaConfig", menuName = "SlivaCYD1/Configs/Player/Stamina")]
    public class PlayerStaminaConfig : ScriptableObject
    {
        public float MaxStamina = 100f;
        public float RegenerationPerSec = 5f;
        public float SprintDrainPerSec = 10f;
    }
}