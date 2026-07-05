namespace SlivaCYD1.Player.Movement
{
    public class PlayerMovementModel
    {
        public float WalkSpeed { get; }
        public float RunSpeed { get; }
        public float Acceleration { get; }
        public float Deceleration { get; }
        public float RotationSmooth { get; }

        public float CurrentSpeed { get; set; }

        public PlayerMovementModel(
            float walkSpeed,
            float runSpeed,
            float acceleration,
            float deceleration,
            float rotationSmooth)
        {
            WalkSpeed = walkSpeed;
            RunSpeed = runSpeed;
            Acceleration = acceleration;
            Deceleration = deceleration;
            RotationSmooth = rotationSmooth;
            CurrentSpeed = 0f;
        }
    }
}