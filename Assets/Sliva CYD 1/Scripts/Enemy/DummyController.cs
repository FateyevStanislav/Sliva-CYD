using System.Collections;
using UnityEngine;
using VContainer;

namespace SlivaCYD1.Enemy
{
    public class DummyController : MonoBehaviour, IDamageable
    {
        [Header("Settings")]
        [SerializeField] private float respawnDelay = 3f;
        [SerializeField] private GameObject visuals;

        [Inject] private DummyHealthModel dummyHealthModel;

        private void Awake()
        {
            dummyHealthModel.Died += HandleDeath;
        }

        public void TakeDamage(float amount)
        {
            dummyHealthModel.TakeDamage(amount);
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

            dummyHealthModel.Respawn();
            
            if (visuals != null)
                visuals.SetActive(true);
        }
        
        private void OnDestroy()
        {
            dummyHealthModel.Died -= HandleDeath;
        }
    }
}