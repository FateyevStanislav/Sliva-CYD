using System;
using SlivaCYD1.Configs.Enemy;
using UnityEngine;

namespace SlivaCYD1.Enemy
{
    public class DummyHealthModel
    {
        public float MaxHealth { get; private set; }
        public float CurrentHealth { get; private set; }
        
        public event Action<float> HealthChanged;
        public event Action Died;

        public DummyHealthModel(DummyHealthConfig config)
        {
            MaxHealth = config.MaxHealth;
            CurrentHealth = config.MaxHealth;
        }

        public void TakeDamage(float amount)
        {
            if (CurrentHealth <= 0) return;
            
            CurrentHealth -= amount;
            CurrentHealth = Mathf.Max(0, CurrentHealth);
            
            HealthChanged?.Invoke(CurrentHealth);

            if (CurrentHealth <= 0)
            {
                Died?.Invoke();
            }
        }
        
        public void Respawn()
        {
            CurrentHealth = MaxHealth;
            HealthChanged?.Invoke(CurrentHealth);
        }
    }
}