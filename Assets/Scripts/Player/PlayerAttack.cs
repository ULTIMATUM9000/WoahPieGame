using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : Player
{
    public float attackRange;
    public int attackDamage;

    [HideInInspector] public int attackStateCounter = 0;

    public float knockbackStrength = 1.5f;

    public bool isAttacking;
    public bool GreenBin;
    public bool RedBin;
    public bool BlueBin;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    void Update()
    {
        AttackPosition();
        AnimatorSetValues();
    }

    void AttackPosition()
	{
        if (Input.GetAxisRaw("Horizontal") >= 0.01)
		{
            attackPoint.transform.position = new Vector2(this.transform.position.x + 0.5f,this.transform.position.y);
		}
        if (Input.GetAxisRaw("Horizontal") <= -0.01)
		{
            attackPoint.transform.position = new Vector2(this.transform.position.x - 0.5f, this.transform.position.y);
		}
        if (Input.GetAxisRaw("Vertical") >= 0.01)
        {
            attackPoint.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 0.5f);
        }
        if (Input.GetAxisRaw("Vertical") <= -0.01)
        {
            attackPoint.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - 0.5f);
        }
    }    

    void AnimatorSetValues()
	{
        animator.SetInteger("Attack Value", attackStateCounter);
        animator.SetBool("isAttacking", isAttacking);
        animator.SetBool("GreenBin", GreenBin);
        animator.SetBool("BlueBin", BlueBin);
        animator.SetBool("RedBin", RedBin);
	}

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}