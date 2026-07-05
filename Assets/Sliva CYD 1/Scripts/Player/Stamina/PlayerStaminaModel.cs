namespace SlivaCYD1.Player.Stamina
{
    public class PlayerStaminaModel
    {
        public float MaxStamina { get; }
        public float CurrentStamina { get; set; }
        
        public float RegenerationPerSec { get; }
        public float SprintDrainPerSec { get; }

        public bool CanRegenerate => CurrentStamina < MaxStamina;
        public bool CanRun => CurrentStamina >= SprintDrainPerSec;

        public PlayerStaminaModel(
            float maxStamina,
            float regenerationPerSec,
            float sprintDrainPerSec)
        {
            MaxStamina = maxStamina;
            CurrentStamina = maxStamina;
            RegenerationPerSec = regenerationPerSec;
            SprintDrainPerSec = sprintDrainPerSec;
        }
    }
}