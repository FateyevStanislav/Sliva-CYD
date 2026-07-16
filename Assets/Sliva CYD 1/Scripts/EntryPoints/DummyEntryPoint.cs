using UnityEngine;
using SlivaCYD1.Configs.Enemy;
using SlivaCYD1.Enemy;

namespace SlivaCYD1.EntryPoints
{
    public class DummyEntryPoint : MonoBehaviour
    {
        [SerializeField] private DummyHealthConfig healthConfig;
        [SerializeField] private DummyController dummyController;
        
        private void Awake()
        {
            var model = new DummyHealthModel(healthConfig);
            dummyController.Initialize(model);
        }
    }
}