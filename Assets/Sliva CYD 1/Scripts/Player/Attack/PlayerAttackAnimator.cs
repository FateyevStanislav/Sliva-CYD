using System;
using UnityEngine;
using VContainer;

namespace SlivaCYD1.Player.Attack
{
    public class PlayerAttackAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private string attackParameterName = "Attack";

        [Inject] private PlayerAttackModel playerAttackModel;
        private int attackParameterHash;
        
        private void Awake()
        {
            animator ??= GetComponentInChildren<Animator>();
            attackParameterHash = Animator.StringToHash(attackParameterName);
        }
        
        private void OnEnable()
        {
            playerAttackModel.OnAttacked += UpdateAttackTrigger;
        }

        private void OnDisable()
        {
            playerAttackModel.OnAttacked -= UpdateAttackTrigger;
        }

        private void UpdateAttackTrigger(PlayerAttackModel _)
        {
            animator.SetTrigger(attackParameterHash);
        }
    }
}