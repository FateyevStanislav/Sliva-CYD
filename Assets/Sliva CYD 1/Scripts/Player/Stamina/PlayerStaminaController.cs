using UnityEngine;
using VContainer;

namespace SlivaCYD1.Player.Stamina
{
    public class PlayerStaminaController : MonoBehaviour
    {
        [SerializeField] private PlayerInputReader playerInputReader;
        
        [Inject] private PlayerStaminaModel playerStaminaModel;

        private void Awake()
        {
            playerInputReader ??= GetComponent<PlayerInputReader>();
        }

        private void Update()
        {
            UpdateSprintState();

            if (playerStaminaModel.IsSprintActive)
                DrainStamina();
            else
                RegenerateStamina();
        }

        private void UpdateSprintState()
        {
            var hasMoveInput = playerInputReader.MoveInput != Vector2.zero;
            var wantsSprint = playerInputReader.IsSprintPressed;

            playerStaminaModel.SetIsSprintActive(wantsSprint && hasMoveInput && playerStaminaModel.CanRun);
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