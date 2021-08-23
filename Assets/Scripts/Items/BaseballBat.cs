using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseballBat : MonoBehaviour
{
	[SerializeField] GameObject BaseballEffect;

	[SerializeField] Transform player;

	[SerializeField] int attackDamage;
	[SerializeField] float attackRange;
	[SerializeField] float knockbackStrength;
	[SerializeField] LayerMask enemyLayers;

	private void Update()
	{
		CheckInput();
	}

	void CheckInput()
	{
		if (Input.GetMouseButtonDown(1) && ItemManager.instance.BaseballBat > 0)
		{
			BaseballBatAttack();
			ItemManager.instance.BaseballBat -= 1;
		}
	}

	void BaseballBatAttack()
	{
		Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(player.position, attackRange, enemyLayers);

		foreach (Collider2D enemy in hitEnemies)
		{
			enemy.GetComponent<EnemyHealth>().BaseballBatDamage(attackDamage, knockbackStrength);
		}

		AudioManager.instance.Play("BaseBallBatSFX");

		Instantiate(BaseballEffect, player.transform);
	}

	private void OnDrawGizmosSelected()
	{
		if (player == null)
			return;

		Gizmos.DrawWireSphere(player.position, attackRange);
	}
}
