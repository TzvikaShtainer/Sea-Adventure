using System;
using UnityEngine;

namespace Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private PlayerMovement playerMovement;

        private const string IS_Jumping = "IsJumping";
        private void Update()
        {
            animator.SetBool(IS_Jumping, playerMovement.GetJumpState());
        }
    }
}