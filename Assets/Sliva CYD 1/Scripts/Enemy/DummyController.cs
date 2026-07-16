using System.Collections;
using UnityEngine;

namespace SlivaCYD1.Enemy
{
    public class DummyController : MonoBehaviour, IDamageable
    {
        [Header("Settings")]
        [SerializeField] private float maxHealth = 50f;
        [SerializeField] private float respawnDelay = 3f;
        [SerializeField] private GameObject visuals;

        public DummyHealthModel Model { get; private set; }

        private void Awake()
        {
            Model.Died += HandleDeath;
        }

        public void Initialize(DummyHealthModel model)
        {
            Model = model;
        }

        public void TakeDamage(float amount)
        {
            Model.TakeDamage(amount);
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

            Model.Respawn();
            
            if (visuals != null)
                visuals.SetActive(true);
        }
        
        private void OnDestroy()
        {
            Model.Died -= HandleDeath;
        }
    }
}