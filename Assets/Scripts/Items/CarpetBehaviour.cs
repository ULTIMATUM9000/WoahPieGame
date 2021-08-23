using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpetBehaviour : MonoBehaviour
{
	[SerializeField] float DestroyTime;
	[SerializeField] LayerMask enemyLayers;

	[SerializeField] float slowAmount;

	private void Start()
	{
		Destroy(gameObject, DestroyTime);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("ENEMY"))
		{
			collision.GetComponent<EnemyMovement>().CarpetSlowDown(slowAmount);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("ENEMY"))
		{
			collision.GetComponent<EnemyMovement>().ResetSlowDown();
		}
	}

	private void OnDestroy()
	{
		SlowReset();
	}

	void SlowReset()
	{
		Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(transform.position, transform.localScale, enemyLayers);

		if (hitEnemies != null)
		{
			foreach (Collider2D enemy in hitEnemies)
			{
				if(hitEnemies != null)
				{
					enemy.GetComponent<EnemyMovement>().ResetSlowDown();
				}
			}
		}
	}
}
