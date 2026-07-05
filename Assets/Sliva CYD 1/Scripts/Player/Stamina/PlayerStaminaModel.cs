using System;
using UnityEngine;

namespace SlivaCYD1.Player.Stamina
{
    public class PlayerStaminaModel
    {
        public float MaxStamina { get; }
        public float CurrentStamina { get; private set; }
        
        public event Action<float> StaminaChanged;
        
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

        public void SetStamina(float currentStamina)
        {
            var clampedStamina = Mathf.Clamp(currentStamina, 0f, MaxStamina);

            if (Mathf.Approximately(CurrentStamina, clampedStamina))
                return;

            CurrentStamina = clampedStamina;
            StaminaChanged?.Invoke(CurrentStamina);
        }
    }
}