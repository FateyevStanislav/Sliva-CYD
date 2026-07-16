using UnityEngine;

namespace SlivaCYD1.Configs.Player
{
    [CreateAssetMenu(fileName = "PlayerMovementConfig", menuName = "SlivaCYD1/Configs/Player/Movement")]
    public class PlayerMovementConfig : ScriptableObject
    {
        public float WalkSpeed = 5f;
        public float RunSpeed = 10f;
        public float Acceleration = 8f;
        public float Deceleration = 20f;
        public float RotationSmooth = 10f;
    }
}