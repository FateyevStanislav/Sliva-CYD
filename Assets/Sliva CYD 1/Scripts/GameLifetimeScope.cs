using UnityEngine;
using VContainer;
using VContainer.Unity;
using SlivaCYD1.Configs.Player;
using SlivaCYD1.Configs.Enemy;
using SlivaCYD1.Player.Movement;
using SlivaCYD1.Player.Stamina;
using SlivaCYD1.Player.Attack;
using SlivaCYD1.Enemy;
using SlivaCYD1.Camera;
using SlivaCYD1.Player;

namespace SlivaCYD1
{
    public class GameLifetimeScope : LifetimeScope
    {
        [Header("Player Configs")]
        [SerializeField] private PlayerMovementConfig movementConfig;
        [SerializeField] private PlayerStaminaConfig staminaConfig;
        [SerializeField] private PlayerAttackConfig attackConfig;
        
        [Header("Enemy Configs")]
        [SerializeField] private DummyHealthConfig dummyHealthConfig;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(movementConfig);
            builder.RegisterInstance(staminaConfig);
            builder.RegisterInstance(attackConfig);
            builder.RegisterInstance(dummyHealthConfig);

            builder.Register<PlayerMovementModel>(Lifetime.Singleton);
            builder.Register<PlayerStaminaModel>(Lifetime.Singleton);
            builder.Register<PlayerAttackModel>(Lifetime.Singleton);
            builder.Register<DummyHealthModel>(Lifetime.Singleton);

            builder.RegisterComponentInHierarchy<PlayerInputReader>();
            builder.RegisterComponentInHierarchy<PlayerMovementController>();
            builder.RegisterComponentInHierarchy<PlayerStaminaController>();
            builder.RegisterComponentInHierarchy<PlayerAttackController>();
            builder.RegisterComponentInHierarchy<PlayerAttackAnimator>();
            builder.RegisterComponentInHierarchy<PlayerMovementAnimator>();
            builder.RegisterComponentInHierarchy<DummyController>();
            builder.RegisterComponentInHierarchy<DummyHealthUI>();
            builder.RegisterComponentInHierarchy<PlayerStaminaUI>();
            builder.RegisterComponentInHierarchy<ThirdPersonCameraController>();
        }
    }
}