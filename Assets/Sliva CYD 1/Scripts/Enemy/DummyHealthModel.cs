using System;
using UnityEngine;

namespace SlivaCYD1.Enemy
{
    public class DummyHealthModel
    {
        public float MaxHealth { get; }
        public float CurrentHealth { get; private set; }
        
        public event Action<float> HealthChanged;
        public event Action Died;

        public DummyHealthModel(float maxHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
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