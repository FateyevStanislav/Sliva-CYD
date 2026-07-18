using System;
using SlivaCYD1.Configs.Player;
using UnityEngine;

namespace SlivaCYD1.Player.Stamina
{
    public class PlayerStaminaModel
    {
        public float MaxStamina { get; private set; }
        public float CurrentStamina { get; private set; }
        
        public event Action<float> StaminaChanged;
        
        public float RegenerationPerSec { get; private set; }
        public float SprintDrainPerSec { get; private set; }
        
        public bool IsSprintActive { get; private set; }

        public bool CanRegenerate => CurrentStamina < MaxStamina;
        public bool CanRun => CurrentStamina >= SprintDrainPerSec;

        public PlayerStaminaModel(PlayerStaminaConfig config)
        {
            MaxStamina = config.MaxStamina;
            CurrentStamina = config.MaxStamina;
            RegenerationPerSec = config.RegenerationPerSec;
            SprintDrainPerSec = config.SprintDrainPerSec;
        }

        public void SetStamina(float currentStamina)
        {
            var clampedStamina = Mathf.Clamp(currentStamina, 0f, MaxStamina);

            if (Mathf.Approximately(CurrentStamina, clampedStamina))
                return;

            CurrentStamina = clampedStamina;
            StaminaChanged?.Invoke(CurrentStamina);
        }
        
        public void SetIsSprintActive(bool isActive)
        {
            IsSprintActive = isActive;
        }
    }
}