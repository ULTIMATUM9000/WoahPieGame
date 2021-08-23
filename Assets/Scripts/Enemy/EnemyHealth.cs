using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Enemy
{
	[SerializeField] GameObject DamageEffect;

	#region Enemy Type
	enum EnemyType
	{
		Recyclable,
		Decomposable,
		NonDecomposable,
		Mutated
	};


	[SerializeField] EnemyType enemyType;
	#endregion

	[SerializeField] GameObject dropObject;
	protected SpriteRenderer spriteRenderer;

	[SerializeField] int maxHealth = 3;
    [SerializeField] int currentHealth;

	[SerializeField] int mutatedMaxHealth;

	bool mutatedState = false;

	public bool isKnockBack = false;

	private void Awake()
	{
		currentHealth = maxHealth;
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private new void Update()
	{
		if (Player == null)
		{
			Player = GameObject.FindGameObjectWithTag("PLAYER");
		}
	}

	public void TakeDamage(int damage, float knockbackStrength, string PlayerAttackType)
	{
		Vector2 direction = Player.transform.position - transform.position;

		if (enemyType.ToString() == PlayerAttackType && !mutatedState)
		{
			currentHealth -= damage;
			rb.AddForce(-direction.normalized * knockbackStrength, ForceMode2D.Impulse);
			ChangeAnimationState(HURT);
			isKnockBack = true;
			spriteRenderer.color = Color.red;
			Instantiate(DamageEffect, this.gameObject.transform);

			Invoke("ResetKnockBack", 0.25f);
		}
		if(enemyType.ToString() != PlayerAttackType && !mutatedState)
		{
			StartCoroutine("MutatedState");
			//MutatedState();
			//Invoke("ResetKnockBack", 0.25f);
		}

		if(mutatedState)
		{
			currentHealth -= damage;
			rb.AddForce(-direction.normalized * knockbackStrength, ForceMode2D.Impulse);
			ChangeAnimationState(HURT);
			isKnockBack = true;
			spriteRenderer.color = Color.red;
			Instantiate(DamageEffect, this.gameObject.transform);
			Invoke("ResetKnockBack", 0.25f);
		}

		if (currentHealth <= 0)
		{
			Die();
		}
	}
	public void EcoBrickKnockBack(GameObject EcoBrick, float knockbackStrength)
	{
		Vector2 direction = EcoBrick.transform.position - transform.position;
		rb.AddForce(-direction.normalized * knockbackStrength, ForceMode2D.Impulse);

		isKnockBack = true;
		Invoke("ResetKnockBack", 0.25f);
	}

	public void BaseballBatDamage(int damage, float knockbackStrength)
	{
		Vector2 direction = Player.transform.position - transform.position;

		currentHealth -= damage;
		rb.AddForce(-direction.normalized * knockbackStrength, ForceMode2D.Impulse);

		isKnockBack = true;
		Invoke("ResetKnockBack", 0.25f);

		if (currentHealth <= 0)
		{
			Die();
		}
	}

	void ResetKnockBack()
	{
		rb.velocity = Vector2.zero;
		isKnockBack = false;

		if(!mutatedState)
		{
			spriteRenderer.color = Color.white;
		}

		if(mutatedState)
		{
			spriteRenderer.color = new Color(1, 0.33f, 0);
		}

		ChangeAnimationState(MOVE);
	}

	IEnumerator MutatedState()
	{
		spriteRenderer.color = new Color(1, 0.33f, 0);

		GAME_MANAGER.instance.currentEnemiesMutated += 1;

		maxHealth = mutatedMaxHealth;
		currentHealth = mutatedMaxHealth;

		yield return new WaitForSeconds(0.5f);

		mutatedState = true;
	}

	void Die()
	{
		ChangeAnimationState(DIE);

		GAME_MANAGER.instance.currentEnemiesDisposed += 1;

		Instantiate(dropObject, transform.localPosition, Quaternion.identity);

		Destroy(gameObject);
	}
}
