﻿using System;
using UnityEngine;

namespace Enemy
{
    public class EnemyAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private const string IS_Electrified = "IsElectrified";
        private const string IS_Attacking = "IsAttacking";
        private const string IS_Death = "IsDeath";

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            animator.SetBool(IS_Electrified, false);
            animator.SetBool(IS_Death, false);
        }

        public void PlayElectrifiedAnimation()
        {
            if (!HasParameter(IS_Electrified))
            {
                animator.SetBool(IS_Death, true);
            }
            else
            {
                animator.SetBool(IS_Electrified, true);
            }
            
        }
        
        public void PlayIdleAnimation()
        {
            animator.SetBool(IS_Attacking, false);
        }
        
        public void PlayAttackAnimation()
        {
            animator.SetBool(IS_Attacking, true);
        }

        public void PlayDeathAnimation()
        {
            animator.SetBool(IS_Death, true);
        }
        
        public bool HasParameter(string parameterName)
        {
            foreach (AnimatorControllerParameter parameter in animator.parameters)
            {
                if (parameter.name == parameterName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}