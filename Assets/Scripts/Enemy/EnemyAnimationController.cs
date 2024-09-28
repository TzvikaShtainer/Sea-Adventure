using System;
using UnityEngine;

namespace Enemy
{
    public class EnemyAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private const string IS_Electrified = "IsElectrified";
        private const string IS_Attacking = "IsAttacking";

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            animator.SetBool(IS_Electrified, false);
        }

        public void PlayElectrifiedAnimation()
        {
            animator.SetBool(IS_Electrified, true);
        }
        
        public void PlayIdleAnimation()
        {
            animator.SetBool(IS_Attacking, false);
        }
        
        public void PlayAttackAnimation()
        {
            animator.SetBool(IS_Attacking, true);
        }
    }
}