using System;
using UnityEngine;

namespace Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private PlayerMovement playerMovement;

        private const string IS_Jumping = "IsJumping";
        private const string IS_Dead = "IsDead";

        private void OnEnable()
        {
            PlayerHealthSystem.onDeath += PlayerHealthSystem_OnDeath;
        }
        private void OnDisable()
        {
            PlayerHealthSystem.onDeath -= PlayerHealthSystem_OnDeath;
        }
        

        private void Update()
        {
            animator.SetBool(IS_Jumping, playerMovement.GetJumpState());
            //Debug.Log(animator.GetBool(IS_Jumping));
            //Debug.Log(animator.GetBool(IS_Dead));
        }

        public void SetAnimator(RuntimeAnimatorController  newAnimatorController)
        {
            animator.runtimeAnimatorController = newAnimatorController;
        }
        
        private void PlayerHealthSystem_OnDeath()
        {
            Debug.Log("Player is dead");
            //animator.updateMode = AnimatorUpdateMode.UnscaledTime; //changed in the component itself
            animator.SetBool(IS_Dead, true);
        }
    }
}