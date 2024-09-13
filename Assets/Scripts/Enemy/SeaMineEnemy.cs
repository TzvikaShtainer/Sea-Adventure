using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaMineEnemy : BaseEnemy
{
    [SerializeField] Animator animator;
    private const string IS_MINE_SPAWN = "IsMineSpawn";
    private void FixedUpdate()
    {
        if (transform.position.x <= 8.5) //when we see the mine on screen
        {
            animator.SetBool(IS_MINE_SPAWN, true);
        }
    }
}
