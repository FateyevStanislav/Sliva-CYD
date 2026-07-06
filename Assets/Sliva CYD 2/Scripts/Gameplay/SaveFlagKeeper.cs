using UnityEngine;

namespace Sliva_CYD_2.Gameplay
{
    public class SaveFlagKeeper : MonoBehaviour
    {
        public static SaveFlagKeeper Instance { get; private set; }
        public bool ShouldLoadGame { get; set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}