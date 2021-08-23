using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : Enemy
{
    [SerializeField] protected int damage;

    public float attackRange = 1;

    private float nextAttackTime;
    [SerializeField] private float attackRate; //The interval of attack animation to do when you spam the left click
    [SerializeField] private float attackFrame; //the frame before the attack

    [SerializeField] private float attackCooldown;
    private float initAttackCooldown;

    bool attackCoolingDown = false;

    [SerializeField] LayerMask playerLayers;

    float distanceFromPlayer;

	private new void Start()
	{
        base.Start();
        initAttackCooldown = attackCooldown;
	}

	new void Update()
	{
        base.Update();

        if(Player != null)
		{
            distanceFromPlayer = Vector2.Distance(transform.position, Player.transform.position);
            CheckAttack();
        }
    }

    void CheckAttack()
    {
        if(distanceFromPlayer < attackRange && !attackCoolingDown)
		{
            StartCoroutine("AttackHit");
            //Debug.Log("Enemy Attacked");
            
        }
        if (attackCoolingDown)
        {
            Cooldown();
        }

        if (distanceFromPlayer > attackRange)
		{
            attackCooldown = initAttackCooldown;
            //ChangeAnimationState(MOVE);
            StopCoroutine("AttackHit");
        }
        
    }

    void Cooldown()
	{
        attackCooldown -= Time.deltaTime;

        //Debug.Log("Cooling Down");

        if (attackCooldown <= 0 && attackCoolingDown)
		{
            attackCoolingDown = false;
            attackCooldown = initAttackCooldown;
		}
	}

	IEnumerator AttackHit()
    {
        attackCoolingDown = true;
        yield return new WaitForSeconds(0.1f);

        ChangeAnimationState(ATTACK);

        yield return new WaitForSecondsRealtime(attackFrame);

        Collider2D hitPlayer = Physics2D.OverlapCircle(transform.position, attackRange, playerLayers);

        if(hitPlayer != null)
		{
            hitPlayer.GetComponent<PlayerHealth>().TakeDamage(damage);
        }

        yield return new WaitForSeconds(0.5f);
        ChangeAnimationState(IDLE);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
