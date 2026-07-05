using UnityEngine;

namespace SlivaCYD1.Player.Stamina
{
    [DefaultExecutionOrder(-100)]
    public class PlayerStaminaController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private PlayerInputReader playerInputReader;

        [Header("Settings")]
        [SerializeField] private float maxStamina = 100f;
        [SerializeField] private float regenerationPerSec = 5f;
        [SerializeField] private float sprintDrainPerSec = 10f;

        public bool IsSprintActive { get; private set; }

        private PlayerStaminaModel playerStaminaModel;
        public PlayerStaminaModel Model => playerStaminaModel;

        private void Awake()
        {
            playerInputReader ??= GetComponent<PlayerInputReader>();

            playerStaminaModel = new PlayerStaminaModel(
                maxStamina,
                regenerationPerSec,
                sprintDrainPerSec);
        }

        private void Update()
        {
            UpdateSprintState();

            if (IsSprintActive)
                DrainStamina();
            else
                RegenerateStamina();
        }

        private void UpdateSprintState()
        {
            var hasMoveInput = playerInputReader.MoveInput != Vector2.zero;
            var wantsSprint = playerInputReader.IsSprintPressed;

            IsSprintActive = wantsSprint && hasMoveInput && playerStaminaModel.CanRun;
        }

        private void DrainStamina()
        {
            var newStamina = playerStaminaModel.CurrentStamina 
                             - playerStaminaModel.SprintDrainPerSec * Time.deltaTime;
            playerStaminaModel.SetStamina(newStamina);
        }

        private void RegenerateStamina()
        {
            if (!playerStaminaModel.CanRegenerate)
                return;

            var newStamina = playerStaminaModel.CurrentStamina 
                             + playerStaminaModel.RegenerationPerSec * Time.deltaTime;
            playerStaminaModel.SetStamina(newStamina);
        }
    }
}