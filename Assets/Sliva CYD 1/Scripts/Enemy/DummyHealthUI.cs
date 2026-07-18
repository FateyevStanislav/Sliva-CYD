using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace SlivaCYD1.Enemy
{
    public class DummyHealthUI : MonoBehaviour
    {
        [SerializeField] private Slider healthSlider;

        [Inject] private DummyHealthModel dummyHealthModel;
        
        private void OnEnable()
        {
            dummyHealthModel.HealthChanged += UpdateHealthBar;
            UpdateHealthBar(dummyHealthModel);
        }

        private void OnDisable()
        {
            dummyHealthModel.HealthChanged -= UpdateHealthBar;
        }

        private void UpdateHealthBar(DummyHealthModel dummyHealthModel)
        {
            healthSlider.maxValue = dummyHealthModel.MaxHealth;
            healthSlider.value = dummyHealthModel.CurrentHealth;
        }
    }
}