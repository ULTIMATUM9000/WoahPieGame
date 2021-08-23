using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBinBehavior : MonoBehaviour
{
    PlayerAttack playerAttack;
    private float nextAttackTime;
    [SerializeField] private float attackRate = 2f; //The interval of attack animation to do when you spam the left click
    private float AttackResetTime;
    [SerializeField] private float attackResetRate = 0.75f; //Seconds of not attacking to reset to first attack animation

    public enum BinType
	{
        Recyclable,
        Decomposable,
        NonDecomposable
	};

    [SerializeField] private BinType attackType; //Decomposable, NonDecomposable, Recyclable

    void Start()
    {
        playerAttack = GetComponentInParent<PlayerAttack>();
    }
	private void Update()
	{
        CheckAttackInput();
	}

	void CheckAttackInput()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButton(0))
            {
                AttackState(); //Do Attack Function\
                playerAttack.isAttacking = true;
                nextAttackTime = Time.time + 1f / attackRate; //sets the interval of the next attack anim
                AttackResetTime = Time.time + attackResetRate; //sets the reset time to first attack anim

                //Debug.Log("Attack Rate: " + 1f / attackRate);
                //Debug.Log("Reset Rate: " + attackResetRate);
            }
            if (Time.time >= AttackResetTime)
            {
                playerAttack.isAttacking = false;
                playerAttack.attackStateCounter = 0;
            }


        }
    }

    void AttackState()
    {
        if (playerAttack.attackStateCounter == 0)
        {
            AttackHit();
            playerAttack.attackStateCounter++;
            return;
        }
        if (playerAttack.attackStateCounter == 1)
        {
            AttackHit();
            playerAttack.attackStateCounter++;
            return;
        }
        if (playerAttack.attackStateCounter == 2)
        {
            AttackHit();
            playerAttack.attackStateCounter++;
            return;
        }
        if (playerAttack.attackStateCounter == 3)
        {
            AttackHit();
            playerAttack.attackStateCounter = 1;
            return;
        }
    }

    void AttackHit()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(playerAttack.attackPoint.position, playerAttack.attackRange, playerAttack.enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            if(enemy.GetComponent<EnemyHealth>() != null)
			{
                enemy.GetComponent<EnemyHealth>().TakeDamage(playerAttack.attackDamage, playerAttack.knockbackStrength, attackType.ToString());
            }
            if(enemy.GetComponent<ObstacleTrashBag>() != null)
			{
                enemy.GetComponent<ObstacleTrashBag>().TakeDamage(attackType.ToString());
            }
            
            AudioManager.instance.Play("HitEnemy");
        }

        AudioManager.instance.Play("TrashBinHit");
    }
}
