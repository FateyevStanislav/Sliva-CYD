using UnityEngine;
using SlivaCYD1.Configs.Player;
using SlivaCYD1.Player.Movement;
using SlivaCYD1.Player.Stamina;
using SlivaCYD1.Player.Attack;

namespace SlivaCYD1.EntryPoints
{
    public class PlayerEntryPoint : MonoBehaviour
    {
        [Header("Configs")]
        [SerializeField] private PlayerMovementConfig movementConfig;
        [SerializeField] private PlayerStaminaConfig staminaConfig;
        [SerializeField] private PlayerAttackConfig attackConfig;
        
        [Header("Controllers")]
        [SerializeField] private PlayerMovementController movementController;
        [SerializeField] private PlayerStaminaController staminaController;
        [SerializeField] private PlayerAttackController attackController;
        
        private void Awake()
        {
            var movementModel = new PlayerMovementModel(movementConfig);
            var staminaModel = new PlayerStaminaModel(staminaConfig);
            var attackModel = new PlayerAttackModel(attackConfig);
            
            staminaController.Initialize(staminaModel);
            attackController.Initialize(attackModel);
            movementController.Initialize(movementModel, attackController, staminaController);
        }
    }
}