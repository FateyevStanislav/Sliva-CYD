using System.Collections;
using UnityEngine;

namespace SlivaCYD1.Enemy
{
    [RequireComponent(typeof(Rigidbody))]
    public class DummyPhysicsShake : MonoBehaviour
    {
        [SerializeField] private float shakeForce = 50f;
        [SerializeField] private Rigidbody rb;

        public void ApplyImpact(Vector3 direction)
        {
            StartCoroutine(ImpactRoutine(direction));
        }

        private IEnumerator ImpactRoutine(Vector3 direction)
        {
            rb.isKinematic = false;
            
            yield return new WaitForFixedUpdate();
            rb.AddForce(direction * shakeForce, ForceMode.Impulse);
            
            yield return new WaitForSeconds(0.5f);
            
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
        }
    }
}