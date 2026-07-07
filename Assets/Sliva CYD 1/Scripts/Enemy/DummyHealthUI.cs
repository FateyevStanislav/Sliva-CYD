using UnityEngine;
using UnityEngine.UI;

namespace SlivaCYD1.Enemy
{
    [DefaultExecutionOrder(100)]
    public class DummyHealthUI : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private DummyController dummyController;
        [SerializeField] private Slider healthSlider;

        private void OnEnable()
        {
            if (dummyController != null)
            {
                dummyController.Model.HealthChanged += UpdateHealthBar;
                UpdateHealthBar(dummyController.Model.CurrentHealth);
            }
        }

        private void OnDisable()
        {
            if (dummyController != null)
            {
                dummyController.Model.HealthChanged -= UpdateHealthBar;
            }
        }

        private void UpdateHealthBar(float currentHealth)
        {
            healthSlider.maxValue = dummyController.Model.MaxHealth;
            healthSlider.value = currentHealth;
        }
    }
}