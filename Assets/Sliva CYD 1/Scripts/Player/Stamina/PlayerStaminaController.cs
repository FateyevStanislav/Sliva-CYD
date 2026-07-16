using UnityEngine;

namespace SlivaCYD1.Player.Stamina
{
    public class PlayerStaminaController : MonoBehaviour
    {
        [SerializeField] private PlayerInputReader playerInputReader;

        public bool IsSprintActive { get; private set; }

        public PlayerStaminaModel Model { get; private set; }

        private void Awake()
        {
            playerInputReader ??= GetComponent<PlayerInputReader>();
        }

        public void Initialize(PlayerStaminaModel model)
        {
            Model = model;
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

            IsSprintActive = wantsSprint && hasMoveInput && Model.CanRun;
        }

        private void DrainStamina()
        {
            var newStamina = Model.CurrentStamina 
                             - Model.SprintDrainPerSec * Time.deltaTime;
            Model.SetStamina(newStamina);
        }

        private void RegenerateStamina()
        {
            if (!Model.CanRegenerate)
                return;

            var newStamina = Model.CurrentStamina 
                             + Model.RegenerationPerSec * Time.deltaTime;
            Model.SetStamina(newStamina);
        }
    }
}