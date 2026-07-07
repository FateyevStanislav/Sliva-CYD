using System.Collections;
using UnityEngine;

namespace SlivaCYD1.Enemy
{
    [DefaultExecutionOrder(-100)]
    public class DummyController : MonoBehaviour, IDamageable
    {
        [Header("Settings")]
        [SerializeField] private float maxHealth = 50f;
        [SerializeField] private float respawnDelay = 3f;
        [SerializeField] private GameObject visuals;

        private DummyHealthModel healthModel;
        public DummyHealthModel Model => healthModel;

        private void Awake()
        {
            healthModel = new DummyHealthModel(maxHealth);
            healthModel.Died += HandleDeath;
        }

        public void TakeDamage(float amount)
        {
            healthModel.TakeDamage(amount);
        }

        private void HandleDeath()
        {
            if (visuals != null)
                visuals.SetActive(false);
            
            StartCoroutine(RespawnRoutine());
        }

        private IEnumerator RespawnRoutine()
        {
            yield return new WaitForSeconds(respawnDelay);

            healthModel.Respawn();
            
            if (visuals != null)
                visuals.SetActive(true);
        }
        
        private void OnDestroy()
        {
            healthModel.Died -= HandleDeath;
        }
    }
}