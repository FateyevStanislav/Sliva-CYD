using SlivaCYD1.Configs.Player;

namespace SlivaCYD1.Player.Movement
{
    public class PlayerMovementModel
    {
        public float WalkSpeed { get; private set; }
        public float RunSpeed { get; private set; }
        public float CurrentSpeed { get; set; }
        
        public float Acceleration { get; }
        public float Deceleration { get; }
        
        public float RotationSmooth { get; }
        
        public PlayerMovementModel(PlayerMovementConfig config)
        {
            WalkSpeed = config.WalkSpeed;
            RunSpeed = config.RunSpeed;
            Acceleration = config.Acceleration;
            Deceleration = config.Deceleration;
            RotationSmooth = config.RotationSmooth;
            CurrentSpeed = 0f;
        }
    }
}