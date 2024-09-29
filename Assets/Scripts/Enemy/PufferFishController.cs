using Enemy;
using UnityEngine;

enum EnemyState
{
    Idle, 
    Attack
}
public class PufferFishController : MonoBehaviour
{
    [SerializeField] private EnemyAnimationController enemyAnimationController;
    [SerializeField] private MoveToPlayer moveToPlayer;
    [SerializeField] private CircleCollider2D enemyCollider;
    
    [SerializeField] private EnemyState currentState;
    [SerializeField] private float rotationSpeed;
    
    [Header("Idle")]
    [SerializeField] private float idleDuration;
    [SerializeField] private float idleSpeed;
    
    [Header("Attack")]
    [SerializeField] private float attackDuration;
    [SerializeField] private float attackSpeed;
    
    private float stateTimer;
    private Quaternion originalRotation;
    


    private void Start()
    {
        attackDuration = Random.Range(1, 3);
        idleDuration = Random.Range(1, 3);
        
        ChangeState(EnemyState.Idle);
        originalRotation = transform.rotation;
    }
    
    private void Update()
    {
        stateTimer -= Time.deltaTime;

        switch (currentState)
        {
            case EnemyState.Idle:
                if (stateTimer <= 0f)
                {
                    ChangeState(EnemyState.Attack);
                }

                break;

            case EnemyState.Attack:
                if (stateTimer <= 0f)
                {
                    ChangeState(EnemyState.Idle);
                }

                break;
        }
    }

    private void ChangeState(EnemyState state)
    {
       currentState = state;

       switch (state)
       {
           case EnemyState.Idle:
               stateTimer = idleDuration;
               OnEnterIdle();
               break;
           
           case EnemyState.Attack:
               stateTimer = attackDuration;
               OnEnterAttack();
               break;
       }
    }
    
    private void OnEnterIdle()
    {
        enemyAnimationController.PlayIdleAnimation();
        
        enemyCollider.enabled = false;
        
        moveToPlayer.SetLeftSpeed(idleSpeed);
        
        transform.rotation = Quaternion.Slerp(originalRotation, originalRotation, rotationSpeed);
    }

    private void OnEnterAttack()
    {
        enemyAnimationController.PlayAttackAnimation();
        
        enemyCollider.enabled = true;
        
        moveToPlayer.SetLeftSpeed(attackSpeed);
        
        float randomRotation = Random.Range(-50, 100);
        transform.rotation = Quaternion.Slerp(originalRotation, Quaternion.Euler(0f, 0f, randomRotation), rotationSpeed);
        
    }
}
